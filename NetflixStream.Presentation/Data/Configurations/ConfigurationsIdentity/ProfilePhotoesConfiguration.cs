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
    internal class ProfilePhotoesConfiguration : IEntityTypeConfiguration<ProfilePhotoes>
    {
        public void Configure(EntityTypeBuilder<ProfilePhotoes> Entity)
        {
            Entity.ToTable("ProfilePhotoes");

            Entity.HasKey(P => P.PhotoId);

            // One-to-One relationship with UserProfile
            Entity.HasOne(pp => pp.UserProfile)
                   .WithOne(up => up.profilePhotoes)
                   .HasForeignKey<ProfilePhotoes>(pp => pp.UserProfileId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete
        }
    }
}
