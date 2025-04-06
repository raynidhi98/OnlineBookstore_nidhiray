using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Models
{
    public class CartItems
    {
        [Key]
        public int BookId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}