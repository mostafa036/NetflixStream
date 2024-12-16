using NetflixStream.Application.Filters;
using NetflixStream.Domain.Entities;
using NetflixStream.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.SpecificationWithEntity
{
    public class TrendingMoviesSpecification : BaseSpecification<Movies>
    {
        //public TrendingMoviesSpecification(MovieFilterParams movieFilterParams)
        //    : base(m => m.MovieWatchingHistories
        //    .Any(w => w.StartWatching >= DateTime.Now.AddMonths(-6)) &&)
        //{
            
        //}
    }
}
