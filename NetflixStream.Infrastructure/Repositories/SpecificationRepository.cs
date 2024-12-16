using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Domain.Specifications;
using NetflixStream.Infrastructure.InfrastructureBases;
using NetflixStream.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Repositories
{
    public class SpecificationRepository<T> : ISpecificationRepository<T> where T : BaseEntity
    {
        private readonly NetflixStreamDbContext _Context;

        public SpecificationRepository(NetflixStreamDbContext dbContext)
        {
            _Context = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
            => await ApplaySpecification(spec).ToListAsync();

        public async Task<T> GetEntityWithSpecAsync(ISpecifications<T> spec)
             => await ApplaySpecification(spec).FirstOrDefaultAsync();

        public IQueryable<T> ApplaySpecification(ISpecifications<T> specifications)
             => SpecificationEvaluator<T>.GetQuery(_Context.Set<T>(), specifications);

        public async Task<int> GetCountAsync(ISpecifications<T> spec)
                => await ApplaySpecification(spec).CountAsync();
    }
}