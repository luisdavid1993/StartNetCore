using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using SecurityBussines.Iuser;

namespace MisFacturasWeb.TokenProvider.Event
{
    public class LocalAuthenticator
    {
        private ActionExecutingContext ContextApp;
        public const string SessionKeyName = "jwToken";
        public const string SessionKeyNameExternal = "jwTokenExternal";
        public const string SessionKeyCompany = "CompanyId";
        public const string SessionKeyAppId = "EINVO";
        public const string SessionKeyShowLayout = "ShowLayout";
        public const string SessionKeyCompanyContext = "CompanyContext";
        public const string HeaderPeticionFrom = "sec-fetch-dest";
        public const string HeaderFromIframe = "iframe";
        private HttpContext request;
        private Isecurity _security;
        public LocalAuthenticator(Isecurity security, ActionExecutingContext ContexIn)
        {
            this.ContextApp = ContexIn;
            request = this.ContextApp.HttpContext;
            this._security = security;
        }

        public void UserAutenticationControl()
        {
            if (twoSessionsActives()){
                deleteIfTwoSessionsActives();
            }
            if (isSessionExternal()){
                CaseSessionExternal();
            }else if (isSessionInternal()){
                CaseSessionInternal();
            }
            else {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }

        }
        private void CaseSessionInternal()
        {
            if (!requestIsFromPrincipal())
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else
            {
                LocalContext();
            }
        }
        private void CaseSessionExternal()
        {
            if (requestIsFromPrincipal())
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else
            {
                ValidateExternal();
            }
        }

        private void deleteIfTwoSessionsActives()
        {
                if (requestIsFromPrincipal())
                {
                    request.Session.Remove(SessionKeyNameExternal);
                }
                else
                {
                    request.Session.Remove(SessionKeyName);
                }
        }

        private void ValidateExternal()
        {
            int companyId = 0;
            string tokenLogin = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Request.Query[SessionKeyName].ToString()))
            {
                tokenLogin = request.Request.Query[SessionKeyName].ToString();
                companyId = ConvertNumeric(request.Request.Query[SessionKeyCompany].ToString());
            }
            if (string.IsNullOrWhiteSpace(tokenLogin))
            {
                tokenLogin = ContextApp.HttpContext.Session.GetString(SessionKeyNameExternal);
                companyId = ContextApp.HttpContext.Session.GetInt32(SessionKeyCompany) == null ? 0 : ContextApp.HttpContext.Session.GetInt32(SessionKeyCompany).Value;
            }
            bool isValid = _security.ValidateToken(companyId, tokenLogin, SessionKeyAppId);
            if (!isValid)
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else
            {
                List<Claim> claims = new List<Claim>
                      {
                       new Claim(ClaimTypes.Authentication, tokenLogin),
                       new Claim(SessionKeyCompany, companyId.ToString()),
                       new Claim(SessionKeyShowLayout, "false")

                     };
                ClaimsIdentity identity = new ClaimsIdentity(claims, SessionKeyCompanyContext);
                ClaimsPrincipal user = new ClaimsPrincipal(identity);
                ContextApp.HttpContext.User = user;
                ContextApp.HttpContext.Session.SetString(SessionKeyNameExternal, tokenLogin);
                ContextApp.HttpContext.Session.SetInt32(SessionKeyCompany, companyId);
                return;
            }
        }

        private void LocalContext()
        {

            if (request.User.Claims.Any())
            {
                ClaimsPrincipal userContex = request.User;
                return;
            }
            else if (!string.IsNullOrEmpty(request.Session.GetString(SessionKeyName)))
            {
                string token = request.Session.GetString(SessionKeyName);
                int companyId = ContextApp.HttpContext.Session.GetInt32(SessionKeyCompany) == null ? 0 : ContextApp.HttpContext.Session.GetInt32(SessionKeyCompany).Value;
                bool isValid = _security.ValidateToken(companyId, token, SessionKeyAppId);
                if (!isValid)
                {
                    request.Session.Remove(SessionKeyName);
                    ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }
                else
                {
                    List<Claim> claims = new List<Claim>
                      {
                       new Claim(ClaimTypes.Authentication, token.ToString()),
                       new Claim(SessionKeyCompany, companyId.ToString()),
                       new Claim(SessionKeyShowLayout, "true")

                     };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, SessionKeyCompanyContext);
                    ClaimsPrincipal user = new ClaimsPrincipal(identity);
                    ContextApp.HttpContext.User = user;
                    return;
                }
            }
            else
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }

        private int ConvertNumeric(object num)
        {
            int numRetorno = 0;
            try
            {
                numRetorno = Convert.ToInt32(num.ToString());
            }
            catch
            {
                numRetorno = 0;
            }
            return numRetorno;
        }

        private string getValue(string seccion, string key)
        {
            try
            {
                IConfigurationBuilder _config;
                IConfigurationRoot root;
                IConfigurationSection rootSection;
                _config = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                _config.AddJsonFile(path, false);
                root = _config.Build();
                rootSection = root.GetSection(seccion);
                string valueReturn = string.Empty;
                string value = rootSection.GetSection(key).Value.ToString();

                return value;
            }
            catch
            {
                return string.Empty;
            }
        }

        private Boolean twoSessionsActives()
        {
            return !string.IsNullOrEmpty(request.Session.GetString(SessionKeyName)) && !string.IsNullOrEmpty(request.Session.GetString(SessionKeyNameExternal));
        }

        private Boolean requestIsFromPrincipal()
        {
            return !request.Request.Headers[HeaderPeticionFrom].ToString().Contains(HeaderFromIframe);
        }

        private Boolean isSessionInternal()
        {
            return !string.IsNullOrEmpty(request.Session.GetString(SessionKeyName));
        }

        private Boolean isSessionExternal()
        {
            return !string.IsNullOrWhiteSpace(request.Request.Query[SessionKeyName].ToString()) || !string.IsNullOrEmpty(request.Session.GetString(SessionKeyNameExternal));
        }
    }
}
