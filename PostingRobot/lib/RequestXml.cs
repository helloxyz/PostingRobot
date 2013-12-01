using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using PostingRobot.lib.Common;
using System.Xml.Linq;

namespace PostingRobot.lib
{
    class RequestXml
    {
        private string _LoginUrl;
        private string _Method;
        private string _ContentType;
        private bool _AllowAutoRedirect;
        private bool _KeepAlive;
        private string _Content;
        private string _UserAgent;
        private Dictionary<string, string> _Parameters;



        public static RequestXml ReadRequestXml(string section)
        {
            return new RequestXml();
        }

        public static void SaveRequest(string section, RequestXml request)
        {
            if (section == null || section == "" || request == null)
                return;

            string fileName = ConfigHelper.GetConfigByKey("WebInfoFile");

            if (!String.IsNullOrEmpty(fileName))
            {
                XDocument myXDoc = new XDocument(
                    new XElement(section,
                        new XElement("LoginUrl", request._LoginUrl),
                        new XElement("Method", request._Method),
                        new XElement("ContentType", request._ContentType),
                        new XElement("AllowAutoRedirect", request._AllowAutoRedirect),
                        new XElement("KeepAlive", request._KeepAlive),
                        new XElement("Content", request._Content),
                        new XElement("Parameters", request._Parameters),
                        new XElement("UserAgent", request._UserAgent)
                       )
                );
                myXDoc.Save(fileName);
            }
        }


        public string LoginUrl
        {
            get { return _LoginUrl; }
            set { _LoginUrl = value; }
        }
        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }
        public bool AllowAutoRedirect
        {
            get { return _AllowAutoRedirect; }
            set { _AllowAutoRedirect = value; }
        }
        public bool KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        public Dictionary<string, string> Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; }
        }
    }
}
