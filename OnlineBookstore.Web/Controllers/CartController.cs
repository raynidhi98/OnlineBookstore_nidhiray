using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [Authorize] // Only logged-in users can access cart
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromQuery] int userId, [FromBody] CartItemDTO cartItem)
        {
            var result = await _cartService.AddToCartAsync(userId, cartItem);
            if (!result) return BadRequest("Failed to add item to cart.");
            return Ok("Item added to cart.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            return Ok(cart);
        }
    }
}
