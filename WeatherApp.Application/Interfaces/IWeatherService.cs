using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<string> Errors { get; }
        Task<CityWeatherDto> GetWeather(string cityName);        
    }
}