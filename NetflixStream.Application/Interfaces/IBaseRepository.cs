using NetflixStream.Domain.Entities;
using System.Linq.Expressions;

namespace NetflixStream.Application.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> AddAsync(T entity);
        IQueryable<T> Include(Expression<Func<T, object>> include);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
