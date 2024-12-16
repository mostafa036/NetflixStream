
namespace NetflixStream.Domain.Entities
{
    public class EpisodeWatchingHistory : BaseEntity
    {
        public string UserEmail { get; set; } = string.Empty;
        public int SeriesID { get; set; }
        public Series Series { get; set; } = null!;
        public int? EpisodeID { get; set; }  
        public Episode Episode { get; set; } = null!;
        public DateTime StartWatching { get; set; }
        public DateTime? EndWatching { get; set; }
        public TimeSpan? LastWatchedPosition { get; set; }
        public int WatchCount { get; set; }
    }
}
