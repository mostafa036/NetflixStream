using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public string? TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string CurrencyCode { get; set; } = string.Empty;

        public int UserSubscriptionId { get; set; }
        public UserSubscriptions UserSubscription { get; set; } = null!;

        public int PaymentMethodid { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
