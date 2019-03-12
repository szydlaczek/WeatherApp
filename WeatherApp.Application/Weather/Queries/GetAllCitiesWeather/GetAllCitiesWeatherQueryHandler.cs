using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Weather.Queries.GetAllCitiesWeather
{
    public class GetAllCitiesWeatherQueryHandler : IRequestHandler<GetAllCitiesWeatherQuery, ICollection<CityWeatherPreview>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCitiesWeatherQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<CityWeatherPreview>> Handle(GetAllCitiesWeatherQuery request, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities
                .Include(c => c.Main)
                .Include(d => d.Weather)
                .Include(a => a.Wind).ToListAsync();

            var result = cities.AsQueryable().Select(CityWeatherPreview.Projection).ToList();

            return result;
        }
    }
}