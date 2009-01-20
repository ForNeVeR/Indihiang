namespace Indihiang.Modules
{
    partial class WebLogUserControl
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
            this.tabWebLog = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabAccessTime = new System.Windows.Forms.TabPage();
            this.tabAccessMethod = new System.Windows.Forms.TabPage();
            this.tabAccessUserAgent = new System.Windows.Forms.TabPage();
            this.tabAccessResource = new System.Windows.Forms.TabPage();
            this.tabWebLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabWebLog
            // 
            this.tabWebLog.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabWebLog.Controls.Add(this.tabGeneral);
            this.tabWebLog.Controls.Add(this.tabAccessTime);
            this.tabWebLog.Controls.Add(this.tabAccessMethod);
            this.tabWebLog.Controls.Add(this.tabAccessUserAgent);
            this.tabWebLog.Controls.Add(this.tabAccessResource);
            this.tabWebLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWebLog.Location = new System.Drawing.Point(0, 0);
            this.tabWebLog.Name = "tabWebLog";
            this.tabWebLog.SelectedIndex = 0;
            this.tabWebLog.Size = new System.Drawing.Size(848, 504);
            this.tabWebLog.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(840, 475);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabAccessTime
            // 
            this.tabAccessTime.Location = new System.Drawing.Point(4, 25);
            this.tabAccessTime.Name = "tabAccessTime";
            this.tabAccessTime.Size = new System.Drawing.Size(840, 475);
            this.tabAccessTime.TabIndex = 1;
            this.tabAccessTime.Text = "Access-by-Time";
            this.tabAccessTime.UseVisualStyleBackColor = true;
            // 
            // tabAccessMethod
            // 
            this.tabAccessMethod.Location = new System.Drawing.Point(4, 25);
            this.tabAccessMethod.Name = "tabAccessMethod";
            this.tabAccessMethod.Size = new System.Drawing.Size(840, 475);
            this.tabAccessMethod.TabIndex = 2;
            this.tabAccessMethod.Text = "Access-by-Methods";
            this.tabAccessMethod.UseVisualStyleBackColor = true;
            // 
            // tabAccessUserAgent
            // 
            this.tabAccessUserAgent.Location = new System.Drawing.Point(4, 25);
            this.tabAccessUserAgent.Name = "tabAccessUserAgent";
            this.tabAccessUserAgent.Size = new System.Drawing.Size(840, 475);
            this.tabAccessUserAgent.TabIndex = 3;
            this.tabAccessUserAgent.Text = "Access-by-UserAgent";
            this.tabAccessUserAgent.UseVisualStyleBackColor = true;
            // 
            // tabAccessResource
            // 
            this.tabAccessResource.Location = new System.Drawing.Point(4, 25);
            this.tabAccessResource.Name = "tabAccessResource";
            this.tabAccessResource.Size = new System.Drawing.Size(840, 475);
            this.tabAccessResource.TabIndex = 4;
            this.tabAccessResource.Text = "Access-by-Resource";
            this.tabAccessResource.UseVisualStyleBackColor = true;
            // 
            // WebLogUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabWebLog);
            this.Name = "WebLogUserControl";
            this.Size = new System.Drawing.Size(848, 504);
            this.tabWebLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabWebLog;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabAccessTime;
        private System.Windows.Forms.TabPage tabAccessMethod;
        private System.Windows.Forms.TabPage tabAccessUserAgent;
        private System.Windows.Forms.TabPage tabAccessResource;
    }
}
