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
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> Entity)
        {
            Entity.ToTable("Countries");

            Entity.HasKey(c => c.CountryId);

            Entity.Property(C => C.CountryName)
                .HasColumnType("varchar")
                .HasMaxLength(29)
                .IsRequired();

            Entity.HasOne(C => C.Regions)
                .WithMany(C => C.Countries)
                .HasForeignKey(C => C.RegionsId);

            Entity.HasMany(C => C.User)
                .WithOne(C => C.Country)
                .HasForeignKey(C => C.CountryId);

        }
    }
}
