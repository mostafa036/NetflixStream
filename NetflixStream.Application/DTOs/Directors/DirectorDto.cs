using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Directors
{
    public class DirectorDto
    {
        public string Name { get; set; } = string.Empty;
        public IReadOnlyList<string>? MovieName { get; set; }
        public IReadOnlyList<string>? SeriesName { get; set; }
    }
}
