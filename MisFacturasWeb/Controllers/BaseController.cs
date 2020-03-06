using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.Authorization;
using SecurityModel;
using SerilogLogger.Interface;

namespace MisFacturasWeb.Controllers
{
 
    [AuthorizationFilterOverride]
    public class BaseController : Controller
    {
        private const string SessionKeyName = "SessionUser";
        private const string SessionKeyNameExternal = "SessionUserExternal";
        private const string SessionKeyShowLayout = "ShowLayout";
        public readonly IEvenLog _logger;

        public BaseController(IEvenLog logger)
        {
            _logger = logger;
        }
        private static UserAccess UserInfo { get; set; }


        public UserAccess InfoUser
        {
            get
            {
                Boolean sessionInteral;
                string sessionInteralString = HttpContext.Session.GetString(SessionKeyShowLayout);
                if (UserInfo == null)
                {
                    if (!string.IsNullOrWhiteSpace(sessionInteralString))
                    {
                        if (Boolean.TryParse(sessionInteralString, out sessionInteral))
                        {
                            switch (sessionInteral)
                            {
                                case true:
                                    UserInfo = ConvertData.FromByteArrayToObject<UserAccess>(HttpContext.Session.Get(SessionKeyName));
                                    break;
                                case false:
                                    UserInfo = ConvertData.FromByteArrayToObject<UserAccess>(HttpContext.Session.Get(SessionKeyNameExternal));
                                    break;
                            }
                        }
                    }
                }
                return UserInfo;
            }
        }
    }
}