using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;
using OnlineBookstore.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Services.Repositories
{
    public class UserService : IUserService
    {
        private readonly BookstoreContext _context;
        public UserService(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> GetUserByCredentialsAsync(string username, string password)
        {
            // Find user by username and password
            var user = await _context.Users
                                      .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Name = user.Username,
                };
            }

            return null; // If user not found
        }

        public Task<UserDTO> AuthenticateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserAsync(UserDTO userDto, string password)
        {
            throw new NotImplementedException();
        }
    }
}
