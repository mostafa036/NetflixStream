using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class SubscriptionPlans
    {
        public int SubscriptionPlansId { get; set; }
        public string Duration { get;  set; } = string.Empty;
        public string PlanName { get;  set; } = string.Empty;
        public decimal Price { get; set; }
        public string Ads { get;  set; } = string.Empty;
        public string Shows { get;set; } = string.Empty;
        public string MobileGames { get;set; } = string.Empty;
        public int DevicesSimultaneous { get; set; }
        public string VideoQuality { get; set; } = string.Empty;
        public string ExtraMembers { get; set; } = string.Empty;
        public int Downloads  { get; set; }
        public string SpatialAudio{ get; set; } = string.Empty;
        public ICollection<UserSubscriptions>? UserSubscriptions { get; set; }// Navigation property
    }
}
