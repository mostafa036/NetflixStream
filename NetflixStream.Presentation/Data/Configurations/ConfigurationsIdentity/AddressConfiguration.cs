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
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> Entity)
        {
            Entity.ToTable("Address");

            Entity.HasKey(A => A.AddressId);

            Entity.Property(x => x.Street).HasColumnType("varchar").HasMaxLength(100);

            Entity.Property(x => x.City).HasColumnType("varchar").HasMaxLength(50);

            Entity.Property(x => x.State).HasColumnType("varchar").HasMaxLength(50);

            Entity.Property(x => x.PostalCode).HasColumnType("varchar").HasMaxLength(12);

            Entity.Property(x => x.AddressType).HasColumnType("varchar").HasMaxLength(50);

            Entity.Property(x => x.IsPrimary).HasColumnType("varchar").HasMaxLength(10);

        }
    }
}
