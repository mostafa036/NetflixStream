using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class SeriesActor  
    {
        public string CharacterName { get;  set; } = string.Empty;
        public int SeriesId { get; set; }
        public Series Series { get; set; } 
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
