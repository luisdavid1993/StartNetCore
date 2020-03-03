using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Security.Repositoty
{
  public static  class Mappers
    {
        public static SecurityModel.UserAccess MapUserAccess(AuthenticatorWcf.UserAccess userAccessWcf)
        {
            if (userAccessWcf != null && !string.IsNullOrEmpty(userAccessWcf.TokenSession) && userAccessWcf.User.CompanyId.HasValue)
            {
                SecurityModel.UserAccess userAccess = new SecurityModel.UserAccess();
                userAccess.TokenSession = userAccessWcf.TokenSession;
                userAccess.User.CompanyId = userAccessWcf.User.CompanyId;
                return userAccess;
            }
            else
            {
                return null;
            }
        }

        public static SecurityModel.UserAccess MapUsersWcf(UsersWcf.UserAccess userAccessWcf, string token)
        {
            if (userAccessWcf != null  && userAccessWcf.User.CompanyId.HasValue)
            {
                SecurityModel.UserAccess userAccess = new SecurityModel.UserAccess();
                userAccess.TokenSession = token;
                userAccess.User.CompanyId = userAccessWcf.User.CompanyId;
                return userAccess;
            }
            else
            {
                return null;
            }
        }
    }
}
