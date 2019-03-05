using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        CityWeatherDto GetCityWeather(string cityName);
        ICollection<CityWeatherDto> GetAllCietiesWeather(List<string> citiesNames);
    }
}
