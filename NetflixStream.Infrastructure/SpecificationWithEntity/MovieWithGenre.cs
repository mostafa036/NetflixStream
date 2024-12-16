using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class MovieWithGenre : BaseSpecification<Movies>
    {
        public MovieWithGenre(MovieFilterParams filterParams)
            : base(m =>
                  (string.IsNullOrEmpty(filterParams.Search) || m.Title.ToLower().Contains(filterParams.Search.ToLower())) &&
                  (!filterParams.GenreId.HasValue || m.Genres.Any(g => g.ID == filterParams.GenreId))
            )
        {

        Includes.Add(M => M.Genres);

        ApplyPaging(filterParams.PageSize * (filterParams.PageIndex - 1), filterParams.PageSize);

        if (!string.IsNullOrEmpty(filterParams.Sort))
        {
            switch(filterParams.Sort)
            {
                case "NameAsc":
                    ApplyOrderBy(M => M.Title);
                    break;
                case "NameDesc":
                    ApplyOrderByDescending(M => M.Title);
                    break;
                default:
                    ApplyOrderBy(m => m.ID);
                    break;
            }
        }
        else{
            ApplyOrderBy(m => m.ID);
        }

        }

        public MovieWithGenre(int id ) : base (M =>M.ID == id)
        {
            Includes.Add(M => M.Genres);
        }
    }
}