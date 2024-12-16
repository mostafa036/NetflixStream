using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
        public ICollection<Series> Series { get; set; } = new List<Series>();
    }
}
