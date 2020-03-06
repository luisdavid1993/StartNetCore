using System;
using System.Collections.Generic;
using System.Text;
using common;
using Proxy.Security.Repositoty;
using SecurityBussines.Authenticator.IAuthenticator;
using SecurityModel;

namespace SecurityBussines.Authenticator
{
    public class AuthenticatorBussines : IAuthenticatorBussines
    {
        public UserAccess AutenticateUser(string userName, string password, string appId)
        {
                AuthenticatorRepository authenticatorRepository = new AuthenticatorRepository();
                return authenticatorRepository.AutenticateUser(userName, password, appId).Result;
        }
    }
}
