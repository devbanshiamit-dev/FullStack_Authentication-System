using Registration_System.Models;

namespace Registration_System.DTO
{
    public class ResponceDTO
    {
        public string AcceccToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
