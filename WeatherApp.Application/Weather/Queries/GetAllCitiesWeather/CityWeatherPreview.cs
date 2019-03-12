using System;

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
    }
}