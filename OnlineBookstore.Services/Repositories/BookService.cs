//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OnlineBookstore.Data.Models;
//using OnlineBookstore.Services.DTOs;
//using OnlineBookstore.Services.Interfaces;
//using OnlineBookstore.Data;
//using Microsoft.EntityFrameworkCore;

//public class BookService : IBookService
//{
//    private readonly BookstoreContext _context; // Inject DbContext

//    public BookService(BookstoreContext context)
//    {
//        _context = context;
//    }

//    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
//    {
//        try
//        {
//            return await _context.Books
//            .Select(book => new BookDTO
//            {
//                Id = book.Id,
//                Title = book.Title,
//                Author = book.Author,
//                ISBN = book.ISBN,
//                Price = book.Price,
//                StockQuantity = book.StockQuantity
//            })
//            .ToListAsync();
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching data", ex);
//        }

//    }
//    // Get book by ID
//    public async Task<BookDTO> GetBookByIdAsync(int id)
//    {
//        try
//        {
//            var book = await _context.Books.FindAsync(id);
//            if (book == null) return null;

//            return new BookDTO
//            {
//                Id = book.Id,
//                Title = book.Title,
//                Author = book.Author,
//                ISBN = book.ISBN,
//                Price = book.Price,
//                StockQuantity = book.StockQuantity
//            };

//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching data", ex);
//        }
//    }

//    // Add a new book
//    public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
//    {
//        try
//        {
//            var book = new Book
//            {
//                Title = bookDto.Title,
//                Author = bookDto.Author,
//                ISBN = bookDto.ISBN,
//                Price = bookDto.Price,
//                StockQuantity = bookDto.StockQuantity
//            };

//            //_context.Books.Add(book);
//            //return await _context.SaveChangesAsync() > 0;

//            _context.Books.Add(book);
//            await _context.SaveChangesAsync();

//            bookDto.Id = book.Id;  // ✅ Assign the generated ID

//            return bookDto;

//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching data", ex);
//        }

//    }

//    // Update an existing book
//    public async Task<bool> UpdateBookAsync(BookDTO bookDto)
//    {
//        try
//        {
//            var book = await _context.Books.FindAsync(bookDto.Id);
//            if (book == null) return false;

//            book.Title = bookDto.Title;
//            book.Author = bookDto.Author;
//            book.ISBN = bookDto.ISBN;
//            book.Price = bookDto.Price;
//            book.StockQuantity = bookDto.StockQuantity;

//            _context.Books.Update(book);
//            return await _context.SaveChangesAsync() > 0;
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching data", ex);
//        }

//    }

//    // Delete a book
//    public async Task<bool> DeleteBookAsync(int id)
//    {
//        try
//        {
//            var book = await _context.Books.FindAsync(id);
//            if (book == null) return false;

//            _context.Books.Remove(book);
//            return await _context.SaveChangesAsync() > 0;
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching data", ex);
//        }
//    }
//}

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
        try
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
        catch (Exception ex)
        {
            throw new Exception("Error fetching data", ex);
        }

    }
    // Get book by ID
    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                StockQuantity = book.StockQuantity
            };

        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching data", ex);
        }
    }

    // Add a new book
    public async Task<bool> AddBookAsync(BookDTO bookDto)
    {
        try
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                Price = bookDto.Price,
                StockQuantity = bookDto.StockQuantity
            };

            _context.Books.Add(book);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching data", ex);
        }

    }

    // Update an existing book
    public async Task<bool> UpdateBookAsync(BookDTO bookDto)
    {
        try
        {
            var book = await _context.Books.FindAsync(bookDto.Id);
            if (book == null) return false;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.Price = bookDto.Price;
            book.StockQuantity = bookDto.StockQuantity;

            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching data", ex);
        }

    }

    // Delete a book
    public async Task<bool> DeleteBookAsync(int id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching data", ex);
        }
    }
}

