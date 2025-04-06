using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using OnlineBookstore.Data;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Models;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

namespace OnlineBookstore.Services.Repositories
{
    public class UserService : IUserService
    {
        private readonly BookstoreContext _context;
        //
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(BookstoreContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }
        public async Task<UserDTO> GetUserByCredentialsAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isPasswordValid)
                return null;


            //var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            //if (verificationResult == PasswordVerificationResult.Failed)
            //    return null;

            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role
            };
        }

        //public async Task<UserDTO> GetUserByCredentialsAsync(string username, string password)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        //    //var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        //    if (user != null)
        //    {
        //        Console.WriteLine($"DEBUG: Retrieved hashed password = {user.PasswordHash}");
        //        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        //        if (result == PasswordVerificationResult.Success)
        //        {
        //            return new UserDTO
        //            {
        //                UserId = user.UserId,
        //                Username = user.Username,
        //                FullName = user.FullName,
        //                Email = user.Email,
        //                Role = user.Role
        //            };
        //        }
        //    }

        //    return null;
        //}

        public async Task<UserDTO> AuthenticateUserAsync(string username, string password)
        {
            return await GetUserByCredentialsAsync(username, password);  // ✅ Call the actual method
        }


        public async Task<bool> RegisterUserAsync(UserDTO userDto, string password)
        {
            var user = new User
            {
                Username = userDto.Username,
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role
            };

            // Hash the password before saving
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
