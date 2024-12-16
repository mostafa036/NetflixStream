using System;
using System.Collections.Generic;
using System.Linq;
using NetflixStream.Application.DTOs.Actors;

namespace NetflixStream.Application.DTOs.Movies
{
    public class MovieCastReturnDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public string? PosterPath { get; set; } = string.Empty;
        public string Writer { get; set; } = string.Empty;
        public IEnumerable<string>? Directors { get; set; }
        public IEnumerable<string>? Producers { get; set; }
        public IEnumerable<MovieActorDto>? MovieActors { get; set; }
    }
}
