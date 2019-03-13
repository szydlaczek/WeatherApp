using Newtonsoft.Json;

namespace WeatherApp.Application.Dtos
{
    public class WindDto
    {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
    }
}