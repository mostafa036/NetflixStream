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
    public class ProducerConfig : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity.HasKey(P => P.ID);

            entity.Property(P=>P.Name).HasMaxLength(100).IsRequired();

            entity.HasMany(P => P.Movies).WithMany(P => P.Producers);

            entity.HasMany(P => P.Series).WithMany(P => P.Producers);
        }
    }
}
