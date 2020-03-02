using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.TokenProvider.Event;

namespace MisFacturasWeb.Controllers
{
    public class BaseController : Controller
    {
        protected string CompanyId
        {
            get
            {
                return getContext("CompanyId");
            }
        }

        protected Boolean ShowLayout
        {
            get
            {
                if (getContext("ShowLayout") == "")
                {
                    return true;
                }
                else {
                    return Convert.ToBoolean(getContext("ShowLayout"));
                }
               
            }
        }
        
        public string getContext(string keyContext)
        {
            string ValueCotext = "";
            if (HttpContext.User.Claims != null && HttpContext.User.Claims.Any())
            {
                ValueCotext = HttpContext.User.Claims.ToList().Where(x => x.Type == keyContext).FirstOrDefault().Value;
            }
            return ValueCotext;
        }


    }
}