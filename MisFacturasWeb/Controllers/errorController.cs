using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.Models;

namespace MisFacturasWeb.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult Handling()
        {
            //var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //Type typeMisFacturasException = typeof(MisFacturasException);
            //Type typeExceptionHandler = exceptionHandlerPathFeature?.Error.GetType();
            //if (typeExceptionHandler == typeMisFacturasException)
            //{
            //    MisFacturasException misFacturasException = (MisFacturasException)exceptionHandlerPathFeature?.Error;
            //    _ = misFacturasException.UserMessage;
            //}
            //else
            //{
            //    _ = Settings.getValue("AppSettings", "MensajeError");
            //}
            //string msg = exceptionHandlerPathFeature?.Error.ToString();
            return View();
        }
    }
}