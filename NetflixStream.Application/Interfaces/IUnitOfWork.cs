using Microsoft.EntityFrameworkCore.Storage;
using NetflixStream.Domain.Entities;

namespace NetflixStream.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVideosRespositores<TEntity> VideosRespositores<TEntity>() where TEntity : BaseEntity;
        IBaseRepository<TEntity> baseRepository<TEntity>() where TEntity : BaseEntity;
        ISpecificationRepository<TEntity> specificationRepository<TEntity>() where TEntity : BaseEntity;
        IDirectorRepository<TEntity> directorRepository<TEntity>() where TEntity : BaseEntity ;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> Commit();
    }
}
