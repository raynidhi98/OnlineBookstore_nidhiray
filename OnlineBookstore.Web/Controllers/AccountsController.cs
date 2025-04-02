using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;
using OnlineBookstore.Data.Models;


namespace OnlineBookstore.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly BookstoreContext _dbContext; // ✅ Inject DbContext

        public AccountsController(IAuthenticationService authService, BookstoreContext dbContext)
        {
            _authService = authService;
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authService.AuthenticateAsync(model.Username, model.PasswordHash);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login credentials.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View(); // Show registration page
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash),
                FullName = model.FullName,
                Role = model.Role
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Login", "Accounts");
        }

    }
}
