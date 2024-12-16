using Microsoft.EntityFrameworkCore;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>  where T : BaseEntity
    {
        private readonly NetflixStreamDbContext _Context;

        public BaseRepository(NetflixStreamDbContext dbContext)
        {
            _Context = dbContext;
        }
        public async Task<T> AddAsync(T Video) {

            await _Context.Set<T>().AddAsync(Video);

            await _Context.SaveChangesAsync();

            return Video;
        }

        public async Task<bool> DeleteAsync(int id) {

            var entity = await _Context.Set<T>().FindAsync(id);

            if (entity == null) return false;

            _Context.Set<T>().Remove(entity);

            var changes = await _Context.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var existingEntity = await _Context.Set<T>().FindAsync(entity.ID);

            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with ID {entity.ID} not found.");

            _Context.Entry(existingEntity).CurrentValues.SetValues(entity);

            await _Context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _Context.Set<T>().FindAsync(id);

            if (result == null) throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");

            return result;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _Context.Set<T>().ToListAsync();

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> express)
        {
            var result =  await _Context.Set<T>().FirstOrDefaultAsync(express);

            if (result == null) throw new KeyNotFoundException($"Entity not found.");

            return result;
        }

        public IQueryable<T> Include(Expression<Func<T, object>> include) => _Context.Set<T>().Include(include);

    }
}
