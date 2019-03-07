namespace WeatherApp.Domain.Entities
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}