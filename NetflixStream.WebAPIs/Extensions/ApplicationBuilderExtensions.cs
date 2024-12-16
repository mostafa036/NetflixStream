using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Contexts;
using NetflixStream.Persistence.Data.DataSeeding;

namespace NetflixStream.WebAPIs.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task ApplyMigrationsAndSeedDataAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var scopedServices = scope.ServiceProvider;

            var logger = scopedServices.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();

            try
            {
                // Migrate UserManagementContext
                var contextUser = scopedServices.GetRequiredService<UserManagementContext>();
                await contextUser.Database.MigrateAsync();

                // Migrate NetflixStreamDbContext
                var contextMovie = scopedServices.GetRequiredService<NetflixStreamDbContext>();
                await contextMovie.Database.MigrateAsync();

                // Seed User data
                var userManager = scopedServices.GetRequiredService<UserManager<User>>();
                await UserIdentityDbContextSeed.SeedAsync(userManager);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during migration and data seeding.");
            }
        }
    }
}