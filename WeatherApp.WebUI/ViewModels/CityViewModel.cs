using System.ComponentModel.DataAnnotations;

namespace WeatherApp.WebUI.ViewModels
{
    public class CityViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string CityName { get; set; }
    }
}