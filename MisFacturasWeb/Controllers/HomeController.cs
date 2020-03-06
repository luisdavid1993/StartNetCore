using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MisFacturasWeb.Models;
using SecurityBussines.User.Iuser;
using SerilogLogger.Interface;
namespace MisFacturasWeb.Controllers
{
    public class HomeController: BaseController
    {
        private static Isecurity _security;
        public HomeController(IEvenLog _logger, Isecurity security):base(_logger)
        {
            _security = security;
        }
       
        public IActionResult Index()
        {
            try
            {
                var context = InfoUser;
            }
            catch (Exception ex)
            {
                string message = "AuthenticatorRepository : " + ex.ToString();
                ViewBag.ErrorMesage = _logger.Error(message,"No se pudo cargar la información","HomeController");
            }
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}