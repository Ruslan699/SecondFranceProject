using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.Security
{
    public class CustomIdentity
    {
        public static UserDto User
        {
            get { return HttpContext.Current.Session["User"] as UserDto; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        public static bool IsAuthenticated => (HttpContext.Current.Session["User"] != null);
        public static void Logout() => User = null;
    }
}