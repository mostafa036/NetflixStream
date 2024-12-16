using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class EpisodePhoto : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public string? PosterPath { get; set; } = string.Empty;
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
    }
}
