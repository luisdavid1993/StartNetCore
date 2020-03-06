using System;
using System.Collections.Generic;
using System.Security.Claims;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using SecurityBussines.User.Iuser;
using SecurityModel;

namespace MisFacturasWeb.Authorization
{
    public class Authenticator
    {
        private readonly AuthorizationFilterContext ContextApp;
        private const string SessionKeyName = "SessionUser";
        private const string HeaderKeyName = "jwToken";
        private const string SessionKeyNameExternal = "SessionUserExternal";
        private const string HeaderKeyCompany = "CompanyId";
        private const string SessionKeyAppId = "EINVO";
        private const string SessionKeyShowLayout = "ShowLayout";
        private const string HeaderPeticionFrom = "sec-fetch-dest";
        private const string HeaderFromIframe = "iframe";
        private readonly HttpContext request;
        private readonly Isecurity _security;
        public Authenticator(Isecurity security, AuthorizationFilterContext ContexIn)
        {
            this.ContextApp = ContexIn;
            request = this.ContextApp.HttpContext;
            this._security = security;
        }
        public void UserAutenticationControl()
        {
            if (RequestIsFromPrincipal()) {
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
                    ContextApp.HttpContext.Session.SetString(SessionKeyShowLayout, "false");
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
                    ContextApp.HttpContext.Session.SetString(SessionKeyShowLayout, "true");
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
                    ContextApp.HttpContext.Session.SetString(SessionKeyShowLayout, "false");
                }
            }
            else
            {
                ContextApp.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Loggin" }));
            }
        }

        private int ConvertNumeric(object num)
        {
            try
            {
                if (int.TryParse(num.ToString(), out int numRetorno))
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
        private Boolean RequestIsFromPrincipal()
        {
            return !request.Request.Headers[HeaderPeticionFrom].ToString().Contains(HeaderFromIframe);
        }
    }
}
