using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Data.Configurations.ConfigurationsIdentity;


namespace NetflixStream.Persistence.Data.Contexts
{
    public class UserManagementContext : IdentityDbContext<User>
    {

        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ProfilePhotoes> ProfilePhotos { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubscriptionPlans> SubscriptionPlans { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserSubscriptions> UserSubscriptions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new DeviceConfiguration());
            builder.ApplyConfiguration(new ProfilePhotoesConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new SubscriptionPlansConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserProfilesConfiguration());
            builder.ApplyConfiguration(new UserSubscriptionsConfiguration());
            builder.ApplyConfiguration(new PaymentsConfig());
            builder.ApplyConfiguration(new PaymentMethodConfig());
        }
    }
}
