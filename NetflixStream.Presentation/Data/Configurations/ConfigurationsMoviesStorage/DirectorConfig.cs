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
    public class DirectorConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> entity)
        {
            entity.HasKey(D=>D.ID);

            entity.Property(D => D.Name).HasMaxLength(100).IsRequired();

            entity.HasMany(D => D.Movies).WithMany(D => D.Directors);

            entity.HasMany(D => D.Series).WithMany(D => D.Directors);
        }
    }
}
