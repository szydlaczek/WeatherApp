using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WeatherApp.Application.Exceptions;
using WeatherApp.WebUI.Extensions;

namespace WeatherApp.WebUI.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                if (context.Exception is ItemExistsException)
                {
                    code = HttpStatusCode.BadRequest;
                    context.Result = new JsonResult(new
                    {
                        errors = new[] { context.Exception.Message }
                        //stackTrace = context.Exception.StackTrace
                    });
                };
                context.HttpContext.Response.StatusCode = (int)code;
            }
        }
    }
}