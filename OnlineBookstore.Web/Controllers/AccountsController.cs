using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountsController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View(); // Return the login page
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            // Authenticate user (using AuthenticationService)
            var user = await _authService.AuthenticateAsync(userDto.Name, userDto.Password);

            if (user != null)
            {
                // Store UserId in the session after successful login
                HttpContext.Session.SetInt32("UserId", user.Id);

                // Redirect to home page or any other protected page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If authentication fails, add an error message
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(userDto); // Return to the login page with error
            }
        }

        public IActionResult Register()
        {
            return View(); // Show registration page
        }
    }
}
