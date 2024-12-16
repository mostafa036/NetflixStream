using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class Episode : BaseEntity
    {
        public int SeriesId { get; set; }
        public int? SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Description { get; private set; } = string.Empty;
        public string FilePath { get;  set; } = string.Empty;
        public DateOnly AirDate { get; set; }
        public int CommentCount { get; set; }
        public int WatchCount { get; set; }
        public Series Series { get; set; } = null!;
        public EpisodStore EpisodStore { get; set; } = null!;
        public ICollection<EpisodePhoto> EpisodePhoto { get; set;} = new HashSet<EpisodePhoto>();
        public ICollection<EpisodeComments> EpisodeComments { get; set;} = new HashSet<EpisodeComments>();
        public ICollection<EpisodeWatchingHistory> EpisodeWatchingHistories { get; set;} = new HashSet<EpisodeWatchingHistory>();
    }
}
