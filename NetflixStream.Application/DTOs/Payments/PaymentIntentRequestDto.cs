using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Payments
{
    public class PaymentIntentRequestDto
    {
        public string Currency { get; set; }
        public List<string> PaymentMethodTypes { get; set; }
        public int SubscriptionPlansId { get; set; }
    }
}
