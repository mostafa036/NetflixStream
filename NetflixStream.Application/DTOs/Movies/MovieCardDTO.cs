using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Movies
{
    public class MovieCardDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseDate { get; set; }
        public int Views { get; set; }
        public string AgeRating { get; set; }
        public decimal IMDbRating { get; set; }
        public string PosterPath { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
