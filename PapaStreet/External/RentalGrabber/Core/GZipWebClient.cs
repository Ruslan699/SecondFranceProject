using System;
using System.Net;

namespace SiteGrabber.Core
{
    class GZipWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            if (base.GetWebRequest(address) is HttpWebRequest request)
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }
            return null;
        }
    }
}