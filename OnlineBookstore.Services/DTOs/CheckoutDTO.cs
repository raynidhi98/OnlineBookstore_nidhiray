using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.DTOs
{
    public class CheckoutDTO
    {
        public int UserId { get; set; }
        public List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
        public decimal TotalAmount { get; set; }
        public PaymentInfoDTO? PaymentInfo { get; set; }
    }

    public class PaymentInfoDTO
    {
        public string? CardNumber { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public string? BillingAddress { get; set; }
    }
}