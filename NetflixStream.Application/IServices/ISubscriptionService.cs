using Microsoft.AspNetCore.Identity;
using NetflixStream.Application.DTOs.Subscriptiones;
using NetflixStream.Domain.UserIdentity;


namespace NetflixStream.Application.IServices
{
    public interface ISubscriptionService
    {
        Task<UserSubscriptionsDto?> GetUserSubscriptionAsync(string Email);
        Task<UserSubscriptions?> CreateSubscriptionAsync(string UserId, int subscriptionPlanId);
        Task<UserSubscriptions?> UpdateSubscriptionAsync(string UserIdint , int SubscriptionPlanId);
        Task<bool> CancelSubscriptionAsync(string UserId);
        Task<bool> DeleteUserSubscriptionAsync(string UserId);
        Task<string?> GetSubscriptionPlanNameAsync(int subscriptionPlansId);
        Task<IdentityResult> AddUserRoleAsync(User user, string roleName);
        Task<bool> UpdateUserSubscriptionStatusAsync(string userId, string newStatus);

    }
}
