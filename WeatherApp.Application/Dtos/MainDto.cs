using Newtonsoft.Json;

namespace WeatherApp.Application.Dtos
{
    public class MainDto
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
    }
}