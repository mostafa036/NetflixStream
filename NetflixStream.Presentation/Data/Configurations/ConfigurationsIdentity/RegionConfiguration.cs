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
    internal class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> Entity)
        {
            Entity.ToTable("Regions");

            Entity.HasKey(R => R.RegionId);

            Entity.Property(r => r.RegionName).IsRequired().HasMaxLength(55);

            Entity.HasMany(R => R.Devices).WithOne(R => R.Region).HasForeignKey(R => R.RegionId).OnDelete(DeleteBehavior.Restrict);

            Entity.HasMany(R => R.Countries).WithOne(R => R.Regions).HasForeignKey(R => R.RegionsId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
