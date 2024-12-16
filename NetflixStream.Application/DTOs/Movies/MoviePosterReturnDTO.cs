using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Movies
{
    public class MoviePosterReturnDTO
    {
        public int MovieId { get; set; }
        public string PosterName { get; set; } = string.Empty;
        public string PosterPath { get; set; } = string.Empty;
    }
}
