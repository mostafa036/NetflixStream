using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.Entities
{
    public class EpisodeComments : BaseEntity
    {
        public string UserEmail { get; set; } = string.Empty; 
        public string UserName { get; set; } = string.Empty;
        public int EpisodeID { get; set; }
        public Episode? Episode { get; set; }  
        public string CommentText { get; set; }= string.Empty;
        public DateTime CommentDate { get; set; }
    }
}
