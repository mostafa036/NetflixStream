using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.Filters
{
    public class MovieFilterParams
    {
        public string? Sort { get; set; }
        public int? GenreId { get; set; }
        public int? Year { get; set; }
        public string? Language { get; set; }
        public string? Search { get; set; }


        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

    }
}
