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
    internal class EpisodStoreConfig : IEntityTypeConfiguration<EpisodStore>
    {
        public void Configure(EntityTypeBuilder<EpisodStore> entity)
        {
            entity.HasKey(E =>E.ID);

            entity.Property(E => E.FilePath).IsRequired(); 

            entity.Property(E => E.TrailerPath).IsRequired();

            entity.HasOne(E => E.Episode).WithOne(E => E.EpisodStore).HasForeignKey<EpisodStore>(E => E.EpisodeId);
        }
    }
}
