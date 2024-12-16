using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Directors
{
    public class ActorReturnDto
    {
        public string FullName { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
        public string MovieName { get; set; } = string.Empty;
    }
}
