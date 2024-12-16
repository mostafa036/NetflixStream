using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; private set; } = string.Empty;
        public int RegionsId { get; set; }
        public Region Regions { get; set; } = null!;
        public ICollection<User> User { get; set; } = new HashSet<User>();
    }

}
