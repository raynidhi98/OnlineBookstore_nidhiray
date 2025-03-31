using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;

namespace OnlineBookstore.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<UserDTO> AuthenticateUserAsync(string username, string password);
        Task<bool> RegisterUserAsync(UserDTO userDto, string password);
    }
}
