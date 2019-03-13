using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Application.Cities.Commands.AddCity;
using WeatherApp.Application.Cities.Commands.UpdateCity;
using WeatherApp.Application.Weather.Queries.GetAllCitiesWeather;
using WeatherApp.WebUI.ViewModels;

namespace WeatherApp.WebUI.Controllers
{
    [Authorize]
    public class AdministratorController : BaseController
    {
        public AdministratorController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllCitiesWeatherQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityViewModel viewModel)
        {
            var command = new AddCityCommand() { CityName = viewModel.CityName };
            var response = await _mediator.Send(command);
            if (response.Errors.Any())
                return BadRequest(response);
            else
                return PartialView("_WeatherItem", response.Result);
        }

        public async Task<IActionResult> UpdateCity()
        {
            var command = new UpdateWeatherCommand();
            var response = await _mediator.Send(command);
            return Ok();
        }
    }
}