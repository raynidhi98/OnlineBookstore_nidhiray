using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto, [FromQuery] string password)
        {
            var result = await _userService.RegisterUserAsync(userDto, password);
            if (!result) return BadRequest("User registration failed.");
            return Ok("User registered successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
