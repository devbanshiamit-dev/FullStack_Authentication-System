using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration_System.Services;
using Registration_System.DTO;

namespace Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTestingController : ControllerBase
    {
        private readonly JwtMethods _jwt;
        public JwtTestingController(JwtMethods jwt)
        {
            _jwt = jwt;
        }

        [HttpGet("AccessToken")]
        public IActionResult GetAS()
        {
            JwtDTO user = new JwtDTO
            {
                Id = 1,
                UserName = "Robin",
                Email = "robin@gmail.com"
            };

            var Access = _jwt.GenerateAccessToken(user);
            return Ok(Access);
        }
        [HttpGet("RefreshToken")]
        public IActionResult GetRF()
        {
            var RefreshToken = _jwt.GenerateRefreshToken();
            return Ok(RefreshToken);
        }
    }
}
