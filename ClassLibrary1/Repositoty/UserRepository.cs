using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Proxy.Base;
using SecurityModel;
using UsersWcf;


namespace Proxy.Security.Repositoty
{
    public class UserRepository : BaseServices<IUsersChannel>
    {
        public const string KeyAppId = "EINVO";
        public async Task<bool> ValidToken(int CompanyId, string token, string appId)
        {
            bool isValid = false;
            try
            {
                HttpConfigureServices httpConfigureServices = ClientProxySettings.getValue("UsersClient");
                SetHTTP(httpConfigureServices);
                using (var serviceProxy = ChannelFactoryRelay.CreateChannel())
                {
                    BasicDataRequest basicDataRequest = new BasicDataRequest();
                    basicDataRequest.IntId = CompanyId;
                    basicDataRequest.InvokeApp = appId;
                    basicDataRequest.Token = token;
                    UsersWcf.UserAccess userWcf = await serviceProxy.GetUserAccessByCompanyIDAsync(basicDataRequest);
                    if (userWcf != null &&  userWcf.User.CompanyId.HasValue)
                    {
                        isValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                string message = "UserRepository : " + ex.ToString();
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
            return isValid;
        }

        public async Task<SecurityModel.UserAccess> ValidToken(int CompanyId, string token)
        {
            SecurityModel.UserAccess userAccess = null;
            try
            {
                HttpConfigureServices httpConfigureServices = ClientProxySettings.getValue("UsersClient");
                SetHTTP(httpConfigureServices);
                using (var serviceProxy = ChannelFactoryRelay.CreateChannel())
                {
                    BasicDataRequest basicDataRequest = new BasicDataRequest();
                    basicDataRequest.IntId = CompanyId;
                    basicDataRequest.InvokeApp = KeyAppId;
                    basicDataRequest.Token = token;
                    UsersWcf.UserAccess userWcf = await serviceProxy.GetUserAccessByCompanyIDAsync(basicDataRequest);
                    userAccess = Mappers.MapUsersWcf(userWcf, token);
                }
            }
            catch
            {
            }
            return userAccess;
        }
    }
}
