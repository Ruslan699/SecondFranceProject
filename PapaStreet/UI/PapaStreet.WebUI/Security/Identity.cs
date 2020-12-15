using PapaStreet.BLL.DTOs;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.Security
{
    public class Identity
    {
        public static CustomerDto Customer
        {
            get { return HttpContext.Current.Session["Customer"] as CustomerDto; }
            set { HttpContext.Current.Session["Customer"] = value; }
        }

        public static CustomerDto RegisterCustomer
        {
            get { return HttpContext.Current.Session["RegisterCustomer"] as CustomerDto; }
            set { HttpContext.Current.Session["RegisterCustomer"] = value; }
        }

        public static bool IsAuthenticated => (HttpContext.Current.Session["Customer"] != null);
        public static void Logout() => Customer = null;
    }
}