using Mapster;
using System.Linq;
using WeatherApp.Application.Dtos;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Adapter
{
    public class WeatherDtoAdapterConfig
    {
        public static TypeAdapterConfig GetConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<CityWeatherDto, City>()
                .Map(dest => dest.Weather, src => src.Weather.FirstOrDefault());
            return config;
        }
    }
}