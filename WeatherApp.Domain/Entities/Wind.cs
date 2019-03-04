using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Domain.Entities
{
    public class Wind
    {
        public int WindId { get; set; }
        public double Speed { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
