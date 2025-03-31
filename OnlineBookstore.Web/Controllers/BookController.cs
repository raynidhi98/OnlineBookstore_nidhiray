using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    [Route("books")] // Adjust the route as per your needs
    public class BookController : Controller  // Use Controller instead of ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);  // Returns a view with the list of books
        }

        [HttpPost]
        [Authorize] // Only authenticated users can add books
        public async Task<IActionResult> AddBook([FromBody] BookDTO bookDto)
        {
            var result = await _bookService.AddBookAsync(bookDto);
            if (!result) return BadRequest("Failed to add book.");
            return Ok("Book added successfully.");
        }
    }
}
