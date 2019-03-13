using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Identity;

namespace WeatherApp.WebUI.Bootstrapping
{
    internal static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddScoped<IRoleStore<Role>, CustomRoleStore>()
                .AddScoped<CustomRoleStore>()
                .AddScoped<IUserStore<User>, CustomUserStore>();

            services.AddIdentity<User, Role>(ConfigureIdentityOptions)
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.ExpireTimeSpan = TimeSpan.FromDays(30));

            return services;
        }

        private static void ConfigureIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    }
}