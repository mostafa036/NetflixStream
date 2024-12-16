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
    internal class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> Entity)
        {
            Entity.ToTable("Devices");

            Entity.HasKey(D => D.DeviceId);


            Entity.Property(D => D.DeviceName)
                .IsRequired(true);


            Entity.HasOne(D => D.Region).WithMany(D => D.Devices).HasForeignKey(D => D.RegionId);

            Entity.HasOne(D => D.User).WithMany(D => D.Devices).HasForeignKey(D => D.UserId);


        }
    }
}
