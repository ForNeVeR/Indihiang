namespace Indihiang.Modules
{
    partial class GeneralControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxIPAddress = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxFileName = new System.Windows.Forms.ListBox();
            this.lbTotalData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Gainsboro;
            this.lbTime.Location = new System.Drawing.Point(91, 243);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(13, 13);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "[]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(28, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Time:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTotalData);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listBoxIPAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.listBoxFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 287);
            this.panel1.TabIndex = 6;
            // 
            // listBoxIPAddress
            // 
            this.listBoxIPAddress.FormattingEnabled = true;
            this.listBoxIPAddress.HorizontalScrollbar = true;
            this.listBoxIPAddress.Location = new System.Drawing.Point(94, 131);
            this.listBoxIPAddress.Name = "listBoxIPAddress";
            this.listBoxIPAddress.ScrollAlwaysVisible = true;
            this.listBoxIPAddress.Size = new System.Drawing.Size(320, 82);
            this.listBoxIPAddress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(28, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP Server:";
            // 
            // listBoxFileName
            // 
            this.listBoxFileName.FormattingEnabled = true;
            this.listBoxFileName.HorizontalScrollbar = true;
            this.listBoxFileName.Location = new System.Drawing.Point(94, 31);
            this.listBoxFileName.Name = "listBoxFileName";
            this.listBoxFileName.ScrollAlwaysVisible = true;
            this.listBoxFileName.Size = new System.Drawing.Size(320, 95);
            this.listBoxFileName.TabIndex = 0;
            // 
            // lbTotalData
            // 
            this.lbTotalData.AutoSize = true;
            this.lbTotalData.BackColor = System.Drawing.Color.Gainsboro;
            this.lbTotalData.Location = new System.Drawing.Point(91, 224);
            this.lbTotalData.Name = "lbTotalData";
            this.lbTotalData.Size = new System.Drawing.Size(13, 13);
            this.lbTotalData.TabIndex = 10;
            this.lbTotalData.Text = "[]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(28, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Data:";
            // 
            // GeneralControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "GeneralControl";
            this.Size = new System.Drawing.Size(554, 287);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFileName;
        private System.Windows.Forms.Label lbTotalData;
        private System.Windows.Forms.Label label4;
    }
}
