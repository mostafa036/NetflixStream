using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Subscriptiones
{
    public class SubscriptionPaymentRequest
    {

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
        [Required]
        public int PaymentMethodId { get; set; }
    }
}
