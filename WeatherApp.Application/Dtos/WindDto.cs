using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Application.Dtos
{
    public class WindDto
    {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }        
    }
}
