using System;
using System.Collections.Generic;
using System.Linq;
using common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisFacturasWeb.Models;
using SecurityModel;

namespace MisFacturasWeb.Components.SidebarComponent
{
    public class LeftSidebarViewComponent : ViewComponent
    {
        private static UserAccess UserInfoView { get; set; }
        private const string SessionKeyName = "SessionUser";
        private const string SessionKeyNameExternal = "SessionUserExternal";
        private const string SessionKeyShowLayout = "ShowLayout";
        public IViewComponentResult Invoke()
        {
            LeftSidebarModel leftSidebarModel = new LeftSidebarModel();
            string sessionInteralString = HttpContext.Session.GetString(SessionKeyShowLayout);
            if (UserInfoView == null)
            {
                if (!string.IsNullOrWhiteSpace(sessionInteralString))
                {
                    if (Boolean.TryParse(sessionInteralString, out bool sessionInteral))
                    {
                        switch (sessionInteral)
                        {
                            case true:
                                UserInfoView = ConvertData.FromByteArrayToObject<UserAccess>(HttpContext.Session.Get(SessionKeyName));
                                break;
                            case false:
                                UserInfoView = ConvertData.FromByteArrayToObject<UserAccess>(HttpContext.Session.Get(SessionKeyNameExternal));
                                break;
                        }
                    }
                }
            }
            leftSidebarModel.UserName = UserInfoView.User.FirstName;
            leftSidebarModel.Email = UserInfoView.User.Email;
            if (UserInfoView.ListRoles.Count > 0)
            {
                List<Module> module = UserInfoView.ListRoles.FirstOrDefault().ListModules;
                foreach (Module item in  module)
                {
                    leftSidebarModel.UrlMenu.Add(item.URL);
                }
            }
            return View(leftSidebarModel);
        }
    }
}