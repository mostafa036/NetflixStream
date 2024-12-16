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
    public class DirectorWithMoviesAndSeriesSpecification : BaseSpecification<Director>
    {
        public DirectorWithMoviesAndSeriesSpecification(DirectorFilterParams filterParams)
            : base(d =>
                  (string.IsNullOrEmpty(filterParams.Search) || d.Name.ToLower().Contains(filterParams.Search.ToLower()))
            )
        {

            Includes.Add(D => D.Movies);
            Includes.Add(D => D.Series);

            ApplyPaging(filterParams.PageSize * (filterParams.PageIndex - 1), filterParams.PageSize);


            if (!string.IsNullOrEmpty(filterParams.Sort))
            {
                switch (filterParams.Sort)
                {
                    case "NameAsc":
                        ApplyOrderBy(M => M.Name);
                        break;
                    case "NameDesc":
                        ApplyOrderByDescending(M => M.Name);
                        break;
                    default:
                        ApplyOrderBy(m => m.ID);
                        break;
                }
            }
            else
            {
                ApplyOrderBy(m => m.ID);
            }
        }

        public DirectorWithMoviesAndSeriesSpecification(int id) : base(D => D.ID == id)
        {
            Includes.Add(D => D.Movies);
            Includes.Add(D => D.Series);
        }
    }
}
