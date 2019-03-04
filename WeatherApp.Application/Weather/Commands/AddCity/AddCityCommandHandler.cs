using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Weather.Commands.AddCity
{
    public class AddCityCommandHandler : IRequestHandler<AddCityCommand, Response>
    {
        public AddCityCommandHandler()
        {

        }
        public Task<Response> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
