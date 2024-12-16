using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs
{
    public class WatchMovieRequest
    {
        public string MoviesName { get; set; } = null!;
        public int Id { get; set; }
    }
}
