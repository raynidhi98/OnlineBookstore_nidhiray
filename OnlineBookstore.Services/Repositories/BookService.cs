using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Data.Models;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using OnlineBookstore.Data;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly BookstoreContext _context; // Inject DbContext

    public BookService(BookstoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
    {
        return await _context.Books
            .Select(book => new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                StockQuantity = book.StockQuantity
            })
            .ToListAsync();
    }
    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddBookAsync(BookDTO book)
    {
        return await Task.FromResult(true); // Assume the book is successfully added
    }

    public async Task<bool> UpdateBookAsync(BookDTO book)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        throw new NotImplementedException(); // Implement actual logic here
    }
}

