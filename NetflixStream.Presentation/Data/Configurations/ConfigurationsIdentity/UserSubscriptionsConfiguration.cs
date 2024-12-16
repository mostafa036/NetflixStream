using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Data.Configurations.ConfigurationsIdentity
{
    internal class UserSubscriptionsConfiguration : IEntityTypeConfiguration<UserSubscriptions>
    {
        public void Configure(EntityTypeBuilder<UserSubscriptions> Entity)
        {
            Entity.ToTable("UserSubscriptions");

            Entity.HasKey(US => US.UserSubscriptionId);

            Entity.HasOne(US => US.User).WithOne(Us => Us.userSubscriptions).HasForeignKey<UserSubscriptions>(US => US.UserId);

            Entity.HasOne(US => US.SubscriptionPlans).WithMany(US => US.UserSubscriptions).HasForeignKey(US => US.SubscriptionPlansId);

            Entity.HasMany(US => US.Payments).WithOne(US => US.UserSubscription).HasForeignKey(FR => FR.UserSubscriptionId);
        }
    }
}
