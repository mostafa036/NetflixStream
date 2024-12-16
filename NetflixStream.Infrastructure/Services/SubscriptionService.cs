using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.DTOs.Subscriptiones;
using NetflixStream.Application.Interfaces;
using NetflixStream.Application.IServices;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Contexts;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly UserManager<User> _userManager;
        private readonly UserManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SubscriptionService(UserManager<User> userManager ,
                UserManagementContext context , 
                IUnitOfWork unitOfWork , 
                IMapper mapper , 
                RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
        }
       
        public async Task<UserSubscriptions?> CreateSubscriptionAsync(string UserId, int subscriptionPlanId)
        {

            var StartDate = DateTime.Now;

            var EndDate = DateTime.Now.AddDays(30);

            var UserSubscription = new UserSubscriptions()
            {
                UserId = UserId,
                StartDate = StartDate,
                EndDate = EndDate,
                SubscriptionPlansId = subscriptionPlanId
            };

            await _context.AddAsync(UserSubscription);

            await _context.SaveChangesAsync();

            return UserSubscription;
        }

        public async Task<bool> CancelSubscriptionAsync(string UserId)
        {
            var userSubscription = await _context.UserSubscriptions.FirstOrDefaultAsync(x => x.UserId == UserId && x.EndDate > DateTime.Now);

            if (userSubscription == null)  return false;

            userSubscription.EndDate = DateTime.Now; // Subscription ends immediately

            userSubscription.Status = "Pinding";

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserSubscriptionsDto?> GetUserSubscriptionAsync(string Email)
        {
             var user = await _userManager.FindByEmailAsync(Email);

            if (user == null) return null;

            var userSubscription = await _context.UserSubscriptions.Include(x => x.SubscriptionPlans)
                .FirstOrDefaultAsync(us => us.UserId == user.Id);

            var subscriptionDto = _mapper.Map<UserSubscriptionsDto>(userSubscription);

            return subscriptionDto;
        }

        public async Task<UserSubscriptions?> UpdateSubscriptionAsync(string UserId, int newSubscriptionPlanId)
        {
             var  user  =  await _userManager.FindByIdAsync(UserId);
             if (user == null) return null;

            var userSubscription = await _context.UserSubscriptions.FirstOrDefaultAsync(us => us.UserId == UserId);
            if (userSubscription == null) return null;

            var renewDate = DateTime.Now;

            userSubscription.StartDate = renewDate;
            userSubscription.EndDate = renewDate.AddDays(30);
            userSubscription.SubscriptionPlansId = newSubscriptionPlanId;

            _context.UserSubscriptions.Update(userSubscription);
            await _context.SaveChangesAsync();

            return userSubscription;
        }

        public async Task<bool> DeleteUserSubscriptionAsync(string UserId)
        {
            var userSubscription = await _context.UserSubscriptions.FirstOrDefaultAsync(us => us.UserId == UserId);

            if (userSubscription == null) return false;

            _context.UserSubscriptions.Remove(userSubscription);

            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null) return false;

            var planName = await GetSubscriptionPlanNameAsync(userSubscription.SubscriptionPlansId);

            if (!string.IsNullOrEmpty(planName))
            {
                var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, planName);

                if (!removeRoleResult.Succeeded)
                {
                    var errors = string.Join(", ", removeRoleResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to remove role '{planName}' from user. Errors: {errors}");
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string?> GetSubscriptionPlanNameAsync(int subscriptionPlansId)
        {
            var planName = await _context.SubscriptionPlans
             .Where(s => s.SubscriptionPlansId == subscriptionPlansId)
             .Select(s => s.PlanName)
             .FirstOrDefaultAsync();

            return planName;
        }

        public async Task<IdentityResult> AddUserRoleAsync(User user, string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                throw new InvalidOperationException($"Role '{roleName}' does not exist.");
            }

            var userHasRole = await _userManager.IsInRoleAsync(user, roleName);
            if (userHasRole)
            {
                return IdentityResult.Success; 
            }

            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<bool> UpdateUserSubscriptionStatusAsync(string userId, string newStatus)
        {
            var userSubscription = await _context.UserSubscriptions.FirstOrDefaultAsync(us => us.UserId == userId);

            if (userSubscription == null)
            {
                throw new InvalidOperationException("User subscription not found.");
            }

            userSubscription.Status = newStatus;

            userSubscription.StartDate = DateTime.UtcNow;

            _context.UserSubscriptions.Update(userSubscription);

            await _context.SaveChangesAsync();

            return true;
        }



    }
}
