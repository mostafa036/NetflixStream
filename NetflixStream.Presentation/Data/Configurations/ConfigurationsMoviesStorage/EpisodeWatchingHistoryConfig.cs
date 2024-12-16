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
    internal class EpisodeWatchingHistoryConfig : IEntityTypeConfiguration<EpisodeWatchingHistory>
    {
        public void Configure(EntityTypeBuilder<EpisodeWatchingHistory> entity)
        {
            entity.HasKey(M => M.ID);

            entity.Property(M => M.UserEmail).IsRequired();

            entity.HasOne(S => S.Episode).WithMany(S => S.EpisodeWatchingHistories).HasForeignKey(S => S.EpisodeID);
        }
    }
}
