using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using SecurityBussines.User.Iuser;
using SecurityModel;

namespace MisFacturasWeb.TokenProvider.Event
{
    public class LocalAuthenticator
    {
        private AuthorizationFilterContext ContextApp;
        public const string SessionKeyName = "SessionUser";
        public const string HeaderKeyName = "jwToken";
        public const string SessionKeyNameExternal = "SessionUserExternal";
        public const string HeaderKeyCompany = "CompanyId";
        public const string SessionKeyAppId = "EINVO";
        public const string SessionKeyShowLayout = "ShowLayout";
        public const string SessionKeyCompanyContext = "CompanyContext";
        public const string HeaderPeticionFrom = "sec-fetch-dest";
        public const string HeaderFromIframe = "iframe";
        private HttpContext request;
        private Isecurity _security;
        public LocalAuthenticator(Isecurity security, AuthorizationFilterContext ContexIn)
        {
            this.ContextApp = ContexIn;
            request = this.ContextApp.HttpContext;
            this._security = security;
        }
        public void UserAutenticationControl()
        {
            if (requestIsFromPrincipal()) {
                LocalContext();
            }
            else
            {
                ValidateExternal();

            }
           
        }
        private void ValidateExternal()
        {
            if (!string.IsNullOrWhiteSpace(request.Request.Query[HeaderKeyName].ToString()) && !string.IsNullOrWhiteSpace(request.Request.Query[HeaderKeyCompany].ToString()))
            {
                string tokenLogin = request.Request.Query[HeaderKeyName].ToString();
                int companyId = ConvertNumeric(request.Request.Query[HeaderKeyCompany].ToString());
                UserAccess isValidUser = _security.ValidateToken(companyId, tokenLogin);
                if (isValidUser != null && !string.IsNullOrEmpty(isValidUser.TokenSession) && isValidUser.User.CompanyId.HasValue)
                {
                    byte[] sessionUser = ConvertData.FromObjectToArrayByte(isValidUser);
                    ContextApp.HttpContext.Session.Set(SessionKeyNameExternal, sessionUser);
                    List<Claim> claims = new List<Claim>
                      {
                       new Claim(SessionKeyShowLayout, "false")

                     };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, SessionKeyCompanyContext);
                    ClaimsPrincipal user = new ClaimsPrincipal(identity);
                    ContextApp.HttpContext.User = user;
                }
                else
                {
                    ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
                }
            }
            else 
            {
                UserAccess userAccess = ConvertData.FromByteArrayToObject<UserAccess>(request.Session.Get(SessionKeyNameExternal));
                ExternalSession(userAccess);
            }
           
        }
        private void LocalContext()
        {
            UserAccess userAccess = ConvertData.FromByteArrayToObject<UserAccess>(request.Session.Get(SessionKeyName));
            if (userAccess!= null && !string.IsNullOrEmpty(userAccess.TokenSession) && userAccess.User.CompanyId.HasValue)
            {
                string token = userAccess.TokenSession;
                int companyId = userAccess.User.CompanyId.Value;
                bool isValid = _security.ValidateToken(companyId, token, SessionKeyAppId);
                if (!isValid)
                {
                    ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
                }
                else
                {
                    List<Claim> claims = new List<Claim>
                      {
                       new Claim(SessionKeyShowLayout, "true")

                     };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, SessionKeyCompanyContext);
                    ClaimsPrincipal user = new ClaimsPrincipal(identity);
                    ContextApp.HttpContext.User = user;
                }
            }
            else
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
            }
        }

        private void ExternalSession(UserAccess userAccess)
        { 
            if (userAccess != null && !string.IsNullOrEmpty(userAccess.TokenSession) && userAccess.User.CompanyId.HasValue)
            {
                string token = userAccess.TokenSession;
                int companyId = userAccess.User.CompanyId.Value;
                bool isValid = _security.ValidateToken(companyId, token, SessionKeyAppId);
                if (!isValid)
                {
                    ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
                }
                else
                {
                    List<Claim> claims = new List<Claim>
                      {
                       new Claim(SessionKeyShowLayout, "false")

                     };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, SessionKeyCompanyContext);
                    ClaimsPrincipal user = new ClaimsPrincipal(identity);
                    ContextApp.HttpContext.User = user;
                }
            }
            else
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
            }
        }

        private int ConvertNumeric(object num)
        {
            int numRetorno = 0;
            try
            {
                if (int.TryParse(num.ToString(), out numRetorno))
                {
                    return numRetorno;
                }
                else 
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        private Boolean requestIsFromPrincipal()
        {
            return !request.Request.Headers[HeaderPeticionFrom].ToString().Contains(HeaderFromIframe);
        }
    }
}
