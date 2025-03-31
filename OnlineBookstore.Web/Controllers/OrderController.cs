using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize] // Only logged-in users can place orders
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder([FromQuery] int userId)
        {
            var result = await _orderService.PlaceOrderAsync(userId);
            if (!result) return BadRequest("Order placement failed.");
            return Ok("Order placed successfully.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }
    }
}
