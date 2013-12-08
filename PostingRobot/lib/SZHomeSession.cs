using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostingRobot.lib
{
    class SZHomeSession : ClientSession
    {
        private string _WebName;

        public SZHomeSession(string webName)
        {
            this._WebName = webName;
        }
        public  void Login()
        {
            if (_WebName == null || _WebName == "")
                return;

            HttpWebRequest request = new RequestManager(_WebName).ReadRequest();
            HttpWebResponse response = null;
        }


    }
}
