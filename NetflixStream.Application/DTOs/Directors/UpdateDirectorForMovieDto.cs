using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Directors
{
    public class UpdateDirectorForMovieDto
    {
        public int DirectorId { get; set; }
        public int MovieId { get; set; }
    }
}
