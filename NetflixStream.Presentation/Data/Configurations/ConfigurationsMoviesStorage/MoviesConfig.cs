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
    public class MoviesConfig : IEntityTypeConfiguration<Movies>
    {
        
            public void Configure(EntityTypeBuilder<Movies> entity)
            {
                // Primary Key
                entity.HasKey(m => m.ID);

                // Properties
                entity.Property(m => m.Title).HasMaxLength(50).IsRequired();
                entity.Property(m => m.Description).HasMaxLength(500).IsRequired();
                entity.Property(m => m.Duration).IsRequired();
                entity.Property(m => m.ReleaseDate).IsRequired();
                entity.Property(m => m.CommentCount).IsRequired();
                entity.Property(m => m.WatchCount).IsRequired();
                entity.Property(m => m.AgeRating).HasMaxLength(10).IsRequired();
                entity.Property(m => m.IMDbRating).HasColumnType("decimal(3,1)");
                entity.Property(m => m.Writer).HasMaxLength(200).IsRequired();
                entity.Property(m => m.PosterPath).HasMaxLength(200).IsRequired(false);

                // Relationships
                entity.HasOne(m => m.MovieStore).WithOne(ms => ms.Movies).HasForeignKey<MovieStore>(ms => ms.MoviesId).OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(m => m.MovieActors).WithOne(ma => ma.Movie).HasForeignKey(ma => ma.MovieId);

                entity.HasMany(m => m.MovieComments).WithOne(mc => mc.Movie).HasForeignKey(mc => mc.MovieID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(m => m.MovieWatchingHistories).WithOne(mwh => mwh.Movie).HasForeignKey(mwh => mwh.MovieID);

                entity.HasMany(m => m.moviePhotos).WithOne(mp => mp.Movie).HasForeignKey(mp => mp.MovieId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasMany(m => m.MovieReviews)
                    .WithOne(mr => mr.Movie)
                    .HasForeignKey(mr => mr.MovieID);

                entity.HasMany(m => m.Genres).WithMany(g => g.Movies);

                entity.HasMany(m => m.Countries).WithMany(c => c.Movies);

                entity.HasMany(m => m.languages).WithMany(l => l.Movies);

                entity.HasMany(m => m.Directors).WithMany(d => d.Movies);

                entity.HasMany(m => m.Producers).WithMany(p => p.Movies);
            }
        }
    }

