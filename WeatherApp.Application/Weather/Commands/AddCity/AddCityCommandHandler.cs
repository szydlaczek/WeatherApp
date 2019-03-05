using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Persistence.Context;

namespace WeatherApp.Application.Weather.Commands.AddCity
{
    public class AddCityCommandHandler : IRequestHandler<AddCityCommand, Response>
    {
        private readonly ApplicationDbContext _context;

        public AddCityCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Response> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}