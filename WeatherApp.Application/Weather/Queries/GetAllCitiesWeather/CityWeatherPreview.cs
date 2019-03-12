using System;
using System.Linq.Expressions;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Weather.Queries.GetAllCitiesWeather
{
    public class CityWeatherPreview
    {
        public string Name { get; set; }

        public int ApiId { get; set; }

        public MainPreview Main { get; set; }

        public WeatherPreview Weather { get; set; }

        public WindPreview Wind { get; set; }

        public DateTime LastUpdate { get; set; }

        public static Expression<Func<City, CityWeatherPreview>> Projection
        {
            get
            {
                return c => new CityWeatherPreview
                {
                    LastUpdate = c.LastUpdate,
                    Name = c.Name,
                    Main = new MainPreview
                    {
                        Humidity = c.Main.Humidity,
                        Pressure = c.Main.Pressure,
                        Temperature = c.Main.Temperature
                    },
                    Weather = new WeatherPreview
                    {
                        Description = c.Weather.Description,
                        Main = c.Weather.Main
                    },
                    Wind = new WindPreview
                    {
                        Speed = c.Wind.Speed
                    }
                };
            }
        }

        public static CityWeatherPreview Create(City city)
        {
            return Projection.Compile().Invoke(city);
        }
    }
}