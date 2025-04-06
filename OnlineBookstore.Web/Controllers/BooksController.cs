//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using OnlineBookstore.Services.DTOs;
//using OnlineBookstore.Services.Interfaces;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace OnlineBookstore.Web.Controllers
//{
//    [Route("api/books")]
//    [ApiController]
//    public class BooksController : Controller
//    {
//        private readonly IBookService _bookService;

//        public BooksController(IBookService bookService)
//        {
//            _bookService = bookService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var books = await _bookService.GetAllBooksAsync();
//            return View(books); // Returns a view with the list of books
//        }
//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> Details(int id)
//        //{
//        //    var book = await _bookService.GetBookByIdAsync(id);
//        //    if (book == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return View(book);
//        //}

//        // ✅ Get a single book by ID
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetBookById(int id)
//        {
//            var book = await _bookService.GetBookByIdAsync(id);
//            if (book == null) return NotFound("Book not found.");
//            return Ok(book);
//        }

//        [HttpPost]
//       // [Authorize]
//        public async Task<IActionResult> AddBook([FromBody] BookDTO bookDto)
//        {
//            if (bookDto == null) return BadRequest("Invalid book data.");

//            var result = await _bookService.AddBookAsync(bookDto);
//            if (result == null) return BadRequest("Failed to add book.");

//            return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, result);
//            //return Ok("Book added successfully.");
//        }

//        [HttpPut("{id}")]
//       // [Authorize]
//        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
//        {
//            if (bookDto == null || id != bookDto.Id) return BadRequest("Invalid book data.");

//            var result = await _bookService.UpdateBookAsync(bookDto);
//            if (!result) return NotFound("Book not found.");
//            return Ok(result);
//            //return Ok("Book updated successfully.");
//        }

//        [HttpDelete("{id}")]
//        //[Authorize]
//        public async Task<IActionResult> DeleteBook(int id)
//        {
//            var result = await _bookService.DeleteBookAsync(id);
//            if (!result) return NotFound("Book not found.");

//            return Ok("Book deleted successfully.");
//        }
//    }

//}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);  // This returns your Index.cshtml view
        }
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookDTO book)
        {
            if (!ModelState.IsValid) return View(book);

            await _bookService.AddBookAsync(book);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDTO book)
        {
            if (!ModelState.IsValid) return View(book);

            await _bookService.UpdateBookAsync(book);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            return View(book); // Optional: show confirm delete
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }




        // ✅ Get a single book by ID
        //[HttpGet("{id}")]
        //    public async Task<IActionResult> GetBookById(int id)
        //    {
        //        var book = await _bookService.GetBookByIdAsync(id);
        //        if (book == null) return NotFound("Book not found.");
        //        return Ok(book);
        //    }

        //    [HttpPost]
        //    [Authorize]
        //    public async Task<IActionResult> AddBook([FromBody] BookDTO bookDto)
        //    {
        //        if (bookDto == null) return BadRequest("Invalid book data.");

        //        var result = await _bookService.AddBookAsync(bookDto);
        //        if (!result) return BadRequest("Failed to add book.");

        //        return Ok("Book added successfully.");
        //    }

        //    [HttpPut("{id}")]
        //    [Authorize]
        //    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
        //    {
        //        //if (bookDto == null || id != bookDto.Id) return BadRequest("Invalid book data.");

        //        //var result = await _bookService.UpdateBookAsync(bookDto);
        //        //if (!result) return NotFound("Book not found.");

        //        //return Ok("Book updated successfully.");
        //        var book = await _bookService.GetBookByIdAsync(id);
        //        if (book == null)
        //            return NotFound();

        //        return View(book);
        //    }

        //    [HttpDelete("{id}")]
        //    [Authorize]
        //    public async Task<IActionResult> DeleteBook(int id)
        //    {
        //        var result = await _bookService.DeleteBookAsync(id);
        //        if (!result) return NotFound("Book not found.");

        //        return Ok("Book deleted successfully.");
        //    }
    }

}