using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.Interfaces;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        // Show order list or order details
        return View();
    }

    // Action to handle order placement
    public async Task<IActionResult> PlaceOrder()
    {
        var result = await _orderService.PlaceOrderAsync(1); // replace with dynamic user ID
        if (result)
        {
            return RedirectToAction("OrderConfirmation");
        }
        return BadRequest("Failed to place order.");
    }

    public IActionResult OrderConfirmation()
    {
        return View();
    }
}