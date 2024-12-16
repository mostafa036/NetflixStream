using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.DTOs.Movies;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Services
{
    public class MovieService
    {
        private readonly NetflixStreamDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(NetflixStreamDbContext context , IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public Movies CreateMovieEntity(MovieCreateDTO movieDto)
        {
            var genres = _context.Genres.Where(g => movieDto.GenreIds.Contains(g.ID)).ToList();

            var countries = _context.Countries.Where(c => movieDto.CountryIds.Contains(c.ID)).ToList();

            var languages = _context.Languages.Where(l => movieDto.LanguageIds.Contains(l.ID)).ToList();

            var directors = _context.Directors.Where(d => movieDto.DirectorIds.Contains(d.ID)).ToList();

            var producers = _context.Producers.Where(p => movieDto.ProducerIds.Contains(p.ID)).ToList();

            
            return new Movies
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Duration = movieDto.Duration,
                ReleaseDate = movieDto.ReleaseDate,
                AgeRating = movieDto.AgeRating,
                IMDbRating = movieDto.IMDbRating,
                Writer = movieDto.Writer,
                Genres = genres,
                Countries = countries,
                languages = languages,
                Directors = directors,
                Producers = producers,

                MovieActors = movieDto.ActorCharacterNames.Select(kv => new MovieActor
                {
                    ActorId = kv.Key, // Actor ID
                    CharacterName = kv.Value // Character Name
                }).ToList(),
            };
        }

        private void UpdateMovieProperties(Movies movie, MovieCreateDTO movieDto)
        {
            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.Duration = movieDto.Duration;
            movie.ReleaseDate = movieDto.ReleaseDate;
            movie.AgeRating = movieDto.AgeRating;
            movie.IMDbRating = movieDto.IMDbRating;
            movie.Writer = movieDto.Writer;
        }

        public async Task<bool> UpdateMovieAsync(int id, MovieCreateDTO movieDto)
        {
            var existingMovie = await _unitOfWork.baseRepository<Movies>().GetByIdAsync(id);

            if (existingMovie == null) throw new Exception("Movie not found");

            UpdateMovieProperties(existingMovie, movieDto);

            await UpdateRelatedEntities(existingMovie.Genres, movieDto.GenreIds, _unitOfWork);
            await UpdateRelatedEntities(existingMovie.Countries, movieDto.CountryIds, _unitOfWork);
            await UpdateRelatedEntities(existingMovie.languages, movieDto.LanguageIds, _unitOfWork);
            await UpdateRelatedEntities(existingMovie.Directors, movieDto.DirectorIds, _unitOfWork);
            await UpdateRelatedEntities(existingMovie.Producers, movieDto.ProducerIds, _unitOfWork);
            await UpdateActorCharacterForMovies(existingMovie, movieDto.ActorCharacterNames);

            var result = await _unitOfWork.Commit();

            return result > 0;


        }

        public async Task UpdateRelatedEntities<TEntity>(ICollection<TEntity> existingEntities, List<int> newIds , IUnitOfWork unitOfWork)
            where TEntity : BaseEntity  , new()
        {
            existingEntities.Clear();

            foreach (var id in newIds)
            {
                var entity = await unitOfWork.baseRepository<TEntity>().GetByIdAsync(id);
                if (entity != null)
                {
                    existingEntities.Add(entity);
                }
            }
        }

        public async Task UpdateActorCharacterForMovies(Movies movie, Dictionary<int, string> actorCharacterNames)
        {
            movie.MovieActors.Clear();

            foreach (var actorId in actorCharacterNames.Keys)
            {
                var actor = await _unitOfWork.baseRepository<Actor>().GetByIdAsync(actorId);
                if (actor != null)
                {
                    movie.MovieActors.Add(new MovieActor
                    {
                        Actor = actor,
                        CharacterName = actorCharacterNames[actorId]
                    });
                }
            }
        }

        public async Task UpdateActorCharacterForSeries(Series series, Dictionary<int, string> actorCharacterNames)
        {
            series.SeriesActors.Clear();

            foreach (var actorId in actorCharacterNames.Keys)
            {
                var actor = await _unitOfWork.baseRepository<Actor>().GetByIdAsync(actorId);
                if (actor != null)
                {
                    series.SeriesActors.Add(new SeriesActor
                    {
                        Actor = actor,
                        CharacterName = actorCharacterNames[actorId]
                    });
                }
            }
        }

    }
}
