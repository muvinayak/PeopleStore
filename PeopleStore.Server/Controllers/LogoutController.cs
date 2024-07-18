using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PeopleStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        SignInManager<IdentityUser> _signInManager;
        public LogoutController(SignInManager<IdentityUser> signInManager) {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] object empty)
        {
            string? userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (empty != null)
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            return Unauthorized();
        }
    }
}
