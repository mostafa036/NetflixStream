using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public int DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public char Gender { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } = new HashSet<MovieActor>();
        public ICollection<SeriesActor> SeriesActors { get; set; } = new HashSet<SeriesActor>();
    }
}
