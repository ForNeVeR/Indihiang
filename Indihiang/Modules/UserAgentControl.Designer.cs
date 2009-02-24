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
            this.zedUserAgent = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedUserAgent
            // 
            this.zedUserAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedUserAgent.Location = new System.Drawing.Point(0, 0);
            this.zedUserAgent.Name = "zedUserAgent";
            this.zedUserAgent.ScrollGrace = 0;
            this.zedUserAgent.ScrollMaxX = 0;
            this.zedUserAgent.ScrollMaxY = 0;
            this.zedUserAgent.ScrollMaxY2 = 0;
            this.zedUserAgent.ScrollMinX = 0;
            this.zedUserAgent.ScrollMinY = 0;
            this.zedUserAgent.ScrollMinY2 = 0;
            this.zedUserAgent.Size = new System.Drawing.Size(718, 350);
            this.zedUserAgent.TabIndex = 0;
            // 
            // UserAgentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zedUserAgent);
            this.Name = "UserAgentControl";
            this.Size = new System.Drawing.Size(718, 350);
            this.Resize += new System.EventHandler(this.UserAgentControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedUserAgent;

    }
}
