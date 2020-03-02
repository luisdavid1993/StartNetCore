using System;
using Microsoft.AspNetCore.Mvc.Filters;
using MisFacturasWeb.TokenProvider.Event;
using SecurityBussines.Iuser;
using SecurityBussines.User;

namespace MisFacturasWeb.TokenProvider
{
    public class JwtAuthentication : Attribute, IActionFilter
    {
        public const string SessionKeyName = "jwToken";
        private Isecurity _security;
        public JwtAuthentication()
        {
            this._security = new BussinesSecurity(); //security[0];
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            LocalAuthenticator localAuthenticator = new LocalAuthenticator(_security, context);
            localAuthenticator.UserAutenticationControl();

        }
    }
}