using Registration_System.DTO;
using Registration_System.Models;

namespace Registration_System.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDTO> RegisterAsync(RequestDTO Dto);
        Task<ResponseDTO> LoginAsync(LoginDTO Dto);
        Task<bool> LogOutAsync(string RefreshToken);
        Task LogOutFromAllAsync(int Id);
        Task<ResponseDTO?> NewTokensAsync(string RefreshToken);
    }
}