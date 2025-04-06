using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;

namespace OnlineBookstore.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartByUserIdAsync(int userId);
        Task<bool> AddToCartAsync(int userId, CartItemDTO cartItem);
        Task<bool> RemoveFromCartAsync(int userId, int bookId);
        Task<bool> ClearCartAsync(int userId);
    }
}