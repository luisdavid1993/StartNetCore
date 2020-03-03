using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MisFacturasWeb.Models;
using MisFacturasWeb.TokenProvider;
using SecurityBussines.User.Iuser;

namespace MisFacturasWeb.Controllers
{
    public class HomeController: BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private static Isecurity _security;
        public HomeController(ILogger<HomeController> logger, Isecurity security)
        {
            _security = security;
            _logger = logger;
        }
        [JwtAuthentication]
        public IActionResult Index()
        {
            var context = HttpContext;
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}