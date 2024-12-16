using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NetflixStream.Domain.Entities
{
    public class MoviePhoto : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
    }
}