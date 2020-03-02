using System;
using System.Threading.Tasks;
using Proxy.Base;
using SecurityModel;
using UsersWcf;


namespace Proxy.Security.Repositoty
{
    public class UserRepository: BaseServices<IUsersChannel>
    {
        public UserRepository()
        {

        }
        public async Task<bool> ValidToken(int CompanyId, string token, string appId)
        {
            bool isValid = false;
            try
            {
                string endPointString = ClientProxySettings.getValue("UsersClientSettings", "UserWcfEndPoint");
                HttpConfigureServices httpConfigureServices = new HttpConfigureServices();
                httpConfigureServices.endpointUrl= endPointString;
                SetHTTP(httpConfigureServices);
                using (var serviceProxy = ChannelFactoryRelay.CreateChannel())
                {
                    var infoToken = await serviceProxy.GetUserAccessAsync(CompanyId, token, appId);
                    if (infoToken != null)
                    {
                        isValid = true;
                    }
                }

            } catch
            {
                isValid = false;
            }
            return isValid;
        }


    }
}
