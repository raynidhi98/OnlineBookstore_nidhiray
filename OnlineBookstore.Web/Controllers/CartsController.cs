using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var cart = await _cartService.GetCartByUserIdAsync(userId.Value);
            return View(cart);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int bookId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // Handle the case where userId is not found in session (e.g., user is not logged in)
                return RedirectToAction("Login", "Account"); // Redirect to Login page if no userId in session
            }

            var result = await _cartService.RemoveFromCartAsync(userId.Value, bookId);
            if (!result)
            {
                return BadRequest("Failed to remove item from cart.");
            }

            return RedirectToAction("Index");
        }

    }
}