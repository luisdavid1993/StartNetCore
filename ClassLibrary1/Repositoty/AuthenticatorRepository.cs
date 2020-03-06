using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AuthenticatorWcf;
using common;
using Proxy.Base;
using SecurityModel;

namespace Proxy.Security.Repositoty
{
  public  class AuthenticatorRepository : BaseServices<IAuthenticatorChannel>
    {
        public async Task<SecurityModel.UserAccess> AutenticateUser(string userName, string password, string appId)
        {
            SecurityModel.UserAccess userAccess = null;
                HttpConfigureServices httpConfigureServices = ClientProxySettings.getValue("AuthenticatorClientServices"); 
                SetHTTP(httpConfigureServices);
                using (var serviceProxy = ChannelFactoryRelay.CreateChannel())
                {
                    AuthenticatorWcf.UserAccess userAccessWcf = await serviceProxy.AutenticateUserAsync(userName, password, appId, false);
                    userAccess= Mappers.MapUserAccess(userAccessWcf);
                }
            return userAccess;
        }
    }
}
