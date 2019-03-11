using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Exceptions;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Cities.Commands.AddCity
{
    public class AddCityCheckDatabase : IRequestPreProcessor<AddCityCommand>
    {
        private readonly ApplicationDbContext _context;

        public AddCityCheckDatabase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Process(AddCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Where(c => string.Equals(c.Name, request.CityName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();

            if (city != null)
                throw new ItemExistsException($"City {request.CityName} already exists");
        }
    }
}