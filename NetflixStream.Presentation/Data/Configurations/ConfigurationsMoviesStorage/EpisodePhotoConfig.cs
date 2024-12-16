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
    internal class EpisodePhotoConfig : IEntityTypeConfiguration<EpisodePhoto>
    {
        public void Configure(EntityTypeBuilder<EpisodePhoto> entity)
        {
            entity.HasKey(E => E.ID);

            entity.Property(E => E.Url).IsRequired();

            entity.Property(E => E.PosterPath).IsRequired();

            entity.HasOne(E =>E.Episode).WithMany(E =>E.EpisodePhoto).HasForeignKey(E => E.EpisodeId);

        }
    }
}
