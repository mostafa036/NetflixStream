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
    internal class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> entity)
        {

            entity.HasKey(ma => new { ma.MovieId, ma.ActorId });

            entity.Property(ma => ma.CharacterName).IsRequired().HasMaxLength(100);

            entity.HasOne(ma => ma.Movie).WithMany(m => m.MovieActors).HasForeignKey(ma => ma.MovieId);

            entity.HasOne(ma => ma.Actor).WithMany(a => a.MovieActors).HasForeignKey(ma => ma.ActorId);
        }
    }
}
