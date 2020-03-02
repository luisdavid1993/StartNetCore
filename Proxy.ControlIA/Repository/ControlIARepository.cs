using System;
using System.Threading.Tasks;
using ControlIA;
using Proxy.Base;

namespace Proxy.ControlIA.Repository
{
    public class ControlIARepository
    {

        public async Task<bool> ExistsSoftware(string username)
        {
            try
            {
                bool result = false;
                ControlIAClient client = new ControlIAClient(ControlIAClient.EndpointConfiguration.BasicHttpBinding_IControlIA);
                await client.OpenAsync();
                result = await client.ExistsSoftwareAsync(username);
                await client.CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int IsValidSoftwareToCompany(string username, string prmSchemaID, string prmNumberID)
        {
            try
            {
                int result = 0;
                ControlIAClient client = new ControlIAClient();
                client.OpenAsync();
                result = client.IsValidSoftwareToCompanyAsync(username, prmSchemaID, prmNumberID).Result;
                client.CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
