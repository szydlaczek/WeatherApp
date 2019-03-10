using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public WeatherService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task<ICollection<CityWeatherDto>> GetCitiesWeather(List<string> citiesNames)
        {
            List<CityWeatherDto> list = new List<CityWeatherDto>();

            foreach(string city in citiesNames)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 4);
                    var result = await client.GetAsync(CreateURL(city));
                    var jsonResult = await result.Content.ReadAsStringAsync();
                    CityWeatherDto cityWeather = JsonConvert.DeserializeObject<CityWeatherDto>(jsonResult);
                    list.Add(cityWeather);
                }
            }
            return list;
        }

        private string CreateURL(string city)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://");
            sb.Append(_apiSettings.Value.ApiPath);
            sb.Append(city);
            sb.Append("&");
            sb.Append("appid=");
            sb.Append(_apiSettings.Value.Key);
            return sb.ToString();               
        }
    }
}