using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Dtos;
using WeatherApp.Application.Interfaces;

namespace WeatherApp.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        public WeatherService()
        {

        }

        public ICollection<CityWeatherDto> GetAllCietiesWeather(List<string> citiesNames)
        {
            throw new NotImplementedException();
        }

        public CityWeatherDto GetCityWeather(string cityName)
        {
            throw new NotImplementedException();
        }
    }
}
