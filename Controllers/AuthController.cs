using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagementAPI.Helpers;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IUserService userService, JwtHelper jwtHelper) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly JwtHelper _jwtHelper = jwtHelper;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new AuthResponse { Token = token });
        }
    }
}
