
namespace NetflixStream.Domain.Entities
{
    public class Movies : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ReleaseDate { get; set; }
        public int CommentCount { get; set; }  
        public int WatchCount { get; set; }  
        public string AgeRating { get; set; } = string.Empty;
        public decimal IMDbRating { get; set; }
        public string Writer { get;  set; } = string.Empty;
        public string? PosterPath { get; set; } = string.Empty;
        public string? PosterName { get; set; } = string.Empty;
        public MovieStore MovieStore { get; set; } = null!;
        public ICollection<Download> Download { get; set; } = new HashSet<Download>();
        public  ICollection<Genre> Genres { get; set; }  = new HashSet<Genre>();
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
        public  ICollection<Language> languages { get; set; } = new HashSet<Language>();
        public  ICollection<MovieComments> MovieComments { get; set; } = new HashSet<MovieComments>();
        public  ICollection<Director> Directors { get; set; } = new HashSet<Director>();
        public  ICollection<Producer> Producers { get; set; } = new HashSet<Producer>();
        public  ICollection<MovieWatchingHistory> MovieWatchingHistories { get; set; } = new HashSet<MovieWatchingHistory>();
        public  ICollection<MovieActor> MovieActors { get; set; }  = new HashSet<MovieActor>();
        public  ICollection<MoviePhoto> moviePhotos { get; set; } = new HashSet<MoviePhoto>();
        public ICollection<MovieReviews> MovieReviews { get; set; } = new HashSet<MovieReviews>();

    }
}
