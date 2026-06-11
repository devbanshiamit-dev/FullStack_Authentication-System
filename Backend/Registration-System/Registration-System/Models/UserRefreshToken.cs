namespace Registration_System.Models
{
    public class UserRefreshToken
    {
        public int Id { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; }

        public string DeviceName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public Users? User { get; set; }
    }
}
