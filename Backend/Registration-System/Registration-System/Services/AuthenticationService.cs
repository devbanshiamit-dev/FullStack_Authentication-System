using Registration_System.DTO;
using Registration_System.Exceptions;
using Registration_System.Models;
using Registration_System.PasswordSecurity;
using Registration_System.Repo;

namespace Registration_System.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtMethods _jwtMethods;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IJwtMethods jwtMethods, IAuthRepository authRepository,
            ILogger<AuthenticationService> logger)
        {
            _jwtMethods = jwtMethods;
            _authRepository = authRepository;
            _logger = logger;
        }


        // NewUser
        public async Task<ResponseDTO> RegisterAsync(RequestDTO Dto)
        {
            var exist = await _authRepository.GetUserByEmailAsync(Dto.Email);
            if (exist != null)
            {
                _logger.LogWarning(
                 "Registration failed. Email {Email} already exists",
                  Dto.Email);
                throw new EmailAlreadyExistsException("Email already exists");
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

        //LogIn
        public async Task<ResponseDTO> LoginAsync(LoginDTO Dto)
        {
            var ExistingUser = await _authRepository.GetUserByEmailAsync(Dto.Email);

            if (ExistingUser == null)
            {
                _logger.LogWarning("Login failed. User not found.");
                throw new InvalidCredentialsException("Invalid Email Or Password");
            }

            if (!PasswordHasher.VerifyPassword(ExistingUser.Password, Dto.Password))
            {
                _logger.LogWarning("Login failed. Invalid password.");
                throw new InvalidCredentialsException("Invalid Password");
            }

            _logger.LogInformation("User {Email} logged in successfully", Dto.Email);

            return await GetAllTokensAsync(ExistingUser);
        }

        //LoginOut
        public async Task<bool> LogOutAsync(string RefreshToken)
        {
            var RefreshEntity = await _authRepository.GetRefreshTokenAsync(RefreshToken);
            if (RefreshEntity == null)
            {
                _logger.LogWarning("Logout failed. Refresh token not found");
                throw new TokenNotFoundException("Token Not Found");
            }
            await _authRepository.RemoveRefreshTokenAsync(RefreshEntity);
            return true;
        }
        public async Task LogOutFromAllAsync(int Id)
        {
            _logger.LogInformation(
              "Logging out user {UserId} from all devices",
              Id);

            await _authRepository.RevokeAllRefreshTokensAsync(Id);
        }


        //Getting new Refresh or Access Tokens
        public async Task<ResponseDTO?> NewTokensAsync(string RefreshToken)
        {
            var Existing = await _authRepository.GetRefreshTokenAsync(RefreshToken);
            if (Existing == null)
            {
                _logger.LogWarning("Token not Found");
                throw new UserNotFoundException("Token not found");
            }
            if(Existing.IsRevoked)
            {
                _logger.LogWarning("Invalid Token (GoTo The Login Page)");
                throw new TokenRevokedException("Invalid Token, Token is Revoked");
            }
            if (Existing.ExpiresAt <= DateTime.UtcNow)
            {
                _logger.LogWarning("Token already expired");
                throw new TokenExpiredException("Token is Expired");
            }

            var user = await _authRepository.GetUserByIdAsync(Existing.UserId);

            if (user == null)
            {
                _logger.LogWarning("User not Found");
                throw new UserNotFoundException("Invalid User Id");
            }

            await _authRepository.RemoveRefreshTokenAsync(Existing);

            return await GetAllTokensAsync(user);
        }

        // Internal services
        private async Task<ResponseDTO> GetAllTokensAsync(Users user)
        {
            var Access = _jwtMethods.GenerateAccessToken(user);
            var RF = _jwtMethods.GenerateRefreshToken(user);

            await _authRepository.AddRefreshTokenAsync(RF);

            return new ResponseDTO
            {
                AccessToken = Access,
                RefreshToken = RF.RefreshToken,
            };
        }
    }
}
