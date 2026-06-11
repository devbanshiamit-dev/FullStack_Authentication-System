using Microsoft.EntityFrameworkCore;
using Registration_System.Data;
using Registration_System.Models;

namespace Registration_System.Repo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(ApplicationDbContext context, ILogger<AuthRepository> logger)
        {
            _context = context;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Finding User In DataBase 
        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            _logger.LogInformation("Fetching user with email {Email}", email);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if(user == null)
                _logger.LogWarning("User not found for email {Email}", email);
            
            return user;
        }
        public async Task<Users?> GetUserByIdAsync(int Id)
        {
            _logger.LogInformation("Fetching user with Id {Id}", Id);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
                _logger.LogWarning("User not found for Id {Id}", Id);

            return user;
        }

        //Finding RefreshToken In DataBase
        public async Task<List<UserRefreshToken>> GetRefreshTokensByUserIdAsync(int Id)
        {
            _logger.LogInformation("Fetching All Users RefreshTokens for User {UserId}", Id);

            var Tokens = await _context.UserRefreshTokens.Where(x => x.UserId == Id).ToListAsync();

            if (!Tokens.Any())
            {
                _logger.LogWarning("No Tokens Are Found for User {UserId}",Id);
            }

            return Tokens;
        }
        public async Task<UserRefreshToken?> GetRefreshTokenAsync(string refreshToken)
        {
            _logger.LogInformation(
                "Fetching refresh token");

            var token = await _context.UserRefreshTokens
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if (token == null)
            {
                _logger.LogWarning(
                    "Refresh token not found");
            }

            return token;
        }

        //Adding Data In DataBase
        public async Task<Users> AddUserAsync(Users user)
        {
            _logger.LogInformation(
                "Adding user {UserName}",
                user.UserName);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task AddRefreshTokenAsync(UserRefreshToken RF)
        {
            _logger.LogInformation(
                "Adding refresh token for user {UserId}",
                 RF.UserId);

            await _context.UserRefreshTokens.AddAsync(RF);
            await _context.SaveChangesAsync();
        }

        //Deleting Tokens In DataBase
        public async Task RemoveRefreshTokenAsync(UserRefreshToken token)
        {
            _logger.LogInformation(
                 "Removing refresh token for user {UserId}",
                  token.UserId);
            _context.UserRefreshTokens.Remove(token);
            await _context.SaveChangesAsync();
        }
        public async Task RevokeAllRefreshTokensAsync(int UserId)
        {
            var Tokens = await _context.UserRefreshTokens.Where(x => x.UserId == UserId).ToListAsync();
            _context.UserRefreshTokens.RemoveRange(Tokens);

            await _context.SaveChangesAsync();
        }
    }
}