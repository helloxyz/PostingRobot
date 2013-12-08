using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingRobot.lib.Model
{
    class WebInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string LoginUrl { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string AllowAutoRedirect { get; set; }
        public string KeepAlive { get; set; }
        public string Content { get; set; }
        public string Parameters { get; set; }
        public string UserAgent { get; set; }
        public string GroupName { get; set; }
        public WebHeaders Headers { get; set; }
    }

    class WebHeaders
    {
        public string  Accept { get; set; }
        public string AcceptEncoding { get; set; }
        public string AcceptLanguage { get; set; }
        public string  UserAgent { get; set; }
        public string ContentType { get; set; }
        public string  ContentLength { get; set; }
        public string Connection { get; set; }
        public string Cookie { get; set; }
    }
}
