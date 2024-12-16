using NetflixStream.Domain.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Users
{
    public class UserProfileDto
    {
        public string DisplayName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Country { get; set; }
        public AddressDto Address { get; set; }
        public UserSubscriptions? userSubscriptions { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
    }
}
