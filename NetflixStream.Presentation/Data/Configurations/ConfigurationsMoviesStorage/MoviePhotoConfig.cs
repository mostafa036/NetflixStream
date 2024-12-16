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
    public class MoviePhotoConfig : IEntityTypeConfiguration<MoviePhoto>
    {
        public void Configure(EntityTypeBuilder<MoviePhoto> entity)
        {
            entity.HasKey(P=>P.ID);

            entity.Property(P => P.Url).IsRequired();

            entity.HasOne(p => p.Movie).WithMany(m => m.moviePhotos).HasForeignKey(p => p.MovieId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
