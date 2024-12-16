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
    internal class MovieReviewsConfig : IEntityTypeConfiguration<MovieReviews>
    {
        public void Configure(EntityTypeBuilder<MovieReviews> entity)
        {
            entity.HasKey(M => M.ID);

            entity.Property(M => M.UserName).HasMaxLength(100).IsRequired();

            entity.Property(M => M.UserEmail).HasMaxLength(150).IsRequired();

            entity.Property(M => M.ReviewText).HasMaxLength(500).IsRequired();

            entity.HasOne(M => M.Movie).WithMany(M => M.MovieReviews).HasForeignKey(M => M.MovieID);
        }
    }
}
