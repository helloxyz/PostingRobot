using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostingRobot.lib.Controls
{
    class ControlPanel
    {
        Panel panel = new Panel();
        List<Control> controlList = new List<Control>();

        public ControlPanel(ScrollableControl parent)
        {
            initialize(parent);
            parent.Controls.Add(panel);
            panel.BackColor = Color.Blue;
            Label ddd = new Label();
            ddd.Text = "--------------------------------";
            panel.Controls.Add(ddd);
        }
        public ControlPanel(ScrollableControl parent, string title)
            : this(parent)
        {
            //Title = title;
        }

        public void initialize(ScrollableControl parent)
        {
            panel.Width = parent.Width;
        }

        private Label _TitleLabel;
        public Label TitleLabel
        {
            set { _TitleLabel = value; }
        }

        public string Title
        {
            set
            {
                if (_TitleLabel == null)
                {
                    _TitleLabel = new Label();
                    _TitleLabel.Font = new System.Drawing.Font(Label.DefaultFont, System.Drawing.FontStyle.Bold);
                }
                _TitleLabel.Text = value;
                updateLocation();
            }
        }

        //标题与第一个control的距离
        private int _TitleBlank = 20;
        public int TitleBlank
        {
            set { _TitleBlank = value; }
        }
        //control之间的距离
        private int _ControlBlank = 10;
        public int ControlBlank
        {
            set { _ControlBlank = value; }
        }

        public void addItem(Control control)
        {
            if (!controlList.Contains(control))
            {
                controlList.Add(control);
            }
            updateLocation();
        }

        public void addMyLabel(string key, string value)
        {
            MyLabel myLabel = new MyLabel();
            myLabel.KeyText = key;
            myLabel.ValueText = value;

            panel.Controls.Add(myLabel);
            controlList.Add(myLabel);
            //updateLocation();
        }

        private void updateLocation()
        {
            int currentTop = 0;
            int currentLeft = 0;

            panel.Controls.Clear();

            if (_TitleLabel != null)
            {
                _TitleLabel.Location = new System.Drawing.Point(currentLeft, currentTop);
                currentTop += _TitleLabel.Height + _TitleBlank;
                panel.Controls.Add(_TitleLabel);
            }
            foreach (Control item in controlList)
            {
                item.Location = new System.Drawing.Point(currentLeft, currentTop);
                currentTop += item.Height + _ControlBlank;
                panel.Controls.Add(item);
            }
        }
    }
}
