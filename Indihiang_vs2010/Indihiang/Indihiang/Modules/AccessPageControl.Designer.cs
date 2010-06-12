namespace Indihiang.Modules
{
    partial class AccessPageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessPageControl));
            this.tabAccessPage = new System.Windows.Forms.TabControl();
            this.tabPageAccess = new System.Windows.Forms.TabPage();
            this.zedAccessPage1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.tabPageGrid = new System.Windows.Forms.TabPage();
            this.dataGridAccess = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboParams2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundJob = new System.ComponentModel.BackgroundWorker();
            this.backgroundJobGraph = new System.ComponentModel.BackgroundWorker();
            this.backgroundJobGrid = new System.ComponentModel.BackgroundWorker();
            this.tabAccessPage.SuspendLayout();
            this.tabPageAccess.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccess)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAccessPage
            // 
            this.tabAccessPage.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabAccessPage.Controls.Add(this.tabPageAccess);
            this.tabAccessPage.Controls.Add(this.tabPageGrid);
            this.tabAccessPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAccessPage.ImageList = this.imageList1;
            this.tabAccessPage.Location = new System.Drawing.Point(0, 0);
            this.tabAccessPage.Name = "tabAccessPage";
            this.tabAccessPage.SelectedIndex = 0;
            this.tabAccessPage.Size = new System.Drawing.Size(783, 438);
            this.tabAccessPage.TabIndex = 0;
            // 
            // tabPageAccess
            // 
            this.tabPageAccess.Controls.Add(this.zedAccessPage1);
            this.tabPageAccess.Controls.Add(this.panel1);
            this.tabPageAccess.ImageIndex = 0;
            this.tabPageAccess.Location = new System.Drawing.Point(4, 26);
            this.tabPageAccess.Name = "tabPageAccess";
            this.tabPageAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccess.Size = new System.Drawing.Size(775, 408);
            this.tabPageAccess.TabIndex = 0;
            this.tabPageAccess.Text = "Access Page";
            this.tabPageAccess.UseVisualStyleBackColor = true;
            // 
            // zedAccessPage1
            // 
            this.zedAccessPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedAccessPage1.Location = new System.Drawing.Point(3, 45);
            this.zedAccessPage1.Name = "zedAccessPage1";
            this.zedAccessPage1.ScrollGrace = 0;
            this.zedAccessPage1.ScrollMaxX = 0;
            this.zedAccessPage1.ScrollMaxY = 0;
            this.zedAccessPage1.ScrollMaxY2 = 0;
            this.zedAccessPage1.ScrollMinX = 0;
            this.zedAccessPage1.ScrollMinY = 0;
            this.zedAccessPage1.ScrollMinY2 = 0;
            this.zedAccessPage1.Size = new System.Drawing.Size(769, 360);
            this.zedAccessPage1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.btnGenerate1);
            this.panel1.Controls.Add(this.cboParams1);
            this.panel1.Controls.Add(this.lbParam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.BackColor = System.Drawing.Color.PaleGoldenrod;
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
            // tabPageGrid
            // 
            this.tabPageGrid.Controls.Add(this.dataGridAccess);
            this.tabPageGrid.Controls.Add(this.panel2);
            this.tabPageGrid.ImageIndex = 0;
            this.tabPageGrid.Location = new System.Drawing.Point(4, 26);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrid.Size = new System.Drawing.Size(777, 410);
            this.tabPageGrid.TabIndex = 1;
            this.tabPageGrid.Text = "Grid Data";
            this.tabPageGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridAccess
            // 
            this.dataGridAccess.AllowUserToAddRows = false;
            this.dataGridAccess.AllowUserToDeleteRows = false;
            this.dataGridAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAccess.Location = new System.Drawing.Point(3, 45);
            this.dataGridAccess.Name = "dataGridAccess";
            this.dataGridAccess.ReadOnly = true;
            this.dataGridAccess.Size = new System.Drawing.Size(771, 362);
            this.dataGridAccess.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Controls.Add(this.btnGenerate2);
            this.panel2.Controls.Add(this.cboParams2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 42);
            this.panel2.TabIndex = 2;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnGenerate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate2.Location = new System.Drawing.Point(173, 12);
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
            this.cboParams2.Size = new System.Drawing.Size(112, 21);
            this.cboParams2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
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
            // backgroundJobGraph
            // 
            this.backgroundJobGraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJobGraph_DoWork);
            this.backgroundJobGraph.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJobGraph_RunWorkerCompleted);
            // 
            // backgroundJobGrid
            // 
            this.backgroundJobGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJobGrid_DoWork);
            this.backgroundJobGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJobGrid_RunWorkerCompleted);
            // 
            // AccessPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabAccessPage);
            this.Name = "AccessPageControl";
            this.Size = new System.Drawing.Size(783, 438);
            this.Resize += new System.EventHandler(this.AccessPageControl_Resize);
            this.tabAccessPage.ResumeLayout(false);
            this.tabPageAccess.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccess)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAccessPage;
        private System.Windows.Forms.TabPage tabPageAccess;
        private System.Windows.Forms.TabPage tabPageGrid;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundJob;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label lbParam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboParams2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridAccess;
        private System.ComponentModel.BackgroundWorker backgroundJobGraph;
        private System.ComponentModel.BackgroundWorker backgroundJobGrid;
        private ZedGraph.ZedGraphControl zedAccessPage1;

    }
}
