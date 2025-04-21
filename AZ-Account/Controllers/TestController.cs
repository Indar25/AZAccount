using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AZ_Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ping")]
        [AllowAnonymous]
        public IActionResult Ping() => Ok("pong");

        [HttpGet("secure")]
        [Authorize(Policy = "ApiScope")]
        public IActionResult GetSecureData()
        {
            var user = HttpContext.User;
            var isAuthenticated = user.Identity.IsAuthenticated;
            var scope = user.Claims.FirstOrDefault(c => c.Type == "scope")?.Value;
            return Ok("You're authenticated 🔐");

        }
    }
}
