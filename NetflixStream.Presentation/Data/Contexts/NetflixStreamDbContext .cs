using Microsoft.EntityFrameworkCore;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Data.Configurations.ConfigurationsMoviesStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Data.Contexts
{
    public class NetflixStreamDbContext : DbContext
    {
        public NetflixStreamDbContext(DbContextOptions<NetflixStreamDbContext> options): base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeComments> EpisodeComments { get; set; }
        public DbSet<EpisodePhoto> EpisodePhotos { get; set; }
        public DbSet<EpisodeWatchingHistory> EpisodeWatchingHistories { get; set; }
        public DbSet<EpisodStore> EpisodStores { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieComments> MovieComments{ get; set; }
        public DbSet<MoviePhoto> MoviePhotos { get; set; }
        public DbSet<MovieReviews> MovieReviews { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieStore> MovieStores { get; set; }
        public DbSet<MovieWatchingHistory> MovieWatchingHistories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<SeriesActor> SeriesActors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Apply configurations for entitie

            modelBuilder.ApplyConfiguration(new ActorConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new DirectorConfig());
            modelBuilder.ApplyConfiguration(new EpisodeCommentsConfig());
            modelBuilder.ApplyConfiguration(new EpisodePhotoConfig());
            modelBuilder.ApplyConfiguration(new EpisodeWatchingHistoryConfig());
            modelBuilder.ApplyConfiguration(new EpisodStoreConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new EpisodeConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new MovieActorConfig());
            modelBuilder.ApplyConfiguration(new MovieCommentsConfig());
            modelBuilder.ApplyConfiguration(new MoviePhotoConfig());
            modelBuilder.ApplyConfiguration(new MovieReviewsConfig());
            modelBuilder.ApplyConfiguration(new MoviesConfig());
            modelBuilder.ApplyConfiguration(new DownloadConfig());



            modelBuilder.ApplyConfiguration(new MovieStoreConfig());
            modelBuilder.ApplyConfiguration(new MovieWatchingHistoryConfig());
            modelBuilder.ApplyConfiguration(new ProducerConfig());

            modelBuilder.ApplyConfiguration(new SeriesConfig());
            modelBuilder.ApplyConfiguration(new SeriesActorConfig());
        }

    }
}
