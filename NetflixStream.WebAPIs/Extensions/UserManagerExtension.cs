using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Domain.UserIdentity;
using System.Security.Claims;

namespace NetflixStream.WebAPIs.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<User> FindUserWithAddressExtension(this UserManager<User> userManager , ClaimsPrincipal User)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            var user = await userManager.Users.Include(U => U.Address).SingleOrDefaultAsync(U => U.Email == Email);

            return user;
        }
    }
}