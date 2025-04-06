using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;

namespace OnlineBookstore.Services.Repositories
{
    public class OrderService : IOrderService
    {
        public Task<List<OrderDTO>> GetOrdersByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PlaceOrderAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}