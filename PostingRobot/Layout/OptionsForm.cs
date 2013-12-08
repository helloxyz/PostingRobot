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

        public OptionsForm()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            initTreeView();
            loadWebInfo();
            display();
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
                SqliteSession session = new SqliteSession();
                session.initialize();
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

        private void display()
        {
            this.splitContainer_top.Panel2.Controls.Add(displayWebInfo());
        }
        private Panel displayWebInfo()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.AliceBlue;

            Label label_client = new Label();
            label_client.Text = ConstUI.UI_CLIENT;
            label_client.Font = new System.Drawing.Font(label_client.Font, FontStyle.Bold);
            label_client.Top = 50;
            label_client.Left = 100;

            MyLabel myLabel_accept = new MyLabel();
            myLabel_accept.KeyText = ConstUI.UI_CLIENT_ACCEPT;
            myLabel_accept.ValueText = "";
            //myLabel_accept.Top = 100;
            //myLabel_accept.Left = 50;

            panel.Controls.Add(label_client);
            panel.Controls.Add(myLabel_accept);
            return panel;
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
                    }
                }
            }
        }
    }
}
