using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityBussines.User.Iuser
{
  public  interface Isecurity
    {
        bool ValidateToken(int CompanyId, string token, string appId);
        SecurityModel.UserAccess ValidateToken(int CompanyId, string token);
    }
}
