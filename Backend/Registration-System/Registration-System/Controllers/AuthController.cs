using Microsoft.AspNetCore.Mvc;
using Registration_System.DTO;
using Registration_System.Services;

namespace Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationSer _authService;

        public AuthController(IAuthenticationSer authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RequestDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result == null)
                return BadRequest("Email already exists.");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Invalid email or password.");

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDTO dto)
        {
            var result = await _authService.NewTokensAsync(dto.RefreshToken);

            if (result == null)
                return Unauthorized("Invalid refresh token.");

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshTokenDTO dto)
        {
            var result = await _authService.LogOutAsync(dto.RefreshToken);

            if (!result)
                return BadRequest("Refresh token not found.");

            return Ok("Logged out successfully.");
        }

        [HttpPost("logout-all/{userId:int}")]
        public async Task<IActionResult> LogoutAll(int userId)
        {
            await _authService.LogOutFromAllAsync(userId);

            return Ok("Logged out from all devices.");
        }
    }
}