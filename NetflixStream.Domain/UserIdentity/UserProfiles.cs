using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class UserProfile 
    {
        public int UserProfileId { get; set; }
        public string Nickname { get; private set; } = string.Empty;
        public string Languages { get; private set; } = string.Empty;
        public bool IsAdult { get; set; }
        public ProfilePhotoes profilePhotoes { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
