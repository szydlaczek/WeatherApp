using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WeatherApp.Application.Weather.Queries.GetAllCitiesWeather;
using WeatherApp.WebUI.Models;

namespace WeatherApp.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllCitiesWeatherQuery());
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}