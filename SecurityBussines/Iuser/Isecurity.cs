using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityBussines.Iuser
{
  public  interface Isecurity
    {
        bool ValidateToken(int CompanyId, string token, string appId);
    }
}
