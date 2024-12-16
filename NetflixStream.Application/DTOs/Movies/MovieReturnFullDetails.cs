using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetflixStream.Application.DTOs.Actors;

namespace NetflixStream.Application.DTOs.Movies
{
    public class MovieReturnFullDetails
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ReleaseDate { get; set; }
        public int Views { get; set; }
        public string AgeRating { get; set; } = string.Empty;
        public decimal IMDbRating { get; set; }
        public string Writer { get; set; } = string.Empty;
        public string? PosterPath { get; set; }
        public IEnumerable<string>? Genres { get; set; }
        public IEnumerable<string>? Countries { get; set; }
        public IEnumerable<string>? Languages { get; set; }
        public IEnumerable<string>? Directors { get; set; }
        public IEnumerable<string>? Producers { get; set; }
        public IEnumerable<MovieActorDto>? MovieActors { get; set; }
        public IEnumerable<string>? MoviePhotos { get; set; }
    }
}
