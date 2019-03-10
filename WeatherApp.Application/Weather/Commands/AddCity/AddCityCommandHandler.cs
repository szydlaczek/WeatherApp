using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
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
            var result = await _weatherService.GetCitiesWeather(new List<string> { request.CityName });
            return new Response();
        }
    }
}