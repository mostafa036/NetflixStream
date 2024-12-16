using NetflixStream.Domain.UserIdentity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.IServices
{
    public interface IPaymentService
    {
        Task<PaymentIntent> CreatePaymentIntentAsync(string Email ,decimal amount, string currency , int paymentMethodId);
        Task<Payments?> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<Payments>> GetPaymentsByUserSubscriptionIdAsync(int userSubscriptionId);
        Task<bool> UpdatePaymentStatusAsync(int paymentId, string newStatus);
    }
}
