using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Adapter;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Persistence.Context;
using WeatherApp.Application.Helpers;

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
            var cities = await _context.Cities.Include(c=>c.Main).Include(d=>d.Weather).Include(a=>a.Wind).ToListAsync();
            var apiResult = await _weatherService.GetCitiesWeather(cities.Select(c=>c.Name).ToList());           

            foreach (var city in cities)
            {
                var cityFromApi = apiResult.Where(c => string.Equals(c.Name, city.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (cityFromApi!=null)
                {
                    city.Map(cityFromApi);
                    
                }
            }
            await _context.SaveChangesAsync();
            return new Response();
        }
    }
}
