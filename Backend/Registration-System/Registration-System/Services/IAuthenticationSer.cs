using Registration_System.DTO;
using Registration_System.Models;

namespace Registration_System.Services
{
    public interface IAuthenticationSer
    {
        Task<ResponceDTO?> RegisterAsync(RequestDTO Dto);
        Task<ResponceDTO?> LoginAsync(LoginDTO Dto);
        Task<bool> LogOutAsync(string RefreshToken);
        Task LogOutFromAllAsync(int Id);
        Task<ResponceDTO?> NewTokensAsync(string RefreshToken);
        Task<ResponceDTO> GetAllTokensAsync(Users user);
    }
}