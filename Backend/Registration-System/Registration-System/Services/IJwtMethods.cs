using Registration_System.DTO;
using Registration_System.Models;

namespace Registration_System.Services
{
    public interface IJwtMethods
    {
        public string GenerateAccessToken(Users user);
        public UserRefreshToken GenerateRefreshToken(Users user);
    }
}
