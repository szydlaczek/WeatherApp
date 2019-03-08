using MediatR;

namespace WeatherApp.Application.Weather.Queries.GetWeatherDetail
{
    public class GetWeatherDetailQuery : IRequest<WeatherDetailPreview>
    {
        public int CityId { get; set; }
    }
}