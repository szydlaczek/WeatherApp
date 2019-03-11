using System.Linq;
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
            city.Name = cityDto.Name;

            if (city.Main is null)
                city.Main = new Main();

            city.Main.Humidity = cityDto.Main.Humidity;
            city.Main.Pressure = cityDto.Main.Pressure;
            city.Main.Temperature = cityDto.Main.Temperature;

            if (city.Wind is null)
                city.Wind = new Wind();

            city.Wind.Speed = cityDto.Wind.Speed;

            if (city.Weather is null)
                city.Weather = new Domain.Entities.Weather();

            city.Weather.Description = cityDto.Weather.FirstOrDefault().Description;
            city.Weather.Main = cityDto.Weather.FirstOrDefault().Main;
            city.LastUpdate = cityDto.LastUpdate;
        }
    }
}