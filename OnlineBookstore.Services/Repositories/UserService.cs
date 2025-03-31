using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;

namespace OnlineBookstore.Services.Repositories
{
    public class UserService : IUserService
    {
        public Task<UserDTO> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
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
