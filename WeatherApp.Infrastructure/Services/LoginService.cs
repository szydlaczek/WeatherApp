using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Infrastructure.Identity
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;

        public LoginService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Response> LoginUser(string password, string userName)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if (!result.Succeeded)
                return new Response().AddError("Bad user name or password");
            else
                return new Response();
        }
    }
}