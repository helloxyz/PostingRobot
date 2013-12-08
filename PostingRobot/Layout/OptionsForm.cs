using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostingRobot.lib.Common;
using PostingRobot.lib.DAL;
using PostingRobot.lib.Model;
using PostingRobot.lib.Controls;

namespace PostingRobot.Layout
{
    public partial class OptionsForm : Form
    {
        TreeNode webNode = null;
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        List<WebInfo> webList = null;
        SqliteSession session = new SqliteSession();

        public OptionsForm()
        {
            InitializeComponent();
            session.initialize();
            initialize();
        }

        private void initialize()
        {
            initTreeView();
            loadWebInfo();
        }

        private void initTreeView()
        {
            TreeNode generalNode = this.treeView_list.Nodes.Add(ConstUI.UI_GENERAL, ConstUI.UI_GENERAL);
            webNode = this.treeView_list.Nodes.Add(ConstUI.UI_WEB, ConstUI.UI_WEB);
        }

        private void loadWebInfo()
        {
            if (webList == null)
            {
                webList = session.LoadWebInfo();

                if (webList != null)
                {
                    foreach (WebInfo web in webList)
                    {
                        if (String.IsNullOrEmpty(web.GroupName))
                        {
                            webNode.Nodes.Add(web.Id, web.Name);
                        }
                        else
                        {
                            if (!webNode.Nodes.ContainsKey(web.GroupName))
                            {
                                webNode.Nodes.Add(web.GroupName, web.GroupName);
                            }
                            webNode.Nodes[web.GroupName].Nodes.Add(web.Id, web.Name);
                        }
                    }
                }
            }
        }
        private void display(TreeNode node)
        {
            if (node.Parent.Name == ConstUI.UI_WEB || node.Parent.Parent.Name == ConstUI.UI_WEB)
            {
                displayWebInfo(node);
            }
            //this.splitContainer_top.Panel2.Controls.Add(displayWebInfo());
        }
        private void displayWebInfo(TreeNode node)
        {
            WebInfo web = null;
            if ((web = webList.Find(delegate(WebInfo webinfo) { return webinfo.Id == node.Name; })) != null)
            {
                Panel panel = this.splitContainer_top.Panel2;
                panel.Padding = new System.Windows.Forms.Padding(50, 20, 0, 0);

                //Label label_client = new Label();
                //label_client.Text = ConstUI.UI_CLIENT;
                //label_client.Font = new System.Drawing.Font(label_client.Font, FontStyle.Bold);
                //label_client.Dock = DockStyle.Top;

                //MyLabel myLabel_accept = new MyLabel();
                //myLabel_accept.KeyText = ConstUI.UI_CLIENT_ACCEPT;
                //myLabel_accept.ValueText = web.Headers.Accept;
                //myLabel_accept.Dock = DockStyle.Top;

                //MyLabel myLabel_Accept_E = new MyLabel();
                //myLabel_Accept_E.KeyText = ConstUI.UI_CLIENT_ACCEPT_E;
                //myLabel_Accept_E.ValueText = web.Headers.AcceptEncoding;
                //myLabel_Accept_E.Dock = DockStyle.Top;

                //MyLabel myLabel_Accept_L = new MyLabel();
                //myLabel_Accept_L.KeyText = ConstUI.UI_CLIENT_ACCEPT_L;
                //myLabel_Accept_L.ValueText = web.Headers.AcceptLanguage;
                //myLabel_Accept_L.Dock = DockStyle.Top;

                //Panel test = new Panel();
                //test.Width = panel.Width;

                //MyLabel myLabel_UserAgent = new MyLabel();
                //myLabel_UserAgent.KeyText = ConstUI.UI_CLIENT_USERAGENT;
                //myLabel_UserAgent.ValueText = web.Headers.UserAgent;
                //myLabel_UserAgent.Dock = DockStyle.Top;
                //test.Controls.Add(myLabel_UserAgent);

                ControlPanel cp_client = new ControlPanel(panel, ConstUI.UI_CLIENT);
                //cp_client.addMyLabel(ConstUI.UI_CLIENT_ACCEPT, web.Headers.Accept);
                //cp_client.addMyLabel(ConstUI.UI_CLIENT_ACCEPT_E, web.Headers.AcceptEncoding);
                //cp_client.addMyLabel(ConstUI.UI_CLIENT_ACCEPT_L, web.Headers.AcceptLanguage);
                //cp_client.addMyLabel(ConstUI.UI_CLIENT_USERAGENT, web.Headers.UserAgent);

                //panel.Controls.Add(label_client);
                //panel.Controls.Add(myLabel_accept);
                //panel.Controls.Add(myLabel_Accept_E);
                //panel.Controls.Add(myLabel_Accept_L);
                //panel.Controls.Add(myLabel_UserAgent);
                //panel.Controls.Add(test);

                //this.splitContainer_top.Panel2.Controls.Add(panel);
                //Panel test = this.splitContainer_top.Panel2;
                //test.BackColor = Color.Red;
            }
        }

        private void treeView_list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.X < e.Node.Bounds.Right && e.X > e.Node.Bounds.Left)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.Node.Name == ConstUI.UI_WEB)
                    {

                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (e.Node.Name == ConstUI.UI_WEB)
                    {
                    }
                    else
                    {
                        treeView_list.SelectedNode = e.Node;
                        display(e.Node);
                    }
                }
            }
        }
    }
}
