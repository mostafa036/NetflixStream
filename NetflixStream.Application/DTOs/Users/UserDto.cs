using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Users
{
    public record UserDto(

        string DisplayName,

        string Email,

        string Token
    );
}
