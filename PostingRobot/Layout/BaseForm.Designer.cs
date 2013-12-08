namespace PostingRobot.Layout
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_top = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_top)).BeginInit();
            this.splitContainer_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.IsSplitterFixed = true;
            this.splitContainer_main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main.Name = "splitContainer_main";
            this.splitContainer_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.Controls.Add(this.splitContainer_top);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer_main.Size = new System.Drawing.Size(634, 412);
            this.splitContainer_main.SplitterDistance = 380;
            this.splitContainer_main.TabIndex = 0;
            // 
            // splitContainer_top
            // 
            this.splitContainer_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_top.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_top.Name = "splitContainer_top";
            this.splitContainer_top.Size = new System.Drawing.Size(634, 380);
            this.splitContainer_top.SplitterDistance = 200;
            this.splitContainer_top.TabIndex = 0;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.splitContainer_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.splitContainer_main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_top)).EndInit();
            this.splitContainer_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.SplitContainer splitContainer_top;

    }
}