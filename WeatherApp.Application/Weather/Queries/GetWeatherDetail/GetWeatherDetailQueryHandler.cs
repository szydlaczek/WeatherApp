using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Weather.Queries.GetWeatherDetail
{
    public class GetWeatherDetailQueryHandler : IRequestHandler<GetWeatherDetailQuery, WeatherDetailPreview>
    {
        private readonly ApplicationDbContext _context;

        public GetWeatherDetailQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WeatherDetailPreview> Handle(GetWeatherDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Cities
                .Include(w => w.Weather)
                .Include(wi => wi.Wind)
                .Include(m => m.Main)
                .FirstOrDefaultAsync(c => c.Id == request.CityId);

            return null;
        }
    }
}