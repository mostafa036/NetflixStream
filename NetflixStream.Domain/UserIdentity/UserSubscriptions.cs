using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class UserSubscriptions
    {
        public int UserSubscriptionId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending"; // Default to 'Pending'
        public string UserId { get; set; }
        public User User { get; set; }
        public int SubscriptionPlansId { get; set; }
        public SubscriptionPlans SubscriptionPlans { get; set; } = null!;
        public ICollection<Payments>? Payments { get; set; }
    }
}
