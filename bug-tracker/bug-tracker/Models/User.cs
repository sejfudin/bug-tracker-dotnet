using Microsoft.AspNetCore.Identity;

namespace bug_tracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public UserRole role { get; set; }
        public List<User>? Users { get; set; }
    }
}
