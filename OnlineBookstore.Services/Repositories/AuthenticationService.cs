using System;
using System.Threading.Tasks;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;

namespace OnlineBookstore.Services.Repositories
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userRepository;

        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            // Assume we check the credentials from the database
            var user = await _userRepository.GetUserByCredentialsAsync(username, password);

            if (user != null)
            {
                // Return the user info (including user Id)
                return new UserDTO { Id = user.Id, Name = user.Name };
            }
            return null;
        }

        //public AuthenticationService()
        //{
        //    // Constructor logic if needed
        //}

        public Task<string> GenerateJwtTokenAsync(UserDTO user)
        {
            throw new NotImplementedException(); // TODO: Implement JWT token generation logic
        }

        public Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException(); // TODO: Implement user validation logic
        }
    }
}
