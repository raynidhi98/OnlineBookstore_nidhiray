using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineBookstore.Data.Models;
using OnlineBookstore.Services.DTOs;
using OnlineBookstore.Services.Interfaces;

namespace OnlineBookstore.Services.Repositories
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserService userRepository)  // ✅ Use IUserRepository
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            // Ensure _userRepository is not null before using it
            if (_userRepository == null)
            {
                throw new InvalidOperationException("UserRepository is not initialized");
            }

            var user = await _userRepository.GetUserByCredentialsAsync(username, password);

            if (user != null)
            {
                return new UserDTO { UserId = user.UserId, Username = user.Username };
            }
            return null;

            //public async Task<UserDTO> AuthenticateAsync(string username, string password)
            //{
            //    // Assume we check the credentials from the database
            //    var user = await _userRepository.GetUserByCredentialsAsync(username, password);

            //    if (user != null)
            //    {
            //        // Return the user info (including user Id)
            //        return new UserDTO { UserId = user.UserId, Username = user.Username };
            //    }
            //    return null;
        }

        //public AuthService(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public Task<string> GenerateJwtTokenAsync(User user, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        //    new Claim(JwtRegisteredClaimNames.Name, user.Username),
        //    new Claim("role", user.Role)
        //};

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["Jwt:Issuer"],
        //        audience: _configuration["Jwt:Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
        //        signingCredentials: credentials
        //    );

        //    return jwtSecurityTokenHandler.WriteToken(token);
        //}


        public async Task<string> GenerateJwtTokenAsync(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("role", user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException(); // TODO: Implement user validation logic
        }
    }
}
