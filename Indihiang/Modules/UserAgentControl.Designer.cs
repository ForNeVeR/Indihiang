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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cboParams = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.cboReport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabUserAgent2 = new System.Windows.Forms.TabPage();
            this.zedUserAgent2 = new ZedGraph.ZedGraphControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundJob = new System.ComponentModel.BackgroundWorker();
            this.backgroundReportJob = new System.ComponentModel.BackgroundWorker();
            this.tabMainUserAgent.SuspendLayout();
            this.tabUserAgent1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabMainUserAgent.Size = new System.Drawing.Size(803, 409);
            this.tabMainUserAgent.TabIndex = 0;
            // 
            // tabUserAgent1
            // 
            this.tabUserAgent1.Controls.Add(this.zedUserAgent1);
            this.tabUserAgent1.Controls.Add(this.panel1);
            this.tabUserAgent1.ImageIndex = 0;
            this.tabUserAgent1.Location = new System.Drawing.Point(4, 26);
            this.tabUserAgent1.Name = "tabUserAgent1";
            this.tabUserAgent1.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserAgent1.Size = new System.Drawing.Size(795, 379);
            this.tabUserAgent1.TabIndex = 0;
            this.tabUserAgent1.Text = "UserAgent per Time";
            this.tabUserAgent1.UseVisualStyleBackColor = true;
            // 
            // zedUserAgent1
            // 
            this.zedUserAgent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedUserAgent1.Location = new System.Drawing.Point(3, 45);
            this.zedUserAgent1.Name = "zedUserAgent1";
            this.zedUserAgent1.ScrollGrace = 0;
            this.zedUserAgent1.ScrollMaxX = 0;
            this.zedUserAgent1.ScrollMaxY = 0;
            this.zedUserAgent1.ScrollMaxY2 = 0;
            this.zedUserAgent1.ScrollMinX = 0;
            this.zedUserAgent1.ScrollMinY = 0;
            this.zedUserAgent1.ScrollMinY2 = 0;
            this.zedUserAgent1.Size = new System.Drawing.Size(789, 331);
            this.zedUserAgent1.TabIndex = 1;
            this.zedUserAgent1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedUserAgent1_PointValueEvent);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.cboParams);
            this.panel1.Controls.Add(this.lbParam);
            this.panel1.Controls.Add(this.cboReport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 42);
            this.panel1.TabIndex = 0;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lbStatus.Location = new System.Drawing.Point(581, 19);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(98, 13);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "Generating report...";
            this.lbStatus.Visible = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.GreenYellow;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Location = new System.Drawing.Point(500, 11);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cboParams
            // 
            this.cboParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams.FormattingEnabled = true;
            this.cboParams.Location = new System.Drawing.Point(344, 11);
            this.cboParams.Name = "cboParams";
            this.cboParams.Size = new System.Drawing.Size(141, 21);
            this.cboParams.TabIndex = 3;
            // 
            // lbParam
            // 
            this.lbParam.AutoSize = true;
            this.lbParam.Location = new System.Drawing.Point(306, 14);
            this.lbParam.Name = "lbParam";
            this.lbParam.Size = new System.Drawing.Size(32, 13);
            this.lbParam.TabIndex = 2;
            this.lbParam.Text = "Year:";
            // 
            // cboReport
            // 
            this.cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Items.AddRange(new object[] {
            "User Agent Report By Year",
            "User Agent Report By Month"});
            this.cboReport.Location = new System.Drawing.Point(89, 11);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(204, 21);
            this.cboReport.TabIndex = 1;
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Type:";
            // 
            // tabUserAgent2
            // 
            this.tabUserAgent2.Controls.Add(this.zedUserAgent2);
            this.tabUserAgent2.ImageIndex = 0;
            this.tabUserAgent2.Location = new System.Drawing.Point(4, 26);
            this.tabUserAgent2.Name = "tabUserAgent2";
            this.tabUserAgent2.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserAgent2.Size = new System.Drawing.Size(795, 379);
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
            this.zedUserAgent2.Size = new System.Drawing.Size(789, 373);
            this.zedUserAgent2.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // backgroundJob
            // 
            this.backgroundJob.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJob_DoWork);
            this.backgroundJob.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJob_RunWorkerCompleted);
            // 
            // backgroundReportJob
            // 
            this.backgroundReportJob.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundReportJob_DoWork);
            this.backgroundReportJob.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundReportJob_RunWorkerCompleted);
            // 
            // UserAgentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabMainUserAgent);
            this.Name = "UserAgentControl";
            this.Size = new System.Drawing.Size(803, 409);
            this.Resize += new System.EventHandler(this.UserAgentControl_Resize);
            this.tabMainUserAgent.ResumeLayout(false);
            this.tabUserAgent1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabUserAgent2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainUserAgent;
        private System.Windows.Forms.TabPage tabUserAgent1;
        private System.Windows.Forms.TabPage tabUserAgent2;
        private ZedGraph.ZedGraphControl zedUserAgent2;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundJob;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zedUserAgent1;
        private System.Windows.Forms.ComboBox cboReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbParam;
        private System.Windows.Forms.ComboBox cboParams;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lbStatus;
        private System.ComponentModel.BackgroundWorker backgroundReportJob;


    }
}
