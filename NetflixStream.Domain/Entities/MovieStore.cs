using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class MovieStore : BaseEntity
    {
        public string? TrailerPath { get; set; } = string.Empty;
        public string? FilePath { get; set; } = string.Empty;
        public int MoviesId { get; set; }
        public Movies Movies { get; set; } = null!;
    } 
}
