using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace PapaStreet.WebUI.ServiceFacades
{
    public class CommonServiceFacade
    {
        public byte[] ConvertImage(HttpPostedFileBase postedFileBase)
        {
            try
            {
                byte[] data;
                using (Stream inputStream = postedFileBase.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }
                return data;
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        public byte[] ResizeImage(HttpPostedFileBase file)
        {
            try
            {
                WebImage img = new WebImage(file.InputStream);
                img.Resize(300, 300, false, false);
                return img.GetBytes();
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }
    }
}