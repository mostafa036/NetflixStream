using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class Download : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string NikeName { get; set; } = string.Empty;
        public int? MovieId { get; set; } 
        public int? SeriesId { get; set; } 
        public DateTime DownloadDate { get; set; } 
        public Movies Movie { get; set; } = null!;
        public Series Series { get; set; } = null!;
    }
}
