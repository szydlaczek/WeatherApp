using MediatR;
using System.ComponentModel.DataAnnotations;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Cities.Commands.AddCity
{
    public class AddCityCommand : IRequest<Response>
    {               
        public string CityName { get; set; }
    }
}