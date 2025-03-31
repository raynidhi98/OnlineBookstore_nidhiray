using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;

namespace OnlineBookstore.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtTokenAsync(UserDTO user);
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
    }
}
