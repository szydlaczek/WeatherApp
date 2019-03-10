using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}