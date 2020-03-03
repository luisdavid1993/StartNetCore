using Proxy.Security.Repositoty;
using SecurityBussines.User.Iuser;

namespace SecurityBussines.User
{
  public class BussinesSecurity: Isecurity
    {
        public bool ValidateToken(int CompanyId, string token, string appId)
        {
            UserRepository usrRepository = new UserRepository();
           return  usrRepository.ValidToken(CompanyId,token,appId).Result;
        }
        public SecurityModel.UserAccess ValidateToken(int CompanyId, string token)
        {
            UserRepository usrRepository = new UserRepository();
            return usrRepository.ValidToken(CompanyId, token).Result;
        }

    }
}
