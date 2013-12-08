using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostingRobot.lib.Controls
{
    class MyLabel : Label
    {
        public MyLabel()
        {
        }
        private string _Text;
        private string _KetText;
        public string KeyText
        {
            get { return _KetText; }
            set
            {
                this._KetText = value;
                if (String.IsNullOrEmpty(_Text))
                {
                    _Text = value;
                }
                else
                {
                    _Text = value + _Text;
                }
                this.Text = _Text;
            }
        }
        private string _ValueText;
        public string ValueText
        {
            get { return _ValueText; }
            set
            {
                this._ValueText = value;
                if (String.IsNullOrEmpty(_Text))
                {
                    _Text = value;
                }
                else
                {
                    _Text += value;
                }
                this.Text = _Text;
            }
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            MessageBox.Show("fuck");
        }
    }
}
