using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PostingRobot
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            post2();
        }

        private void post()
        {
            //HttpWebRequest myHttpWebRequest;
            //string url = "http://bbs.szhome.com/commentdetail.aspx?id=156957778&projectid=32459";
            //string str = "偶住在半山30年了，如何健身一直困扰着偶这个小女人，也试过在市区的健身馆健身，晚上吃饭坐车回家都是很大的问题，健身半小时，回家需要1个小时，甚至更长。现在，半山有了健身馆，不过只去看过一次，人气好像不太旺，偶也没啥毅力，一个人不知道怎么锻炼身体，除了偶尔爬山。 以前跳过健身操什么的，对节奏感比较强的比较喜欢，现在老了，心脏可能受不了的，瑜伽之类的又坐不牢，这个夏天，偶老感冒，很想锻炼好自己的身体，请教在半山住的XDJM，你们是怎么锻炼身体的？ 或者我们组织一个半山健身群，爬爬半山，打打球，大家一起来锻炼身体吧！";
            //myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);//请求的URL
            //myHttpWebRequest.CookieContainer = Cookies;//*发送COOKIE
            //myHttpWebRequest.Method = "POST";
            //myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            //myHttpWebRequest.ContentLength = oneData.Length;
            //Stream newMyStream = myHttpWebRequest.GetRequestStream();
            //newMyStream.Write(oneData, 0, oneData.Length);
        }

        private void post2()
        {
            //CookieContainer cookies = new CookieContainer();
            //string url = "http://bbs.szhome.com/commentdetail.aspx?id=156957778&projectid=32459";
            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //myHttpWebRequest.Timeout = 20 * 1000; //连接超时
            //myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
            //myHttpWebRequest.CookieContainer = new CookieContainer(); //暂存到新实例
            //myHttpWebRequest.GetResponse().Close();
            //cookies = myHttpWebRequest.CookieContainer; //保存cookies
            //string cookiesstr = myHttpWebRequest.CookieContainer.GetCookieHeader(myHttpWebRequest.RequestUri); //把cookies转换成字符串


            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //string s = "要提交的数据";
            //byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(LoginInfo);
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            //req.ContentLength = requestBytes.Length;
            //Stream requestStream = req.GetRequestStream();
            //requestStream.Write(requestBytes, 0, requestBytes.Length);
            //requestStream.Close();
            //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            //string backstr = sr.ReadToEnd(); Response.Write(line); sr.Close(); res.Close();


            string s = "ddddddddddddd";
            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(s);
            string mycookie = "userlogin=2013/12/8 0:29:17; DefaultGoPage=0; Hm_lvt_9a7b16ce65b422c3a2b3f1d30d705175=1384434550,1384565670,1386433782,1386513814; ASP.NET_SessionId=wymixiuxrdqshurnl3v1cm55; SSOR=1; Hm_lvt_75d7e14328346393cb778e8ef89b1d0d=1385911818,1385911998,1386433808,1386514540; Hm_lpvt_75d7e14328346393cb778e8ef89b1d0d=1386514556";
            string url = "http://bbs.szhome.com/commentdetail.aspx?id=156957778&projectid=32459";
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = 20 * 1000; //连接超时
            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
            //myHttpWebRequest.CookieContainer = cookies; //使用已经保存的cookies 方法一
            myHttpWebRequest.Headers.Add("Cookie", mycookie); //使用已经保存的cookies 方法二

            Stream requestStream = myHttpWebRequest.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream stream = myHttpWebResponse.GetResponseStream();
            stream.ReadTimeout = 15 * 1000; //读取超时
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string strWebData = sr.ReadToEnd();


           

        }
    }
}
