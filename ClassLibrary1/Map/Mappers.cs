using System;
using System.Collections.Generic;
using System.Linq;
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
                List<SecurityModel.Module> userAccessListModules = new List<SecurityModel.Module>();
                userAccess.TokenSession = userAccessWcf.TokenSession;
                userAccess.User.CompanyId = userAccessWcf.User.CompanyId;
                userAccess.User.FirstName = userAccessWcf.User.FirstName;
                userAccess.User.Email = userAccessWcf.User.Email;
                if (userAccessWcf.ListRoles.ToList().Count > 0 && userAccessWcf.ListRoles.ToList().FirstOrDefault().ListModules.ToList().Count >0)
                {
                    foreach (AuthenticatorWcf.Module item in userAccessWcf.ListRoles.ToList().FirstOrDefault().ListModules.ToList())
                    {
                        SecurityModel.Module module = new SecurityModel.Module();
                        module.ModuleId = item.ModuleId;
                        module.ModuleName = item.ModuleName;
                        module.RoleId = item.RoleId;
                        module.URL = item.URL;
                        userAccessListModules.Add(module);
                    }
                    userAccess.ListRoles.Add(new SecurityModel.Role());
                    userAccess.ListRoles.FirstOrDefault().ListModules = userAccessListModules;
                }
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
                List<SecurityModel.Module> userAccessListModules = new List<SecurityModel.Module>();
                userAccess.TokenSession = token;
                userAccess.User.CompanyId = userAccessWcf.User.CompanyId;
                userAccess.User.FirstName = userAccessWcf.User.FirstName;
                userAccess.User.Email = userAccessWcf.User.Email;
                if (userAccessWcf.ListRoles.ToList().Count > 0 && userAccessWcf.ListRoles.ToList().FirstOrDefault().ListModules.ToList().Count > 0)
                {
                    foreach (UsersWcf.Module item in userAccessWcf.ListRoles.ToList().FirstOrDefault().ListModules.ToList())
                    {
                        SecurityModel.Module module = new SecurityModel.Module();
                        module.ModuleId = item.ModuleId;
                        module.ModuleName = item.ModuleName;
                        module.RoleId = item.RoleId;
                        module.URL = item.URL;
                        userAccessListModules.Add(module);
                    }
                    userAccess.ListRoles.Add(new SecurityModel.Role());
                    userAccess.ListRoles.FirstOrDefault().ListModules = userAccessListModules;
                }
                return userAccess;
            }
            else
            {
                return null;
            }
        }
    }
}
