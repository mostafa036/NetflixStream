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
    internal class EpisodeCommentsConfig : IEntityTypeConfiguration<EpisodeComments>
    {
        public void Configure(EntityTypeBuilder<EpisodeComments> entity)
        {
            entity.HasKey(E => E.ID);

            entity.Property(E => E.UserEmail).HasMaxLength(500).IsRequired();

            entity.Property(E => E.UserName).HasMaxLength(500).IsRequired();

            entity.Property(E => E.CommentText).HasMaxLength(500).IsRequired();

            entity.HasOne(E => E.Episode).WithMany(E => E.EpisodeComments).HasForeignKey(E => E.EpisodeID);
        }
    }
}
