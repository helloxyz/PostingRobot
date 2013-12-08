using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace PostingRobot.lib
{
    abstract class ClientSession : IClientSession
    {
        private string WebName;


        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostUrl { get; set; }
        public string LoginUrl { get; set; }
        public string PostUrl { get; set; }
        public HttpWebRequest Request { get; set; }

        public void GetCookieCollection()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {

        }

        public void Post()
        {
            throw new NotImplementedException();
        }

        protected CookieContainer GetCookie(HttpWebRequest request, CookieContainer cc, byte[] content)
        {
            if (cc != null)
            {
                request.CookieContainer = cc;
            }
            else
            {
                request.CookieContainer = new CookieContainer();
                cc = request.CookieContainer;
            }

            try
            {
                Stream stream = request.GetRequestStream();
                stream.Write(content, 0, content.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                //CookieCollection cook = response.Cookies;
                string CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
                // TODO  save cookiesstring to xml file
            }
            catch (WebException wex)
            {
                // TODO Log
            }
            catch (Exception ex)
            {
                // TODO log
            }
            return cc;
        }
    }
}
