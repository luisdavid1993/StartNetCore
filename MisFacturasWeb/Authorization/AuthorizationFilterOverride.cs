using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SecurityBussines.User;
using SecurityBussines.User.Iuser;

namespace MisFacturasWeb.Authorization
{
    public class AuthorizationFilterOverride : Attribute, IAuthorizationFilter
    {
        public const string SessionKeyName = "jwToken";
        private Isecurity _security;
        public AuthorizationFilterOverride()
        {
            this._security = new BussinesSecurity(); //security[0];
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Authenticator localAuthenticator = new Authenticator(_security, context);
            localAuthenticator.UserAutenticationControl();
        }
    }
}