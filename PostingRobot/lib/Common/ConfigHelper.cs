using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PostingRobot.lib.Common
{
    public class ConfigHelper
    {
        public static string GetConfigByKey(string key)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                val = ConfigurationManager.AppSettings[key];
            }
                
            return val;
        }

    }
}
