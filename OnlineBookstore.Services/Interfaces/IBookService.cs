using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Data.Models;
using OnlineBookstore.Services.DTOs;

namespace OnlineBookstore.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int bookId);
        Task<bool> AddBookAsync(BookDTO book);
        Task<bool> UpdateBookAsync(BookDTO book);
        Task<bool> DeleteBookAsync(int id);
    }
}

