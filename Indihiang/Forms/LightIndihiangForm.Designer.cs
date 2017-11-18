namespace Indihiang.Forms
{
    partial class LightIndihiangForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightIndihiangForm));
            this.webLogUserControl1 = new Indihiang.Modules.WebLogUserControl();
            this.SuspendLayout();
            // 
            // webLogUserControl1
            // 
            this.webLogUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webLogUserControl1.Location = new System.Drawing.Point(0, 0);
            this.webLogUserControl1.Name = "webLogUserControl1";
            this.webLogUserControl1.Size = new System.Drawing.Size(903, 537);
            this.webLogUserControl1.TabIndex = 0;
            // 
            // LightIndihiangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 537);
            this.Controls.Add(this.webLogUserControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LightIndihiangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indihiang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LightIndihiangForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LightIndihiangForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Indihiang.Modules.WebLogUserControl webLogUserControl1;
    }
}