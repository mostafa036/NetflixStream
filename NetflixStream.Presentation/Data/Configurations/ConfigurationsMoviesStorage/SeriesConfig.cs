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
    public class SeriesConfig : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> entity)
        {
            entity.HasKey(S => S.ID);

            entity.Property(s => s.Title).IsRequired();

            entity.Property(s => s.Description).IsRequired();

            entity.Property(s => s.AgeRating).IsRequired();

            entity.Property(m => m.AgeRating).HasMaxLength(10).IsRequired();

            entity.Property(m => m.Writer).HasMaxLength(200).IsRequired();

            entity.HasMany(m => m.Countries).WithMany(c => c.Series);

            entity.HasMany(m => m.languages).WithMany(c => c.Series);

            entity.HasMany(m => m.Genres).WithMany(c => c.Series);

            entity.HasMany(m => m.Directors).WithMany(c => c.Series);

            entity.HasMany(m => m.Producers).WithMany(c => c.Series);

            entity.HasMany(S => S.EpisodesList).WithOne(S => S.Series).HasForeignKey(S => S.SeriesId);

            entity.HasMany(S => S.SeriesActors).WithOne(S => S.Series).HasForeignKey(S => S.SeriesId);
        }
    }
}
