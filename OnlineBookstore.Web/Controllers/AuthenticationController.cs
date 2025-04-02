using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        // API endpoint to login and generate JWT token
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            var token = await _authService.GenerateJwtTokenAsync(userDto);
            if (token == null) return Unauthorized("Invalid credentials.");
            return Ok(new { Token = token });
        }
    }
}
