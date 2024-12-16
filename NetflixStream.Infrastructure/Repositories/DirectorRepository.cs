using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Infrastructure.Repositories
{
    public class DirectorRepository<T> : IDirectorRepository<T> where T : BaseEntity
    {
        public Task<bool> UpdateDirectorAsync(int directorId, string entityType)
        {
            throw new NotImplementedException();
        }
    }
}
