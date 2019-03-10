using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;

namespace WeatherApp.Application.Users.Commands.SignUpUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response>
    {
        private readonly ILoginService _loginService;

        public LoginUserCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<Response> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _loginService.LoginUser(request.Password, request.UserName);
            return result;
        }
    }
}