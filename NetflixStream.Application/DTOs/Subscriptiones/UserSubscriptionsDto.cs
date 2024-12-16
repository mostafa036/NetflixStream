using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Subscriptiones
{
    public class UserSubscriptionsDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string SubscriptionPlanName { get; set; } = string.Empty;// Assuming you want to return the plan name
        public decimal Price { get; set; } // Assuming subscription plan has a price
    }
}
