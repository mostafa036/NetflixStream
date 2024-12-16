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
    internal class SubscriptionPlansConfiguration : IEntityTypeConfiguration<SubscriptionPlans>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlans> Entity)
        {
            Entity.ToTable("SubscriptionPlans");

            Entity.HasKey(SP => SP.SubscriptionPlansId);

            Entity.Property(SP => SP.Price).HasColumnType("decimal(18,2)");

            Entity.HasMany(SP => SP.UserSubscriptions).WithOne(SP => SP.SubscriptionPlans).HasForeignKey(SP => SP.SubscriptionPlansId);
        }
    }
}
