using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3.Components
{
    public class CookieWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
        public CookieWebClient()
        {
            CookieContainer = new CookieContainer();
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null) return base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }
    }
}
