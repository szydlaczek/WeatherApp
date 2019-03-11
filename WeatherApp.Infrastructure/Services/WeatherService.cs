using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.Dtos;
using WeatherApp.Application.Interfaces;
using WeatherApp.Infrastructure.Helpers;

namespace WeatherApp.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IOptions<ApiSettings> _apiSettings;

        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }

        public WeatherService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings;
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public async Task<CityWeatherDto> GetWeather(string cityName)
        {
            CityWeatherDto cityWeather = null;
            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 4);
                var result = await client.GetAsync(CreateURL(cityName));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = await result.Content.ReadAsStringAsync();
                    cityWeather = JsonConvert.DeserializeObject<CityWeatherDto>(jsonResult);

                }
                else
                    _messages.Add($"Cannot download data for city {cityName}");
            }
            return cityWeather;
        }

        private string CreateURL(string city)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(_apiSettings.Value.ApiPath);
            city = city.Replace(" ", String.Empty);
            sb.Append(city);
            sb.Append("&");
            sb.Append("appid=");
            sb.Append(_apiSettings.Value.Key);
            return sb.ToString();
        }

        
    }
}