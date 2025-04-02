using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    //[Route("books")] 
    public class BooksController : Controller 
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);  // Returns a view with the list of books
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var book = await _bookService.GetBookByIdAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(book);
        //}

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
