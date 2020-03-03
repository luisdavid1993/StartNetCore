using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityBussines.Authenticator.IAuthenticator
{
   public interface IAuthenticatorBussines
    {
        SecurityModel.UserAccess AutenticateUser(string userName, string password, string appId);
    }
}
