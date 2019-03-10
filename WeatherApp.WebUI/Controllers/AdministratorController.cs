using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AddCity()
        {
            return PartialView();
        }
    }
}