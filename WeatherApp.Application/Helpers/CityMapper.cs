using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Application.Dtos;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Helpers
{
    public static class CityMapper
    {
        public static void Map(this City city, CityWeatherDto cityDto)
        {
            city.ApiId = cityDto.ApiId;
            city.LastUpdate = cityDto.LastUpdate;
            city.Main.Humidity = cityDto.Main.Humidity;
            city.Main.Pressure = cityDto.Main.Pressure;
            city.Main.Temperature = cityDto.Main.Temperature;
            city.Wind.Speed= cityDto.Wind.Speed;
            city.LastUpdate = cityDto.LastUpdate;
        }
    }
}
