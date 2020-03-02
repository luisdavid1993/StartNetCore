using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MisFacturasWeb.Models;
using MisFacturasWeb.TokenProvider;

namespace MisFacturasWeb.Controllers
{
    public class LoginController: Controller
    {
        public const string SessionKeyName = "jwToken";
        public const string SessionKeyNameExternal = "jwTokenExternal";
        public const string SessionKeyCompany = "CompanyId";
        private IConfiguration configuration;
        public LoginController(IConfiguration iConfig)
        {
            this.configuration = iConfig;
        }
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.Remove(SessionKeyName);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(ErrorViewModel error)
        {
            string token = configuration.GetSection("MySettings").GetSection("tokenJwt").Value;
            int CompanyId = System.Convert.ToInt32(configuration.GetSection("MySettings").GetSection("CompanyId").Value.ToString());
            
            HttpContext.Session.SetString(SessionKeyName,token);
            HttpContext.Session.SetInt32(SessionKeyCompany, CompanyId);
            return RedirectToAction("Index", "Home", null);
        }
    }
}