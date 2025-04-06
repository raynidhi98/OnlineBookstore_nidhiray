using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookstore.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public string PasswordHash { get; set; }

        public string? FullName { get; set; }  // Optional for login
        public string? Email { get; set; }  // Optional for login
        public string? Role { get; set; }
    }
}
