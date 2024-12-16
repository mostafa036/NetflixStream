using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class Series : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Seasons { get; set; }
        public int Episodes { get; set; }
        public int WatchCount { get; set; } 
        public DateOnly FirstAired { get; set; }
        public DateOnly LastAired { get; set; }
        public string AgeRating { get; private set; } = string.Empty;
        public string Writer { get; set; } = string.Empty;
        public decimal IMDbRating { get; set; }
        public ICollection<Download> Downloads { get; set; } = new HashSet<Download>();
        public ICollection<Language> languages { get; set; } = new HashSet<Language>();
        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
        public ICollection<Country> Countries { get; set; }  = new HashSet<Country>();
        public ICollection<Episode> EpisodesList { get; set; } = new HashSet<Episode>();
        public ICollection<Producer> Producers { get; set; } = new HashSet<Producer>();
        public ICollection<Director> Directors { get; set; } = new HashSet<Director>();
        public ICollection<SeriesActor> SeriesActors { get; set; }
    }
}
