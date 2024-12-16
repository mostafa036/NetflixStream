using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Subscriptiones
{
    public class UpdateDirectorForSeriesDto
    {
        public int DirectorId { get; set; }
        public int SeriesId { get; set; }
    }
}
