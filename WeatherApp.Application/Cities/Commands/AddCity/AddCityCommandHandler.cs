using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Cities.Commands.AddCity;
using WeatherApp.Application.Helpers;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Weather.Commands.AddCity
{
    public class AddCityCommandHandler : IRequestHandler<AddCityCommand, Response>
    {
        private readonly ApplicationDbContext _context;
        private IWeatherService _weatherService;

        public AddCityCommandHandler(ApplicationDbContext context, IWeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        public async Task<Response> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _weatherService.GetWeather(request.CityName);
            if (result != null)
            {
                City city = new City();
                city.Map(result);
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();
            }
            
            Response response = new Response();
            foreach (string error in _weatherService.Errors)
            {
                response.AddError(error);
            }
            return response;
        }
    }
}