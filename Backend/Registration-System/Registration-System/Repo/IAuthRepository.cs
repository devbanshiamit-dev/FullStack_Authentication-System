using Registration_System.Models;

namespace Registration_System.Repo
{
    public interface IAuthRepository
    {
        Task<Users?> GetUserByEmailAsync(string email);
        Task<Users?> GetUserByIdAsync(int Id);
        Task<List<UserRefreshToken>> GetRefreshTokensByUserIdAsync(int Id);
        Task<UserRefreshToken?> GetRefreshTokenAsync(string refreshToken);
        Task<Users> AddUserAsync(Users user);
        Task AddRefreshTokenAsync(UserRefreshToken RF);
        Task RemoveRefreshTokenAsync(UserRefreshToken token);
        Task RevokeAllRefreshTokensAsync(int UserId);
    }
}