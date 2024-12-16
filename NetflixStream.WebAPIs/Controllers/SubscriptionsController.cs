using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.DTOs.Subscriptiones;
using NetflixStream.Application.IServices;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Contexts;
using Stripe;
using System.Runtime.InteropServices;
using System.Security.Claims;


namespace NetflixStream.WebAPIs.Controllers
{
    public class SubscriptionsController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(UserManager<User> userManager,
                                      RoleManager<IdentityRole> roleManager,
                                      UserManagementContext context, 
                                      ISubscriptionService subscriptionService,
                                      IMapper mapper
                                      )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
            _subscriptionService = subscriptionService;
        }


        [ValidateAntiForgeryToken]
        [HttpPost("AddSubscriptionPlan")]
        public async Task<ActionResult> AddSubscriptionPlan(SubscriptionPlanDtos subscription)
        {
            var subscriptionPlan = _mapper.Map<SubscriptionPlans>(subscription);

            _context.SubscriptionPlans.Add(subscriptionPlan);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return Ok();

            return BadRequest(new ApiResponse(400, "Failed to add the subscription plan."));
        }


        [HttpGet("GetAllSubscriptionPlan")]
        public async Task<ActionResult<IEnumerable<SubscriptionPlanDtos>>> GetAllSubscriptionPlan()
        {
            var Data = await _context.SubscriptionPlans.ToListAsync();

            var result = _mapper.Map<IEnumerable<SubscriptionPlanDtos>>(Data);

            return Ok(result);
        }


        [HttpDelete("DeleteSubscriptionPlan/{Id}")]
        public async Task<ActionResult<bool>> DeleteSubscriptionPlan(int Id)
        {
            var subscriptionPlan = await _context.SubscriptionPlans.FindAsync(Id);

            if (subscriptionPlan == null) return NotFound(new ApiResponse(404));

            _context.SubscriptionPlans.Remove(subscriptionPlan);

            int reult = await _context.SaveChangesAsync();

            return Ok(reult > 0);
        }


        [Authorize(Roles = "Admain")]
        [ValidateAntiForgeryToken]
        [HttpPut("UpdateSubscriptionPlan/{Id}")]
        public async Task<ActionResult<SubscriptionPlanDtos>> UpdateSubscriptionPlan(int Id, [FromBody] SubscriptionPlanDtos subscription)
        {
            var SubscriptionPlan = await _context.SubscriptionPlans.FindAsync(Id);

            if (SubscriptionPlan == null) return NotFound(new ApiResponse(400, $"Subscription plan with Id {Id} not found."));

            return Ok();
        }


        [Authorize]
        [HttpPost("CreateUserSubscription")]
        public async Task<ActionResult<SubscriptionResponseDto>> CreateSubscription(int SubscriptionPlansId)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(Email))
                return Unauthorized(new ApiResponse(401, "User email not found in the token."));

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return Unauthorized(new ApiResponse(401, "User not found with the provided email."));

            var subscription = await _subscriptionService.CreateSubscriptionAsync(user.Id, SubscriptionPlansId);
            if (subscription == null)
                return BadRequest(new ApiResponse(400, "Subscription could not be created."));

            var planName = await _subscriptionService.GetSubscriptionPlanNameAsync(SubscriptionPlansId);
            if (string.IsNullOrEmpty(planName))
                return NotFound(new ApiResponse(404, "Subscription plan not found."));

            var addRoleResult = await _subscriptionService.AddUserRoleAsync(user, planName);
            if (!addRoleResult.Succeeded)
            {
                return StatusCode(500, new ApiResponse(500, "Failed to assign user to the subscription role."));
            }

            return Ok(new SubscriptionResponseDto(user.UserName, planName));
        }


        [Authorize]
        [HttpPut("UpdateUserSubscription")]
        public async Task<ActionResult> UpdateSubscription(int SubscriptionPlansId)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(Email))
                return Unauthorized(new ApiResponse(401, "User email not found in the token."));

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return Unauthorized(new ApiResponse(401, "User not found with the provided email."));

            var subscription = await _subscriptionService.UpdateSubscriptionAsync(user.Id, SubscriptionPlansId);

            return Ok(new { message = "Subscription Update SuccessFuly " });
        }

        [Authorize]
        [HttpGet("GetUserSubscription")]
        public async Task<ActionResult<SubscriptionResponseDto>> GetUserSubscription()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(Email))
                return Unauthorized(new ApiResponse(401, "User email not found in the token."));

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return Unauthorized(new ApiResponse(401, "User not found with the provided email."));

            var userSubscription = await _subscriptionService.GetUserSubscriptionAsync(Email);

            if (userSubscription == null)
                return NotFound(new ApiResponse(404, "Subscription not found for this user."));

            return Ok(userSubscription);

        }

        [Authorize]
        [HttpDelete("DeleteUserSubscription")] 
        public async Task<ActionResult<bool>> DeleteUserSubscription()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(Email))
                return Unauthorized(new ApiResponse(401, "User email not found in the token."));

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
                return Unauthorized(new ApiResponse(401, "User not found with the provided email."));

            var subscriptionDeleted = await _subscriptionService.DeleteUserSubscriptionAsync(user.Id);

            if (!subscriptionDeleted) 
                return NotFound(new ApiResponse(404, "Subscription not found or already deleted."));

            return Ok(subscriptionDeleted);
        }


    }
}