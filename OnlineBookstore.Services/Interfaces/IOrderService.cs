using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;

namespace OnlineBookstore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDTO> GetOrderByIdAsync(int orderId);
        Task<bool> PlaceOrderAsync(int userId);
    }
}
