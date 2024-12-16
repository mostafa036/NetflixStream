using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Subscriptiones
{
    public class SubscriptionPlanDtos
    {
        public string Duration { get; set; } = string.Empty;
        public string PlanName { get; set; } = string.Empty;
        public decimal price { get; set; }
        public string Ads { get; set; } = string.Empty;
        public string Shows { get; set; } = string.Empty;
        public string MobileGames { get; set; } = string.Empty;
        public int DevicesSimultaneous { get; set; }
        public string Quality { get; set; } = string.Empty;
        public string ExtraMembers { get; set; } = string.Empty;
        public int Downloads { get; set; }
        public string spatialaudio { get; set; } = string.Empty;
    }
}
