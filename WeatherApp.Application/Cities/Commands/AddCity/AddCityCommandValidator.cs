using FluentValidation;

namespace WeatherApp.Application.Cities.Commands.AddCity
{
    public class AddCityCommandValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityCommandValidator()
        {
            RuleFor(c => c.CityName)
                .NotEmpty()
                .WithMessage("City name cannot be empty")
                .NotNull()
                .WithMessage("City name cannot be empty");
        }
    }
}