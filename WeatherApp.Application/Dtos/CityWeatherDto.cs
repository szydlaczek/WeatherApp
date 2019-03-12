using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherApp.Application.Dtos
{
    public class CityWeatherDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int ApiId { get; set; }

        [JsonProperty(PropertyName = "main")]
        public MainDto Main { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public ICollection<WeatherDto> Weather { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public WindDto Wind { get; set; }

        public DateTime LastUpdate { get; private set; } = DateTime.Now;
    }
}