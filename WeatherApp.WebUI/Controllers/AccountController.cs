using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Application.Users.Commands.SignUpUser;

namespace WeatherApp.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(AdministratorController.Index), typeof(AdministratorController).Name.Replace("Controller", string.Empty));
            return View();
        }

        [HttpPost]
        [Filters.ModelStateValidationFilter]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Errors.Any())
                return RedirectToAction(nameof(AdministratorController.Index), typeof(AdministratorController).Name.Replace("Controller", string.Empty));
            else
            {
                ModelState.AddModelError("login", result.Errors.FirstOrDefault());
                return View();
            }
        }
    }
}