using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Cities.Commands.UpdateCity
{
    public class UpdateWeatherCommand : IRequest<Response>
    {
    }
}
