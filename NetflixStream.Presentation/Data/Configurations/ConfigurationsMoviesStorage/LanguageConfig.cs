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
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.HasKey(L => L.ID);

            entity.Property(L => L.Name).IsRequired().HasMaxLength(50);

            entity.HasMany(L => L.Movies).WithMany(L => L.languages);

            entity.HasMany(L => L.Series).WithMany(L => L.languages);
        }
    }
}
