using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PapaStreet.Common.Helpers
{
    public static class ConvertHelper
    {
        public static byte[] ToBinary(HttpPostedFileBase httpPostedFileBase )
        {
            MemoryStream target = new MemoryStream();
            httpPostedFileBase.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }
    }
}
