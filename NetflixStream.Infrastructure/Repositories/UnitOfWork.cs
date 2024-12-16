using Microsoft.EntityFrameworkCore.Storage;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using NetflixStream.Persistence.Data.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NetflixStreamDbContext _context;
        private readonly Dictionary<Type, object> _repositories ;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        //private Hashtable _repositories; 


        public UnitOfWork(NetflixStreamDbContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositories =  new Dictionary<Type, object>(); 
        }

        // Repository Manager
        private TRepo Repository<TRepo, TRepoImpl>() where TRepoImpl : class, TRepo
        {
            var type = typeof(TRepo);
            if (!_repositories.ContainsKey(type))
            {
                var repository = Activator.CreateInstance(typeof(TRepoImpl), _context);
                _repositories[type] = repository;
            }

            return (TRepo)_repositories[type];
        }

        public async Task<int> Commit() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        
        public IBaseRepository<TEntity> baseRepository<TEntity>() where TEntity : BaseEntity
               => Repository<IBaseRepository<TEntity>, BaseRepository<TEntity>>();

        public ISpecificationRepository<TEntity> specificationRepository<TEntity>() where TEntity : BaseEntity
               => Repository<ISpecificationRepository<TEntity>, SpecificationRepository<TEntity>>();

        public IDirectorRepository<TEntity> directorRepository<TEntity>() where TEntity : BaseEntity
               => Repository<IDirectorRepository<TEntity>, DirectorRepository<TEntity>>();

        public IVideosRespositores<TEntity> VideosRespositores<TEntity>() where TEntity : BaseEntity
               => Repository<IVideosRespositores<TEntity>, VideosRespositores<TEntity>>();



        //// Video Repository
        //public IVideosRespositores<TEntity> Respositores<TEntity>() where TEntity : BaseEntity
        //    => GetOrAddRepository<IVideosRespositores<TEntity>, VideosRepository<TEntity>>();

        //// Base Repository
        //public IBaseRepository<TEntity> baseRepository<TEntity>() where TEntity : BaseEntity
        //    => GetOrAddRepository<IBaseRepository<TEntity>, BaseRepository<TEntity>>();


        //// Specification Repository
        //public ISpecificationRepository<TEntity> specificationRepository<TEntity>() where TEntity : BaseEntity
        //    => GetOrAddRepository<ISpecificationRepository<TEntity>, SpecificationRepository<TEntity>>();

        //// Director Repository
        //public IDirectorRepository<TEntity> directorRepository<TEntity>() where TEntity : BaseEntity
        //    => GetOrAddRepository<IDirectorRepository<TEntity>, DirectorRepository<TEntity>>();



        //public IVideosRespositores<TEntity> Respositores<TEntity>() where TEntity : BaseEntity, new()
        //{
        //    var typeName = typeof(TEntity).Name;

        //    if (!_repositories.ContainsKey(typeName))
        //    {
        //        var repositoryInstance = new VideosRespositores<TEntity>(_context);

        //        _repositories.Add(typeName, repositoryInstance);
        //    }

        //    return (IVideosRespositores<TEntity>)_repositories[typeName];
        //}


    }
}
