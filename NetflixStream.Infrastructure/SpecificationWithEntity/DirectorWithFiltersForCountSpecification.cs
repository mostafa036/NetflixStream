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
    public class DirectorWithMoviesFiltersForCountSpecification : BaseSpecification<Director>
    {
        public DirectorWithMoviesFiltersForCountSpecification(DirectorFilterParams filterParams)
             : base(d =>
                  (string.IsNullOrEmpty(filterParams.Search) || d.Name.ToLower().Contains(filterParams.Search.ToLower()))
            )
        {
            
        }
    }
}
