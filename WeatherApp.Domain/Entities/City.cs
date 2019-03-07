using System;

namespace WeatherApp.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApiId { get; set; }
        public Main Main { get; set; }
        public Weather Weather { get; set; }
        public Wind Wind { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}