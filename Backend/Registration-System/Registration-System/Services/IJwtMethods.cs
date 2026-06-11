using Registration_System.DTO;

namespace Registration_System.Services
{
    public interface IJwtMethods
    {
        public string GenerateAccessToken(JwtDTO user);
        public string GenerateRefreshToken();
    }
}
