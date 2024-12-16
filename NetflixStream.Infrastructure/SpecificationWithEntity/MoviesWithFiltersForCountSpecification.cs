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
    public class MoviesWithFiltersForCountSpecification : BaseSpecification<Movies>
    {
    public MoviesWithFiltersForCountSpecification(MovieFilterParams filterParams)
        : base(m =>
            (string.IsNullOrEmpty(filterParams.Search) || m.Title.ToLower().Contains(filterParams.Search.ToLower())) &&
            (!filterParams.GenreId.HasValue || m.Genres.Any(g => g.ID == filterParams.GenreId))
        )
    {
    }


    }
}
