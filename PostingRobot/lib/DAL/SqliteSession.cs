using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostingRobot.lib.Common;
using System.Data.SQLite;
using PostingRobot.lib.Model;
using System.Data;
using PostingRobot.lib.Common;

namespace PostingRobot.lib.DAL
{
    class SqliteSession
    {
        SQLiteHelper sqliteHelper = null;
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public SqliteSession()
        {

        }

        public void initialize()
        {
            createDB();
            createSettingTable();
            //testData();
        }

        private void createDB()
        {
            string tmp = ConfigHelper.GetConfigByKey("WebInfoFile");
            tmp = tmp.TrimStart('.').TrimStart('/').TrimStart('\\').TrimStart('/');
            string filePath = System.Windows.Forms.Application.StartupPath + @"\" + tmp;
            if (!File.Exists(filePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(filePath);
                }
                catch (Exception ex)
                {
                    log.ErrorException("Create DB file failed.", ex);
                }
            }
            string datasource = "data source=" + filePath + "; Version=3;";
            sqliteHelper = new SQLiteHelper(datasource);   
        }

        private void createSettingTable()
        {
            string tbDetectQuery = String.Format("SELECT COUNT(*) FROM [sqlite_master] where type='table' and name='{0}'", ConstPR.webInfoName);
            if (0 == Convert.ToInt32(sqliteHelper.ExecuteScalar(tbDetectQuery)))
            {
                string webInfoTbQuery = String.Format("create table [{0}]({1} varchar(20),{2} varchar(20),{3} varchar(50),{4} varchar(200),{5} varchar(100),{6} varchar(100),{7} varchar(100),{8} varchar(100),{9} varchar(100),{10} varchar(100),{11} varchar(100))",
                    ConstPR.webInfoName, ConstPR.ID, ConstPR.name, ConstPR.host, ConstPR.loginUrl, ConstPR.contentType, ConstPR.allowAutoRedirect,
                    ConstPR.connection, ConstPR.content, ConstPR.parameters, ConstPR.userAgent,ConstPR.groupName);
                sqliteHelper.Execute(webInfoTbQuery);
            }

            //string createTagsTbQuery = "create table tags(id integer primary key autoincrement,name varchar(140),content text,tag_type varchar(10),source varchar(255),application varchar(20),createdate datetime default (datetime('now', 'localtime')),updatedate datetime)";
        }

        public void WriteWebInfo(WebInfo webinfo)
        {
            string insertQuery = String.Format("insert into [{0}] ({1},{2}) values(@name,@host)",
                ConstPR.webInfoName, ConstPR.name, ConstPR.host);
            SQLiteParameter[] parameters = new SQLiteParameter[2];
            parameters[0] = new SQLiteParameter("@name", webinfo.Name);
            parameters[1] = new SQLiteParameter("@host", webinfo.Host);
            try
            {
                sqliteHelper.Execute(insertQuery, parameters);
                log.Info(String.Format("insert {0} record into DB success.",ConstPR.webInfoName));
            }
            catch (Exception ex)
            {
                log.ErrorException(String.Format("insert {0} record into DB failed.",ConstPR.webInfoName), ex);
            }
        }

        public List<WebInfo> LoadWebInfo()
        {
            string QueryWebInfo = QueryHelper.GetInstance().GetQueryCommand("", "QueryWebInfo");
            try
            {
                DataSet ds = sqliteHelper.GetDs(QueryWebInfo);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    List<WebInfo> webList = new List<WebInfo>();
                    foreach (DataRow record in ds.Tables[0].Rows)
                    {
                        WebInfo webinfo = new WebInfo();
                        webinfo.Id = record[ConstPR.ID].ToString();
                        webinfo.Name = record[ConstPR.name].ToString();
                        webinfo.Host = record[ConstPR.host].ToString();
                        webinfo.GroupName = record[ConstPR.groupName].ToString();

                        WebHeaders headers = new WebHeaders();
                        headers.Accept = record[ConstPR.accept].ToString();
                        headers.AcceptEncoding = record[ConstPR.acceptEncoding].ToString();
                        headers.AcceptLanguage = record[ConstPR.acceptLanguage].ToString();
                        headers.UserAgent = record[ConstPR.userAgent].ToString();
                        headers.ContentType = record[ConstPR.contentType].ToString();
                        headers.ContentLength = record[ConstPR.contentLength].ToString();
                        headers.Connection = record[ConstPR.connection].ToString();
                        headers.Cookie = record[ConstPR.cookie].ToString();

                        webinfo.Headers = headers;
                        webList.Add(webinfo);
                    }
                    return webList;
                }
            }
            catch (Exception ex)
            {
                log.ErrorException(String.Format("Load {0} failed", ConstPR.webInfoName), ex);
            }
            return null;
        }

        private void testData()
        {
            string insertQuery = "insert into [webinfo] values('11','深圳房地产网','www.szfdc.com','','','','','','','','')";
            try
            {
                sqliteHelper.Execute(insertQuery);
            }
            catch (Exception ex)
            {
                log.ErrorException("insert data to DB failed.", ex);
            }
        }
    }
}
