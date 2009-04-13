namespace Indihiang.Modules
{
    partial class UserAgentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAgentControl));
            this.tabMainUserAgent = new System.Windows.Forms.TabControl();
            this.tabUserAgent1 = new System.Windows.Forms.TabPage();
            this.zedUserAgent1 = new ZedGraph.ZedGraphControl();
            this.tabUserAgent2 = new System.Windows.Forms.TabPage();
            this.zedUserAgent2 = new ZedGraph.ZedGraphControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabMainUserAgent.SuspendLayout();
            this.tabUserAgent1.SuspendLayout();
            this.tabUserAgent2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainUserAgent
            // 
            this.tabMainUserAgent.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMainUserAgent.Controls.Add(this.tabUserAgent1);
            this.tabMainUserAgent.Controls.Add(this.tabUserAgent2);
            this.tabMainUserAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainUserAgent.ImageList = this.imageList1;
            this.tabMainUserAgent.Location = new System.Drawing.Point(0, 0);
            this.tabMainUserAgent.Name = "tabMainUserAgent";
            this.tabMainUserAgent.SelectedIndex = 0;
            this.tabMainUserAgent.Size = new System.Drawing.Size(805, 411);
            this.tabMainUserAgent.TabIndex = 0;
            // 
            // tabUserAgent1
            // 
            this.tabUserAgent1.Controls.Add(this.zedUserAgent1);
            this.tabUserAgent1.ImageIndex = 0;
            this.tabUserAgent1.Location = new System.Drawing.Point(4, 26);
            this.tabUserAgent1.Name = "tabUserAgent1";
            this.tabUserAgent1.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserAgent1.Size = new System.Drawing.Size(797, 381);
            this.tabUserAgent1.TabIndex = 0;
            this.tabUserAgent1.Text = "UserAgent per Time";
            this.tabUserAgent1.UseVisualStyleBackColor = true;
            // 
            // zedUserAgent1
            // 
            this.zedUserAgent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedUserAgent1.Location = new System.Drawing.Point(3, 3);
            this.zedUserAgent1.Name = "zedUserAgent1";
            this.zedUserAgent1.ScrollGrace = 0;
            this.zedUserAgent1.ScrollMaxX = 0;
            this.zedUserAgent1.ScrollMaxY = 0;
            this.zedUserAgent1.ScrollMaxY2 = 0;
            this.zedUserAgent1.ScrollMinX = 0;
            this.zedUserAgent1.ScrollMinY = 0;
            this.zedUserAgent1.ScrollMinY2 = 0;
            this.zedUserAgent1.Size = new System.Drawing.Size(791, 375);
            this.zedUserAgent1.TabIndex = 0;
            this.zedUserAgent1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedUserAgent1_PointValueEvent);
            // 
            // tabUserAgent2
            // 
            this.tabUserAgent2.Controls.Add(this.zedUserAgent2);
            this.tabUserAgent2.ImageIndex = 0;
            this.tabUserAgent2.Location = new System.Drawing.Point(4, 26);
            this.tabUserAgent2.Name = "tabUserAgent2";
            this.tabUserAgent2.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserAgent2.Size = new System.Drawing.Size(797, 381);
            this.tabUserAgent2.TabIndex = 1;
            this.tabUserAgent2.Text = "UserAgent %";
            this.tabUserAgent2.UseVisualStyleBackColor = true;
            // 
            // zedUserAgent2
            // 
            this.zedUserAgent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedUserAgent2.Location = new System.Drawing.Point(3, 3);
            this.zedUserAgent2.Name = "zedUserAgent2";
            this.zedUserAgent2.ScrollGrace = 0;
            this.zedUserAgent2.ScrollMaxX = 0;
            this.zedUserAgent2.ScrollMaxY = 0;
            this.zedUserAgent2.ScrollMaxY2 = 0;
            this.zedUserAgent2.ScrollMinX = 0;
            this.zedUserAgent2.ScrollMinY = 0;
            this.zedUserAgent2.ScrollMinY2 = 0;
            this.zedUserAgent2.Size = new System.Drawing.Size(791, 375);
            this.zedUserAgent2.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // UserAgentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMainUserAgent);
            this.Name = "UserAgentControl";
            this.Size = new System.Drawing.Size(805, 411);
            this.Resize += new System.EventHandler(this.UserAgentControl_Resize);
            this.tabMainUserAgent.ResumeLayout(false);
            this.tabUserAgent1.ResumeLayout(false);
            this.tabUserAgent2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainUserAgent;
        private System.Windows.Forms.TabPage tabUserAgent1;
        private System.Windows.Forms.TabPage tabUserAgent2;
        private ZedGraph.ZedGraphControl zedUserAgent1;
        private ZedGraph.ZedGraphControl zedUserAgent2;
        private System.Windows.Forms.ImageList imageList1;


    }
}
