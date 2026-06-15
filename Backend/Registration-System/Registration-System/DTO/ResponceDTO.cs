using Registration_System.Models;

namespace Registration_System.DTO
{
    public class ResponseDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
