using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
    }

    public class CartItemDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
