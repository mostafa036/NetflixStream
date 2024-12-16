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
    internal class MovieWatchingHistoryConfig : IEntityTypeConfiguration<MovieWatchingHistory>
    {
        public void Configure(EntityTypeBuilder<MovieWatchingHistory> entity)
        {
            entity.HasKey(M => M.ID);

            entity.HasOne(M => M.Movie).WithMany(M => M.MovieWatchingHistories).HasForeignKey(M => M.MovieID);
        }
    }
}
