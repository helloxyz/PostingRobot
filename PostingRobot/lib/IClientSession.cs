using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingRobot.lib
{
    public interface IClientSession
    {
        public void GetCookieCollection();
        public void Login();
        public void Post();
    }
}
