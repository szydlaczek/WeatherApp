using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {    
        Task<ICollection<CityWeatherDto>> GetCitiesWeather(List<string> citiesNames);
    }
}