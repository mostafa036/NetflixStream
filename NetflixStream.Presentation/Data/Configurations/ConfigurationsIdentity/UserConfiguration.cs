using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using NetflixStream.Domain.UserIdentity;


namespace NetflixStream.Persistence.Data.Configurations.ConfigurationsIdentity
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(u => u.Id);

            entity.HasMany(U => U.Devices).WithOne(U => U.User).HasForeignKey(U => U.UserId);

            entity.HasMany(U => U.Profiles).WithOne(U => U.User).HasForeignKey(U => U.UserId);

            entity.HasOne(U => U.Country).WithMany(U => U.User).HasForeignKey(U => U.CountryId).OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
