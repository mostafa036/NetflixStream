
namespace NetflixStream.Domain.Entities
{
    public class MovieWatchingHistory : BaseEntity
    {
        public string UserEmail { get; set; } = string.Empty;
        public int MovieID { get; set; }
        public Movies Movie { get; set; }  
        public DateTime StartWatching { get; set; }
        public DateTime? EndWatching { get; set; }
        public TimeSpan? LastWatchedPosition { get; set; }
        public int WatchCount { get; set; }
    }
}