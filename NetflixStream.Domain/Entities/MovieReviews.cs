using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class MovieReviews :BaseEntity
    {
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; }
        public int MovieID { get; set; }
        public Movies Movie { get; set; }  // Navigation property
        public int Rating { get; set; }  // Rating can be from 1 to 5 or custom logic
        public string ReviewText { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; }
    }
}
