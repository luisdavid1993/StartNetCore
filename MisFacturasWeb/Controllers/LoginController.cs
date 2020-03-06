using System;
using common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MisFacturasWeb.Models;
using SecurityBussines.Authenticator.IAuthenticator;
using SecurityModel;
using SerilogLogger.Interface;

namespace MisFacturasWeb.Controllers
{
    public class LoginController : Controller
    {
        public const string SessionKeyName = "SessionUser";
        public const string SessionKeyAppId = "EINVO";
        public const string TempLoginFail = "TempLoginFail";
        private readonly IAuthenticatorBussines  authenticatorBussines;
        public readonly IEvenLog _logger;
        public LoginController(IAuthenticatorBussines _authenticatorBussines, IEvenLog logger)
        {
            _logger = logger;
            this.authenticatorBussines = _authenticatorBussines;
        }
        public IActionResult Loggin()
        {
            HttpContext.Session.Clear();
            if (TempData[TempLoginFail] != null)
                ViewBag.TempLoginFail = true;
            return View();
        }
        [HttpPost]
        public IActionResult Loggin(LogginModel logg)
        {
            try
            {
                UserAccess userAccess = authenticatorBussines.AutenticateUser(logg.Username, logg.Password, SessionKeyAppId);
                if (userAccess != null && !string.IsNullOrEmpty(userAccess.TokenSession) && userAccess.User.CompanyId.HasValue)
                {
                    byte[] sessionUser = ConvertData.FromObjectToArrayByte(userAccess);
                    HttpContext.Session.Set(SessionKeyName, sessionUser);
                    return RedirectToAction("Index", "Home", null);
                }
            }
            catch (Exception ex)
            {
                string message = "LoginController : " + ex.ToString();
                ViewBag.ErrorMesage = _logger.Error(message, "No se puede realizar el loggin", "LoginController");
            }
            TempData[TempLoginFail] = true;
            return RedirectToAction("Loggin");
        }
    }
}