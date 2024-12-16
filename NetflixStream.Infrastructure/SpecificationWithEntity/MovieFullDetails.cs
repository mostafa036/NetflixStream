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
    public class MovieFullDetails : BaseSpecification<Movies>
    {
        public MovieFullDetails()
        {
            Includes.Add(G => G.Genres);
            Includes.Add(L => L.languages);
            Includes.Add(C => C.Countries);
            Includes.Add(A => A.MovieActors);
            Includes.Add(P => P.Producers);
            Includes.Add(D => D.Directors);

        }
        public MovieFullDetails(int id ) :base(b => b.ID == id)
        {
            Includes.Add(G => G.Genres);
            Includes.Add(L => L.languages);
            Includes.Add(C => C.Countries);
            Includes.Add(P => P.Producers);
            Includes.Add(D => D.Directors);
            ThenIncludes.Add(movies => movies.Include(m => m.MovieActors).ThenInclude(g => g.Actor));
        }
    }
}
