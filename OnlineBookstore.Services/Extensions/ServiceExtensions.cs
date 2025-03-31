using Microsoft.Extensions.DependencyInjection;
using OnlineBookstore.Services.Interfaces;
using OnlineBookstore.Services.Extensions;
using AutoMapper; // ✅ Ensure AutoMapper is imported
using System;
using OnlineBookstore.Services.Repositories;

namespace OnlineBookstore.Services.Extensions
{
    public static class ServiceExtensions // ✅ This class wraps the extension method
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            // ✅ Register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
