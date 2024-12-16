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
    internal class MovieStoreConfig : IEntityTypeConfiguration<MovieStore>
    {
        public void Configure(EntityTypeBuilder<MovieStore> entity)
        {
            entity.HasKey(M => M.ID);

            entity.HasOne(M => M.Movies).WithOne(M => M.MovieStore).HasForeignKey<MovieStore>(M => M.MoviesId);
        }
    }
}
