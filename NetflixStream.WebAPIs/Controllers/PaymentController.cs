using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.DTOs.Subscriptiones;
using NetflixStream.Application.IServices;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Contexts;
using System.Security.Claims;

namespace NetflixStream.WebAPIs.Controllers
{
    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly UserManager<User> _userManager;
        private readonly UserManagementContext _context;

        public PaymentController(IPaymentService paymentService ,
            ISubscriptionService subscriptionService ,
            UserManager<User> userManager,
            UserManagementContext context)
        {
            _paymentService = paymentService;
            _subscriptionService = subscriptionService;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("PayForSubscription")]
        public async Task<ActionResult> PayForSubscription([FromBody] SubscriptionPaymentRequest request)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
                return Unauthorized(new ApiResponse(401, "User not found with the provided email."));

            var UserSubscriptionPrice = await _context.UserSubscriptions.Include(x => x.SubscriptionPlans).FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (UserSubscriptionPrice == null || UserSubscriptionPrice.SubscriptionPlans == null)
                return BadRequest(new ApiResponse(400, "User subscription or subscription plan not found."));


            var subscriptionPrice = UserSubscriptionPrice.SubscriptionPlans.Price;

            if (request.Amount < subscriptionPrice)
            {
                return BadRequest(new ApiResponse(400, "Insufficient payment amount."));
            }

            var paymentIntent = await _paymentService.CreatePaymentIntentAsync(Email, request.Amount, request.Currency, request.PaymentMethodId);


            if (paymentIntent.Status == "succeeded")
            {
                // Update the user subscription status to Active
                await _subscriptionService.UpdateUserSubscriptionStatusAsync(user.Id, "Active");
            }
            return Ok(new
            {
                PaymentIntentId = paymentIntent.Id,
                ClientSecret = paymentIntent.ClientSecret,
                Status = paymentIntent.Status
            });

        }

    }
}
