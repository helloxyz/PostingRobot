using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PostingRobot.lib.Common;

namespace PostingRobot.lib.Common
{
    class QueryHelper
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        string queryPath = "";

        private QueryHelper()
        {
            CheckFile();
        }
        private static QueryHelper _QueryHelper;
        public static QueryHelper GetInstance()
        {
            if (_QueryHelper == null)
            {
                _QueryHelper = new QueryHelper();
            }
            return _QueryHelper;
        }
        public string GetQueryCommand(string section, string key)
        {
            if(section == null)
                section = "";

            if (key == null)
                key = "";

            section = section.ToUpper();
            key = key.ToUpper();
            string currentSection = "";
            if (queryPath != "")
            {
                string line = "";
                using (StreamReader sr = new StreamReader(queryPath))
                {
                    while ((line = sr.ReadLine().Trim()) != null)
                    {
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            currentSection = line.Substring(1, line.Length - 2).ToUpper();
                        }
                        if (section == currentSection)
                        {
                            if (line.StartsWith(key, true, null))
                            {
                                return line.Substring(line.IndexOf('=') + 1);
                            }
                        }
                    }
                }
            }
            return "";
        }

        private void CheckFile()
        {
            string tmpPath= ConfigHelper.GetConfigByKey("QueryPath");
            if (String.IsNullOrEmpty(tmpPath))
            {
                log.Error("No QueryPath setting, please check app.config");
                return;
            }
            if (!File.Exists(tmpPath))
            {
                log.Error("No " + tmpPath + "file, please check.");
                return;
            }
            queryPath = tmpPath;
        }
    }
}
