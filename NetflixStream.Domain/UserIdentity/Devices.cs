using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; private set; } = string.Empty;
        public string IPAddress { get; private set; } = string.Empty;
        public DateTime LastUsed { get; set; }
        public int DeviceType { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public int RegionId { get; set; }
        public Region Region { get; set; } = null!;

    }

}
