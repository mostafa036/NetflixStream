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
    internal class UserProfilesConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> Entity)
        {
            Entity.ToTable("UserProfiles");

            Entity.HasKey(UP => UP.UserProfileId);

            Entity.Property(UP => UP.Nickname)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Entity.Property(UP => UP.Languages)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Entity.HasOne(R => R.User)
                .WithMany(R => R.Profiles)
                .HasForeignKey(R => R.UserId);

            Entity.HasOne(up => up.profilePhotoes)
            .WithOne(pp => pp.UserProfile)
              .HasForeignKey<ProfilePhotoes>(pp => pp.UserProfileId)
              .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete
        }
    }
}
