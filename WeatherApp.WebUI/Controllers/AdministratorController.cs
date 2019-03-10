using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Application.Cities.Commands.AddCity;
using WeatherApp.Application.Cities.Commands.UpdateCity;
using WeatherApp.Application.Weather.Commands.AddCity;

namespace WeatherApp.WebUI.Controllers
{
    [Authorize]
    public class AdministratorController : BaseController
    {
        public AdministratorController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddCity()
        {
            var command = new UpdateWeatherCommand();
            var result = await _mediator.Send(command);
            return PartialView();
        }
    }
}