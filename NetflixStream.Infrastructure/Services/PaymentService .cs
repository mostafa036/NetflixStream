using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetflixStream.Application.IServices;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Contexts;
using Stripe;
using PaymentMethod = NetflixStream.Domain.UserIdentity.PaymentMethod;


namespace NetflixStream.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManagementContext _context;

        public PaymentService(IConfiguration configuration , UserManagementContext context )
        {
            _configuration = configuration;
           
            _context = context;
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(string Email, decimal amount, string currency, int paymentMethodId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(pm => pm.PaymentMethodId == paymentMethodId);


            if (paymentMethod == null || !paymentMethod.IsActive)
            {
                throw new Exception("Invalid or inactive payment method.");
            }

            var processingFee = (amount * paymentMethod.ProcessingFee)/ 100;

            var totalAmount = amount + processingFee;

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(totalAmount * 100),
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" },
                Metadata = new Dictionary<string, string>
                {
                    { "PaymentMethodId", paymentMethod.ToString() } // You can store additional metadata
                }
            };

            var service = new PaymentIntentService();

            var paymentIntent = await service.CreateAsync(options);

            return paymentIntent;

        }

     

        public Task<Payments?> GetPaymentByIdAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payments>> GetPaymentsByUserSubscriptionIdAsync(int userSubscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePaymentStatusAsync(int paymentId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
