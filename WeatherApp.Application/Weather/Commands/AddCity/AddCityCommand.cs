using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Weather.Commands.AddCity
{
    public class AddCityCommand : IRequest<Response>
    {
        public string CityName { get; set; }
    }
}
