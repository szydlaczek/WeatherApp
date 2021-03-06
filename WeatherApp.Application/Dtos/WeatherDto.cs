﻿using Newtonsoft.Json;

namespace WeatherApp.Application.Dtos
{
    public class WeatherDto
    {
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}