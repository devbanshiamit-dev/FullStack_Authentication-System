using System.Diagnostics.CodeAnalysis;

namespace Registration_System.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public DateTime AccountCreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserRefreshToken> RefreshTokens { get; set; }
        = new List<UserRefreshToken>();
    }
}
