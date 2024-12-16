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
    public class EpisodeConfig : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> entity)
        {
            entity.HasKey(E => E.ID);

            entity.Property(E => E.Description).HasMaxLength(500).IsRequired();

            entity.Property(E => E.FilePath).HasMaxLength(500).IsRequired();

            entity.Property(E => E.AirDate).IsRequired();

            entity.HasMany(E => E.EpisodePhoto).WithOne(E =>E.Episode).HasForeignKey(E => E.EpisodeId);

            entity.HasMany(E => E.EpisodeComments).WithOne(E => E.Episode).HasForeignKey(E => E.ID);

            entity.HasOne(E => E.Series).WithMany(E => E.EpisodesList).HasForeignKey(E => E.ID);

            entity.HasOne(E => E.EpisodStore).WithOne(E => E.Episode).HasForeignKey<EpisodStore>(E => E.EpisodeId);
        }
    }
}
