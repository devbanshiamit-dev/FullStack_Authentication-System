using Registration_System.DTO;
using Registration_System.Models;
using Registration_System.PasswordSecurity;
using Registration_System.Repo;

namespace Registration_System.Services
{
    public class AuthenticationSer : IAuthenticationSer
    {
        private readonly IJwtMethods _jwtMethods;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<AuthenticationSer> _logger;

        public AuthenticationSer(IJwtMethods jwtMethods, IAuthRepository authRepository,
            ILogger<AuthenticationSer> logger)
        {
            _jwtMethods = jwtMethods;
            _authRepository = authRepository;
            _logger = logger;
        }

        public async Task<ResponceDTO?> RegisterAsync(RequestDTO Dto)
        {
            var exist = await _authRepository.GetUserByEmailAsync(Dto.Email);
            if (exist != null)
            {
                _logger.LogWarning("Email Already Exist");
                return null;
            }

            _logger.LogInformation("Creating Account");

            var user = new Users
            {
                UserName = Dto.UserName,
                Email = Dto.Email,
                Password = PasswordHasher.HashPassword(Dto.Password),
                PhoneNumber = Dto.PhoneNumber,
                AccountCreatedAt = DateTime.UtcNow
            };

            var AddedUser = await _authRepository.AddUserAsync(user);

            _logger.LogInformation(
               "Account created successfully for {Email}",
               user.Email);

            return await GetAllTokensAsync(AddedUser);
        }


        // Internal services
        private async Task<ResponceDTO> GetAllTokensAsync(Users user)
        {
            var Access = _jwtMethods.GenerateAccessToken(user);
            var RF = _jwtMethods.GenerateRefreshToken(user);

            await _authRepository.AddRefreshTokenAsync(RF);

            return new ResponceDTO
            {
                AcceccToken = Access,
                RefreshToken = RF.RefreshToken,
            };
        }
    }
}
