using System;
using common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MisFacturasWeb.Models;
using MisFacturasWeb.TokenProvider;
using SecurityBussines.Authenticator.IAuthenticator;
using SecurityModel;

namespace MisFacturasWeb.Controllers
{
    public class LoginController: Controller
    {
        public const string SessionKeyName = "SessionUser";
        public const string SessionKeyAppId = "EINVO";
        private IAuthenticatorBussines authenticatorBussines;
        public LoginController(IAuthenticatorBussines _authenticatorBussines)
        {
            this.authenticatorBussines = _authenticatorBussines;
        }
        public IActionResult Loggin()
        {
            if (HttpContext.Session.Get(SessionKeyName) != null)
            {
                HttpContext.Session.Clear();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Loggin(LogginModel logg)
        {
            UserAccess userAccess = authenticatorBussines.AutenticateUser(logg.Username, logg.Password, SessionKeyAppId);
            if (userAccess != null && !string.IsNullOrEmpty(userAccess.TokenSession) && userAccess.User.CompanyId.HasValue)
            {
                byte[] sessionUser = ConvertData.FromObjectToArrayByte(userAccess);
                HttpContext.Session.Set(SessionKeyName, sessionUser);
                return RedirectToAction("Index", "Home", null);
            }
            return View();
        }
    }
}