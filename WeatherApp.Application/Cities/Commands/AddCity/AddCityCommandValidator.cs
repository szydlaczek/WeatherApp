using FluentValidation;

namespace WeatherApp.Application.Cities.Commands.AddCity
{
    public class AddCityCommandValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityCommandValidator()
        {
            RuleFor(c => c.CityName)
                .Must(d => !string.IsNullOrEmpty(d))
                .WithMessage("City name cannot be empty");
        }
    }
}