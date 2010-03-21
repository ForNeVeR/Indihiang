namespace Indihiang.Modules
{
    partial class AccessStatusControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessStatusControl));
            this.tabAccessStatus = new System.Windows.Forms.TabControl();
            this.tabPercentHttp = new System.Windows.Forms.TabPage();
            this.tabGridHttp = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.zedPercentStatus1 = new ZedGraph.ZedGraphControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridHttpStatus = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboParams2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabAccessStatus.SuspendLayout();
            this.tabPercentHttp.SuspendLayout();
            this.tabGridHttp.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHttpStatus)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAccessStatus
            // 
            this.tabAccessStatus.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabAccessStatus.Controls.Add(this.tabPercentHttp);
            this.tabAccessStatus.Controls.Add(this.tabGridHttp);
            this.tabAccessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAccessStatus.ImageList = this.imageList1;
            this.tabAccessStatus.Location = new System.Drawing.Point(0, 0);
            this.tabAccessStatus.Name = "tabAccessStatus";
            this.tabAccessStatus.SelectedIndex = 0;
            this.tabAccessStatus.Size = new System.Drawing.Size(761, 432);
            this.tabAccessStatus.TabIndex = 0;
            // 
            // tabPercentHttp
            // 
            this.tabPercentHttp.Controls.Add(this.zedPercentStatus1);
            this.tabPercentHttp.Controls.Add(this.panel2);
            this.tabPercentHttp.ImageIndex = 0;
            this.tabPercentHttp.Location = new System.Drawing.Point(4, 26);
            this.tabPercentHttp.Name = "tabPercentHttp";
            this.tabPercentHttp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPercentHttp.Size = new System.Drawing.Size(753, 402);
            this.tabPercentHttp.TabIndex = 0;
            this.tabPercentHttp.Text = "Percent HTTP Status";
            this.tabPercentHttp.UseVisualStyleBackColor = true;
            // 
            // tabGridHttp
            // 
            this.tabGridHttp.Controls.Add(this.dataGridHttpStatus);
            this.tabGridHttp.Controls.Add(this.panel3);
            this.tabGridHttp.ImageIndex = 0;
            this.tabGridHttp.Location = new System.Drawing.Point(4, 26);
            this.tabGridHttp.Name = "tabGridHttp";
            this.tabGridHttp.Padding = new System.Windows.Forms.Padding(3);
            this.tabGridHttp.Size = new System.Drawing.Size(755, 404);
            this.tabGridHttp.TabIndex = 1;
            this.tabGridHttp.Text = "Data Grid HTTP Status";
            this.tabGridHttp.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SandyBrown;
            this.panel2.Controls.Add(this.btnGenerate1);
            this.panel2.Controls.Add(this.cboParams1);
            this.panel2.Controls.Add(this.lbParam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 42);
            this.panel2.TabIndex = 3;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.BackColor = System.Drawing.Color.PeachPuff;
            this.btnGenerate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate1.Location = new System.Drawing.Point(141, 12);
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
            this.cboParams1.Location = new System.Drawing.Point(47, 12);
            this.cboParams1.Name = "cboParams1";
            this.cboParams1.Size = new System.Drawing.Size(81, 21);
            this.cboParams1.TabIndex = 3;
            // 
            // lbParam
            // 
            this.lbParam.AutoSize = true;
            this.lbParam.Location = new System.Drawing.Point(9, 15);
            this.lbParam.Name = "lbParam";
            this.lbParam.Size = new System.Drawing.Size(32, 13);
            this.lbParam.TabIndex = 2;
            this.lbParam.Text = "Year:";
            // 
            // zedPercentStatus1
            // 
            this.zedPercentStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedPercentStatus1.Location = new System.Drawing.Point(3, 45);
            this.zedPercentStatus1.Name = "zedPercentStatus1";
            this.zedPercentStatus1.ScrollGrace = 0;
            this.zedPercentStatus1.ScrollMaxX = 0;
            this.zedPercentStatus1.ScrollMaxY = 0;
            this.zedPercentStatus1.ScrollMaxY2 = 0;
            this.zedPercentStatus1.ScrollMinX = 0;
            this.zedPercentStatus1.ScrollMinY = 0;
            this.zedPercentStatus1.ScrollMinY2 = 0;
            this.zedPercentStatus1.Size = new System.Drawing.Size(747, 354);
            this.zedPercentStatus1.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dataGridHttpStatus
            // 
            this.dataGridHttpStatus.AllowUserToAddRows = false;
            this.dataGridHttpStatus.AllowUserToDeleteRows = false;
            this.dataGridHttpStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHttpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHttpStatus.Location = new System.Drawing.Point(3, 45);
            this.dataGridHttpStatus.Name = "dataGridHttpStatus";
            this.dataGridHttpStatus.ReadOnly = true;
            this.dataGridHttpStatus.Size = new System.Drawing.Size(749, 356);
            this.dataGridHttpStatus.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SandyBrown;
            this.panel3.Controls.Add(this.btnGenerate2);
            this.panel3.Controls.Add(this.cboParams2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(749, 42);
            this.panel3.TabIndex = 5;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.PeachPuff;
            this.btnGenerate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate2.Location = new System.Drawing.Point(141, 12);
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
            this.cboParams2.Location = new System.Drawing.Point(47, 12);
            this.cboParams2.Name = "cboParams2";
            this.cboParams2.Size = new System.Drawing.Size(81, 21);
            this.cboParams2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year:";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // AccessStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabAccessStatus);
            this.Name = "AccessStatusControl";
            this.Size = new System.Drawing.Size(761, 432);
            this.Resize += new System.EventHandler(this.AccessStatusControl_Resize);
            this.tabAccessStatus.ResumeLayout(false);
            this.tabPercentHttp.ResumeLayout(false);
            this.tabGridHttp.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHttpStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAccessStatus;
        private System.Windows.Forms.TabPage tabPercentHttp;
        private System.Windows.Forms.TabPage tabGridHttp;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label lbParam;
        private ZedGraph.ZedGraphControl zedPercentStatus1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridHttpStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboParams2;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
