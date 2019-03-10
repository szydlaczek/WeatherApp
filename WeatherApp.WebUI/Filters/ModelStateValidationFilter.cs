using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebUI.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;
                var model = context.ActionArguments?.Count > 0
                   ? context.ActionArguments.First().Value
                   : null;
                context.Result = (IActionResult)controller?.View(model)
                   ?? new BadRequestResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
