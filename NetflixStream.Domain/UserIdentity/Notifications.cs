using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; private set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime DateSent { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }

}
