using Microsoft.AspNetCore.Identity;

namespace NetflixStream.Domain.UserIdentity
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public Address Address { get; set; } = null!;
        public UserSubscriptions? userSubscriptions { get; set; }
        public ICollection<UserProfile> Profiles { get; set; } = null!;
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<Device> Devices { get; set; } = new HashSet<Device>();
    }

}
