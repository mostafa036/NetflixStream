using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Users
{
    public record RegisterDto(
    [Required]
    string DisplayName,
    [Required]
    int CountryId,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [Phone]
    string PhoneNumber,
    [Required]
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d@$!%*?&]{8,}$",
    ErrorMessage = "Password must be at least 8 characters long, include one uppercase letter, one lowercase letter, one digit, and may contain special characters.")]
    string Password
    );

}
