using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Users
{
    public record LoginDto(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        string Password
    );
}
