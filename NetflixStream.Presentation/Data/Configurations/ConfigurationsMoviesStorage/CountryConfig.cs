using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Data.Configurations.ConfigurationsMoviesStorage
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
           entity.HasKey(x => x.ID);

            entity.Property(x => x.Name).IsRequired();

            entity.HasMany(c => c.Movies).WithMany(m => m.Countries);

            entity.HasMany(c => c.Series).WithMany(s => s.Countries);
        }
    }
}
