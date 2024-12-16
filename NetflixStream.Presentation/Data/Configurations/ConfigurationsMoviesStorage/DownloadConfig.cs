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
    public class DownloadConfig : IEntityTypeConfiguration<Download>
    {
        public void Configure(EntityTypeBuilder<Download> entity)
        {
            entity.HasKey(D => D.ID);

            entity.Property(d => d.DownloadDate).HasColumnType("timestamp").IsRequired();

            entity.HasOne(d => d.Movie).WithMany(m => m.Download).HasForeignKey(d => d.MovieId).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Series).WithMany(s => s.Downloads).HasForeignKey(d => d.SeriesId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
