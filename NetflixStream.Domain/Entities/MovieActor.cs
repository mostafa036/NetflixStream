using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class MovieActor
    {
        public string CharacterName { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public Movies Movie { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!; 
    }
}
