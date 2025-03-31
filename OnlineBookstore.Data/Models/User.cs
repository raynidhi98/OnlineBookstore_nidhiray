﻿namespace OnlineBookstore.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // Hashed Password
        public string Role { get; set; }  // Admin or Customer
    }
}
