using MediatR;
using System.Collections.Generic;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Weather.Queries.GetAllCitiesWeather
{
    public class GetAllCitiesWeatherQuery : IRequest<ICollection<CityWeatherPreview>>
    {
    }
}