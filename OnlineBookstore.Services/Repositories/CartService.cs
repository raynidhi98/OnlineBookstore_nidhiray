using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Repositories
{
    public class CartService : ICartService
    {
        private readonly Dictionary<int, List<CartItemDTO>> _userCarts;
        private readonly BookstoreContext _context;

        public CartService()
        {
            _userCarts = new Dictionary<int, List<CartItemDTO>>();
        }

        public async Task<CartDTO> GetCartByUserIdAsync(int userId)
        {
            var cartItems = await _context.Cart
                                          .Where(c => c.UserId == userId)
                                          .Select(c => new CartItemDTO { BookId = c.BookId, Quantity = c.Quantity })
                                          .ToListAsync();

            return new CartDTO { UserId = userId, Items = cartItems };
        }

        public async Task<bool> AddToCartAsync(int userId, CartItemDTO cartItem) // Corrected method signature
        {
            if (!_userCarts.ContainsKey(userId))
            {
                _userCarts[userId] = new List<CartItemDTO>();
            }

            _userCarts[userId].Add(cartItem);
            return await Task.FromResult(true);
        }

        public async Task<bool> RemoveFromCartAsync(int userId, int bookId)
        {
            if (_userCarts.TryGetValue(userId, out var cartItems))
            {
                var item = cartItems.Find(c => c.BookId == bookId);
                if (item != null)
                {
                    cartItems.Remove(item);
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            if (_userCarts.ContainsKey(userId))
            {
                _userCarts[userId].Clear();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
