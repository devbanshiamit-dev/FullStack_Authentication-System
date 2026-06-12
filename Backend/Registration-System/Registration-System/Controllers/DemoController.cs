using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration_System.DTO;
using Registration_System.Services;

namespace Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IAuthenticationSer _authService;

        public DemoController(IAuthenticationSer authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RequestDTO Dto)
        {
            var Result = await _authService.RegisterAsync(Dto);
            return Ok(Result);
        }
    }
}
