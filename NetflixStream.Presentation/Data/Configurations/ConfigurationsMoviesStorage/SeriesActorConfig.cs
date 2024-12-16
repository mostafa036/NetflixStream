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
    public class SeriesActorConfig : IEntityTypeConfiguration<SeriesActor>
    {
        public void Configure(EntityTypeBuilder<SeriesActor> entity)
        {
            
            entity.HasKey(sa => new { sa.SeriesId, sa.ActorId });

            entity.Property(P => P.CharacterName).HasMaxLength(100).IsRequired();

            // Configure relationships
            entity.HasOne(sa => sa.Series).WithMany(s => s.SeriesActors).HasForeignKey(sa => sa.SeriesId);

            entity.HasOne(sa => sa.Actor).WithMany(a => a.SeriesActors).HasForeignKey(sa => sa.ActorId);
        }
    }
}

