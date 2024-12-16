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
    internal class MovieCommentsConfig : IEntityTypeConfiguration<MovieComments>
    {
        public void Configure(EntityTypeBuilder<MovieComments> entity)
        {
            entity.HasKey(M => M.ID);

            entity.Property(M => M.UserEmail).IsRequired();

            entity.Property(M => M.UserName).IsRequired();

            entity.Property(M => M.CommentText).IsRequired();

            entity.Property(M => M.CommentDate).IsRequired();

            entity.HasOne(E => E.Movie).WithMany(E => E.MovieComments).HasForeignKey(E => E.MovieID);
        }
    }
}
