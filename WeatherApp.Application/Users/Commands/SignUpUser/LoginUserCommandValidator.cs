using FluentValidation;

namespace WeatherApp.Application.Users.Commands.SignUpUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty");
        }
    }
}