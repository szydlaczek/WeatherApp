using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Application.Users.Commands.SignUpUser;
using WeatherApp.Domain.Entities;

namespace WeatherApp.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        UserManager<User> _manager;
        public AccountController(IMediator mediator, UserManager<User> manager) : base(mediator)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Login()
        {
            //var result=await _manager.CreateAsync(new Domain.Entities.User { Id = Guid.NewGuid().ToString(), Email = "szydlak@gmail.com", UserName = "szydlo.grzegorz" }, "123456");
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