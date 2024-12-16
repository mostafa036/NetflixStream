using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.Interfaces
{
    public interface IDirectorRepository <T> where T : BaseEntity
    {
        Task<bool> UpdateDirectorAsync(int directorId, string entityType);
    }
}
