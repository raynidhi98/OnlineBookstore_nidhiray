using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; }

        public string? FullName { get; set; }  // Optional for login
        public string? Email { get; set; }  // Optional for login
        public string? Role { get; set; }
    }
}
