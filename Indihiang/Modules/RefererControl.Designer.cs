namespace Indihiang.Modules
{
    partial class RefererControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefererControl));
            this.tabMainReferer = new System.Windows.Forms.TabControl();
            this.tabPageReferer = new System.Windows.Forms.TabPage();
            this.zedReferer = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.tabPageRefererDataSet = new System.Windows.Forms.TabPage();
            this.dataGridViewReferer = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboParams2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabMainReferer.SuspendLayout();
            this.tabPageReferer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageRefererDataSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferer)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainReferer
            // 
            this.tabMainReferer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMainReferer.Controls.Add(this.tabPageReferer);
            this.tabMainReferer.Controls.Add(this.tabPageRefererDataSet);
            this.tabMainReferer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainReferer.ImageList = this.imageList1;
            this.tabMainReferer.Location = new System.Drawing.Point(0, 0);
            this.tabMainReferer.Name = "tabMainReferer";
            this.tabMainReferer.SelectedIndex = 0;
            this.tabMainReferer.Size = new System.Drawing.Size(824, 476);
            this.tabMainReferer.TabIndex = 0;
            // 
            // tabPageReferer
            // 
            this.tabPageReferer.Controls.Add(this.zedReferer);
            this.tabPageReferer.Controls.Add(this.panel1);
            this.tabPageReferer.ImageIndex = 0;
            this.tabPageReferer.Location = new System.Drawing.Point(4, 26);
            this.tabPageReferer.Name = "tabPageReferer";
            this.tabPageReferer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReferer.Size = new System.Drawing.Size(816, 446);
            this.tabPageReferer.TabIndex = 0;
            this.tabPageReferer.Text = "Referer";
            this.tabPageReferer.UseVisualStyleBackColor = true;
            // 
            // zedReferer
            // 
            this.zedReferer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedReferer.Location = new System.Drawing.Point(3, 45);
            this.zedReferer.Name = "zedReferer";
            this.zedReferer.ScrollGrace = 0;
            this.zedReferer.ScrollMaxX = 0;
            this.zedReferer.ScrollMaxY = 0;
            this.zedReferer.ScrollMaxY2 = 0;
            this.zedReferer.ScrollMinX = 0;
            this.zedReferer.ScrollMinY = 0;
            this.zedReferer.ScrollMinY2 = 0;
            this.zedReferer.Size = new System.Drawing.Size(810, 398);
            this.zedReferer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.btnGenerate1);
            this.panel1.Controls.Add(this.cboParams1);
            this.panel1.Controls.Add(this.lbParam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 42);
            this.panel1.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.lbStatus.Location = new System.Drawing.Point(283, 19);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(98, 13);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "Generating report...";
            this.lbStatus.Visible = false;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnGenerate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate1.Location = new System.Drawing.Point(202, 11);
            this.btnGenerate1.Name = "btnGenerate1";
            this.btnGenerate1.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate1.TabIndex = 4;
            this.btnGenerate1.Text = "Generate";
            this.btnGenerate1.UseVisualStyleBackColor = false;
            this.btnGenerate1.Click += new System.EventHandler(this.btnGenerate1_Click);
            // 
            // cboParams1
            // 
            this.cboParams1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams1.FormattingEnabled = true;
            this.cboParams1.Location = new System.Drawing.Point(46, 11);
            this.cboParams1.Name = "cboParams1";
            this.cboParams1.Size = new System.Drawing.Size(141, 21);
            this.cboParams1.TabIndex = 3;
            // 
            // lbParam
            // 
            this.lbParam.AutoSize = true;
            this.lbParam.Location = new System.Drawing.Point(8, 14);
            this.lbParam.Name = "lbParam";
            this.lbParam.Size = new System.Drawing.Size(32, 13);
            this.lbParam.TabIndex = 2;
            this.lbParam.Text = "Year:";
            // 
            // tabPageRefererDataSet
            // 
            this.tabPageRefererDataSet.Controls.Add(this.dataGridViewReferer);
            this.tabPageRefererDataSet.Controls.Add(this.panel2);
            this.tabPageRefererDataSet.ImageIndex = 0;
            this.tabPageRefererDataSet.Location = new System.Drawing.Point(4, 26);
            this.tabPageRefererDataSet.Name = "tabPageRefererDataSet";
            this.tabPageRefererDataSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRefererDataSet.Size = new System.Drawing.Size(818, 448);
            this.tabPageRefererDataSet.TabIndex = 1;
            this.tabPageRefererDataSet.Text = "Referer DataSet";
            this.tabPageRefererDataSet.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReferer
            // 
            this.dataGridViewReferer.AllowUserToAddRows = false;
            this.dataGridViewReferer.AllowUserToDeleteRows = false;
            this.dataGridViewReferer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReferer.Location = new System.Drawing.Point(3, 45);
            this.dataGridViewReferer.Name = "dataGridViewReferer";
            this.dataGridViewReferer.ReadOnly = true;
            this.dataGridViewReferer.Size = new System.Drawing.Size(812, 400);
            this.dataGridViewReferer.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGenerate2);
            this.panel2.Controls.Add(this.cboParams2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 42);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(283, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Generating report...";
            this.label1.Visible = false;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnGenerate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate2.Location = new System.Drawing.Point(202, 11);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate2.TabIndex = 4;
            this.btnGenerate2.Text = "Generate";
            this.btnGenerate2.UseVisualStyleBackColor = false;
            this.btnGenerate2.Click += new System.EventHandler(this.btnGenerate2_Click);
            // 
            // cboParams2
            // 
            this.cboParams2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams2.FormattingEnabled = true;
            this.cboParams2.Location = new System.Drawing.Point(46, 11);
            this.cboParams2.Name = "cboParams2";
            this.cboParams2.Size = new System.Drawing.Size(141, 21);
            this.cboParams2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // RefererControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabMainReferer);
            this.Name = "RefererControl";
            this.Size = new System.Drawing.Size(824, 476);
            this.tabMainReferer.ResumeLayout(false);
            this.tabPageReferer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageRefererDataSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferer)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainReferer;
        private System.Windows.Forms.TabPage tabPageReferer;
        private System.Windows.Forms.TabPage tabPageRefererDataSet;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label lbParam;
        private ZedGraph.ZedGraphControl zedReferer;
        private System.Windows.Forms.DataGridView dataGridViewReferer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboParams2;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
