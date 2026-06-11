using Microsoft.IdentityModel.Tokens;
using Registration_System.DTO;
using Registration_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Registration_System.Services
{
    public class JwtMethods
    {
        private readonly IConfiguration _conf;

        public JwtMethods(IConfiguration conf)
        {
            _conf = conf;
        }

        public string GenerateAccessToken(JwtDTO user)
        {
            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                issuer: _conf["Jwt:Issuer"],
                audience: _conf["Jwt:Audience"],
                claims: Claims,
                expires: DateTime.UtcNow.AddDays(Convert.ToInt32(_conf["Jwt:Expiry"])),
                signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        public string GenerateRefreshToken()
        {
            var Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            return Token;
        }
    }
}
