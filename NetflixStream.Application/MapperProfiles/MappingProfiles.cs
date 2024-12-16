using AutoMapper;

using NetflixStream.Application.DTOs.Actors;
using NetflixStream.Application.DTOs.Directors;
using NetflixStream.Application.DTOs.Movies;
using NetflixStream.Application.DTOs.Payments;
using NetflixStream.Application.DTOs.Series;
using NetflixStream.Application.DTOs.Subscriptiones;
using NetflixStream.Application.DTOs.Users;
using NetflixStream.Application.Resolvers;
using NetflixStream.Domain.Entities;
using NetflixStream.Domain.UserIdentity;
using System;

namespace NetflixStream.Application.MapperProfiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Movies, MovieCardDTO>()
                 .ForMember(d => d.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name)))
                 .ForMember(d => d.Views, opt => opt.MapFrom(src => src.WatchCount))
                 .ForMember(d => d.PosterPath, opt => opt.MapFrom<PictureUrlResolver>());

            CreateMap<MovieStore, MovieTrailerReturnDTO>()
                 .ForMember(d => d.TrailerUrl, opt => opt.MapFrom<UrlResolver>());

            CreateMap<Episode, EpisodePosterReturnDTO>()
                .ForMember(d => d.FilePath, opt => opt.MapFrom<EpisodePosterResolver>());

            CreateMap<Movies, MoviePosterReturnDTO>()
                 .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.ID))
                 .ForMember(dest => dest.PosterName, opt => opt.MapFrom(src => src.PosterName))
                 .ForMember(dest => dest.PosterPath, opt => opt.MapFrom<PosterUrlResolver>());

            CreateMap<Movies , MovieReturnFullDetails>()
                 .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name)))
                 .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(c => c.Name)))
                 .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.languages.Select(l => l.Name)))
                 .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => d.Name)))
                 .ForMember(dest => dest.Producers, opt => opt.MapFrom(src => src.Producers.Select(p => p.Name)))
                 .ForMember(dest => dest.MoviePhotos, opt => opt.MapFrom(src => src.moviePhotos.Select(mp => mp.Url)));

            CreateMap<Movies, MovieCastReturnDto>()
                 .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => d.Name)))
                 .ForMember(dest => dest.Producers, opt => opt.MapFrom(src => src.Producers.Select(p => p.Name)));

            CreateMap<Director, DirectorDto>()
                 .ForMember(dest => dest.SeriesName, opt => opt.MapFrom(src => src.Series.Select(s => s.Title)))
                 .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movies.Select(s => s.Title)));

            CreateMap<MovieActor, MovieActorDto>()
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Actor.FullName))
                 .ForMember(dest => dest.CharacterName, opt => opt.MapFrom(src => src.CharacterName))
                 .ForMember(dest => dest.ActorPhotoPath, opt => opt.MapFrom(src => src.Actor.PhotoPath)); 

            CreateMap<UserSubscriptions, UserSubscriptionsDto>()
                 .ForMember(dest => dest.SubscriptionPlanName, opt => opt.MapFrom(src => src.SubscriptionPlans.PlanName))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.SubscriptionPlans.Price));

            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<SubscriptionPlanDtos, SubscriptionPlans>().ReverseMap();
        }
    }
}