using Registration_System.DTO;
using Registration_System.Models;
using System.Security.Claims;

namespace Registration_System.Services
{
    public interface IJwtMethods
    {
        public string GenerateAccessToken(Users user);
        public UserRefreshToken GenerateRefreshToken(Users user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
