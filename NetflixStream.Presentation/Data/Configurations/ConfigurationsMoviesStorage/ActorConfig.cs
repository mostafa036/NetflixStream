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
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> entity)
        {
            entity.HasKey(A=>A.ID);

            entity.Property(A =>A.Nationality).HasMaxLength(60).IsRequired();

            entity.Property(A =>A.Biography).HasMaxLength(60).IsRequired();

            entity.Property(A =>A.PhotoPath).HasMaxLength(200).IsRequired();

            entity.Property(A =>A.FullName).HasMaxLength(100).IsRequired();

            entity.Property(A =>A.Gender).IsRequired();

            entity.HasMany(A => A.MovieActors).WithOne(A => A.Actor).HasForeignKey(A => A.ActorId);

            entity.HasMany(A => A.SeriesActors).WithOne(A => A.Actor).HasForeignKey(A => A.ActorId);

        }
    }
}
