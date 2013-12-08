using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostingRobot.Layout
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected string FormTitle
        {
            set { this.Text = value; }
        }

        protected Panel PanelBottom
        {
            get { return this.splitContainer_main.Panel2; }
        }

        protected virtual void button_save_Click(object sender, EventArgs e)
        {

        }

        protected virtual void button_cancel_Click(object sender, EventArgs e)
        {

        }

        protected virtual void button_apply_Click(object sender, EventArgs e)
        {

        }
    }
}
