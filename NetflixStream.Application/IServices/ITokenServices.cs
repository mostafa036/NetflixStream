using Microsoft.AspNetCore.Identity;
using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.IServices
{
    public interface ITokenServices
    {
         Task<string> CreateToken(User user , UserManager<User> userManager);

    }
}
