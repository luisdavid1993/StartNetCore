using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Security.Repositoty;
using SecurityBussines.Iuser;

namespace SecurityBussines.User
{
  public class BussinesSecurity: Isecurity
    {
        public bool ValidateToken(int CompanyId, string token, string appId)
        {
            UserRepository usrRepository = new UserRepository();
           return  usrRepository.ValidToken(CompanyId,token,appId).Result;
        }

    }
}
