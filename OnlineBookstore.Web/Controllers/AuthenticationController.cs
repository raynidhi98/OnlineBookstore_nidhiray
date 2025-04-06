using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        // Authenticate user and return user details with role
        private async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            var user = await _authService.GetUserByCredentialsAsync(username, password);
            return user != null ? new UserDTO { UserId = user.UserId, Username = user.Username, Role = user.Role } : null;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {

            var user = await _authService.AuthenticateAsync(userDto.Username, userDto.Password); //PasswordHash
            if (user == null)
                return Unauthorized("Invalid credentials.");

            var token = await _authService.GenerateJwtTokenAsync(user);
            return Ok(new { Token = token, Role = user.Role });
        }
        //public async Task<UserDTO> AuthenticateAsync(string username, string password)
        //{
        //    var user = await _authService.GetUserByCredentialsAsync(username, password);
        //    return user != null ? new UserDTO { UserId = user.UserId, Username = user.Username, Role = user.Role } : null;
        //}
        //// API endpoint to login and generate JWT token
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        //{
        //    var token = await _authService.GenerateJwtTokenAsync(userDto);
        //    if (token == null) return Unauthorized("Invalid credentials.");
        //    return Ok(new { Token = token });
        //}
    }
}
