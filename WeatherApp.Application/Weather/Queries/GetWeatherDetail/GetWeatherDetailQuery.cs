using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Application.Weather.Queries.GetWeatherDetail
{
    public class GetWeatherDetailQuery : IRequest<WeatherDetailPreview>
    {
        public int CityId { get; set; }
    }
}
