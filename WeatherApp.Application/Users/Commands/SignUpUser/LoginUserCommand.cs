using MediatR;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Users.Commands.SignUpUser
{
    public class LoginUserCommand : IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}