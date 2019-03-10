using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<string> Errors { get; }
        Task<ICollection<CityWeatherDto>> GetCitiesWeather(List<string> citiesNames);        
    }
}