using NetflixStream.Application.DTOs;
using NetflixStream.Application.Interfaces;
using NetflixStream.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Persistence.Services
{
    public class UpdateDirector
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDirector(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


      



        }
    
}
