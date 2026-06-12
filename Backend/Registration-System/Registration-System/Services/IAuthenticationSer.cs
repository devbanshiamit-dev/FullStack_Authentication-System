using Registration_System.DTO;
using Registration_System.Models;

namespace Registration_System.Services
{
    public interface IAuthenticationSer
    {
        Task<ResponceDTO?> RegisterAsync(RequestDTO Dto);
    }
}