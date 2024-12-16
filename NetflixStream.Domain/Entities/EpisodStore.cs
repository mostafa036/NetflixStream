

namespace NetflixStream.Domain.Entities
{
    public class EpisodStore : BaseEntity
    {
        public string? TrailerPath { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; } = null!;
    }
}
