using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Adapter;
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
            var apiResult = await _weatherService.GetCitiesWeather(new List<string> { request.CityName });
            foreach (var cityWeather in apiResult)
            {
                City city = new City();
                city.Map(cityWeather);
                _context.Cities.Add(city);
            }
            Response response = new Response();
            foreach(string error in _weatherService.Errors)
            {
                response.AddError(error);
            }
            return response;            
        }
    }
}