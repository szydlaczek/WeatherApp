using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebUI.ViewModels
{
    public class CityViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string CityName { get; set; }
    }
}
