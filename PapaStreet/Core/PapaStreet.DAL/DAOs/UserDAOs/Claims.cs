using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DAOs
{
   public static class Claims
    {
        public static string FullName => "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/fullname";
        public static string PhoneNumber => "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/phonenumber";
    }
}
