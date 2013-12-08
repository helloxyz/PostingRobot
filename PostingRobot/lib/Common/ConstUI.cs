using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingRobot.lib.Common
{
    public class ConstUI
    {
        public static string UI_WEB
        {
            get { return "网站"; }
        }

        public static string UI_GENERAL
        {
            get { return "常规"; }
        }


        public const string UI_CLIENT = "Client";
        public const string UI_COOKIES = "Cookies / Login";
        public const string UI_TRANSPORT = "Transport";
        public const string UI_CLIENT_ACCEPT = "Accept:";
        public const string UI_CLIENT_ACCEPT_E = "Accept-Encoding:";
        public const string UI_CLIENT_ACCEPT_L = "Accept-Language:";
        public const string UI_CLIENT_USERAGENT= "User-Agent:";
        public const string UI_COOKIES_COOKIE = "Cookie:";
        public const string UI_T_CONNECTION = "Connection:";
        public const string UI_T_HOST = "Host:";

    }
}
