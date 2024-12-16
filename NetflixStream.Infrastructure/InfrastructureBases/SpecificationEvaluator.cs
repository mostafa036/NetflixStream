﻿using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NetflixStream.Domain.Entities;
using NetflixStream.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NetflixStream.Infrastructure.InfrastructureBases
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> EntryQuery , ISpecifications<TEntity> specifications)
        {
            var Query = EntryQuery;

            // Applay Criteria
            if (specifications.Criteria != null) 
                Query = Query.Where(specifications.Criteria);

            // Apply ordering (OrderBy or OrderByDescending)
            if (specifications.OrderBy != null)
                Query = Query.OrderBy(specifications.OrderBy);
            else if (specifications.OrderByDescending != null)
                Query = Query.OrderByDescending(specifications.OrderByDescending);
          
            // Apply Includes
            Query = specifications.Includes.Aggregate(Query, (CurrentQuery, includesExpression) => CurrentQuery.Include(includesExpression));

            // Apply ThenIncludes
            Query = specifications.ThenIncludes.Aggregate(Query, (CurrentQuery, includesExpression) => includesExpression(CurrentQuery));

            // Apply pagination
            if (specifications.IsPagingEnabled)
                Query = Query.Skip(specifications.Skip).Take(specifications.Take);

            // Apply split query logic based on the number of includes/then-includes
            if ((specifications.Includes.Count() + specifications.ThenIncludes.Count) >= 4)
                Query = Query.AsSplitQuery();

            return Query;
        }
    }
}