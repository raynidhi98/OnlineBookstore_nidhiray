using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.DTOs
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        //public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string? Role { get; set; }
    }

    //public class UserDTO
    //{
    //    public int UserId { get; set; }

    //    [Required(ErrorMessage = "Username is required.")]
    //    public string Username { get; set; }

    //    [Required(ErrorMessage = "Password is required.")]
    //    public string Password { get; set; }
    //    public string PasswordHash { get; set; }

    //    public string? FullName { get; set; }  // Optional for login
    //    public string? Email { get; set; }  // Optional for login
    //    public string? Role { get; set; }
    //}
}
