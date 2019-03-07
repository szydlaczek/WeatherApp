namespace WeatherApp.Domain.Entities
{
    public class Main
    {
        public int MainId { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}