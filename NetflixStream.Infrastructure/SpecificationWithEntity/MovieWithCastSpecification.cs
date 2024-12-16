using Microsoft.EntityFrameworkCore;
using NetflixStream.Domain.Entities;
using NetflixStream.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.SpecificationWithEntity
{
    public class MovieWithCastSpecification : BaseSpecification<Movies>
    {
        public MovieWithCastSpecification(int movieId) : base(m => m.ID == movieId)
        {
            ThenIncludes.Add(movies => movies.Include(m => m.MovieActors).ThenInclude(g => g.Actor));
            Includes.Add(P => P.Producers);
            Includes.Add(D => D.Directors);
        }
    }
}
