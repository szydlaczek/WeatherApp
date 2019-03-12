using MediatR;
using System.Collections.Generic;

namespace WeatherApp.Application.Weather.Queries.GetAllCitiesWeather
{
    public class GetAllCitiesWeatherQuery : IRequest<ICollection<CityWeatherPreview>>
    {
    }
}