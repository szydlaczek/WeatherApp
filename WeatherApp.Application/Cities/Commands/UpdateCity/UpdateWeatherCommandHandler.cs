using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Helpers;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Cities.Commands.UpdateCity
{
    public class UpdateWeatherCommandHandler : IRequestHandler<UpdateWeatherCommand, Response>
    {
        private readonly ApplicationDbContext _context;
        private IWeatherService _weatherService;

        public UpdateWeatherCommandHandler(ApplicationDbContext context, IWeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        public async Task<Response> Handle(UpdateWeatherCommand request, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities
                .Include(c => c.Main)
                .Include(d => d.Weather)
                .Include(a => a.Wind)
                .ToListAsync();

            foreach (var city in cities)
            {
                var resultFromApi = await _weatherService.GetWeather(city.Name);
                if (resultFromApi != null)
                {
                    city.Map(resultFromApi);
                }
            }

            await _context.SaveChangesAsync();
            var response = new Response();

            foreach (string error in _weatherService.Errors)
            {
                response.AddError(error);
            }

            return response;
        }
    }
}