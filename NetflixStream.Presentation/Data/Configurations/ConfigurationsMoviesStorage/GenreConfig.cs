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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity.HasKey(g => g.ID);

            entity.Property(G => G.Name).HasMaxLength(50).IsRequired();

            entity.HasMany(G => G.Movies).WithMany(G => G.Genres);

            entity.HasMany(G => G.Series).WithMany(G => G.Genres);
        }
    }
}
