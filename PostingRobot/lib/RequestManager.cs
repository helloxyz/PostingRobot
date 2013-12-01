using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostingRobot.lib
{
    class RequestManager
    {
        private string _Content;
        public string Content
        {
            get { return _Content; }
        }

        private HttpWebRequest _Request;
        public HttpWebRequest Request
        {
            get 
            {
                _Request = ReadRequest();
                return _Request;
            }
            
        }

        private string _Section;
        public RequestManager(string section)
        {
            this._Section = section;
        }
       
        public HttpWebRequest ReadRequest()
        {
            if (_Section == "")
                return (HttpWebRequest)WebRequest.Create("");

            RequestXml requestXml = RequestXml.ReadRequestXml(_Section);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestXml.LoginUrl);
                        
            _Content = requestXml.Content;

            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = requestXml.Method;
            request.ContentType = requestXml.ContentType;
            request.AllowAutoRedirect = requestXml.AllowAutoRedirect;
            request.KeepAlive = requestXml.KeepAlive;
            request.ContentLength = _Content.Length;
            request.UserAgent = requestXml.UserAgent;

            return request;
        }

        public void SaveRequest()
        {
            if (_Request == null || _Section == "")
                return;

            RequestXml requestXml = new RequestXml();
            if (_Request.Method != null)
                requestXml.Method = _Request.Method;
            if (_Request.ContentType != null)
                requestXml.ContentType = _Request.ContentType;
            if (_Request.AllowAutoRedirect != null)
                requestXml.AllowAutoRedirect = _Request.AllowAutoRedirect;
            if (_Request.KeepAlive != null)
                requestXml.KeepAlive = _Request.KeepAlive;
            if (_Request.UserAgent != null)
                requestXml.UserAgent = _Request.UserAgent;
           

            RequestXml.SaveRequest(_Section, requestXml);
        }
    }
}
