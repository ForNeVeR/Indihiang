namespace Indihiang.Modules
{
    partial class HitsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitsControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHitPerDay = new System.Windows.Forms.TabPage();
            this.zedHits1 = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboYear1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabHitsPerMonth = new System.Windows.Forms.TabPage();
            this.zedHits2 = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboYear2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabHitsData = new System.Windows.Forms.TabPage();
            this.dataGridHits = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate3 = new System.Windows.Forms.Button();
            this.cboYear3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHitsData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundJobHitsDay = new System.ComponentModel.BackgroundWorker();
            this.backgroundJobHitsMonth = new System.ComponentModel.BackgroundWorker();
            this.backgroundJobHitsDataGrid = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabHitPerDay.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabHitsPerMonth.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabHitsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHits)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabHitPerDay);
            this.tabControl1.Controls.Add(this.tabHitsPerMonth);
            this.tabControl1.Controls.Add(this.tabHitsData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 393);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHitPerDay
            // 
            this.tabHitPerDay.Controls.Add(this.zedHits1);
            this.tabHitPerDay.Controls.Add(this.panel2);
            this.tabHitPerDay.ImageIndex = 0;
            this.tabHitPerDay.Location = new System.Drawing.Point(4, 26);
            this.tabHitPerDay.Name = "tabHitPerDay";
            this.tabHitPerDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabHitPerDay.Size = new System.Drawing.Size(680, 363);
            this.tabHitPerDay.TabIndex = 0;
            this.tabHitPerDay.Text = "Hits per Day";
            this.tabHitPerDay.UseVisualStyleBackColor = true;
            // 
            // zedHits1
            // 
            this.zedHits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedHits1.Location = new System.Drawing.Point(3, 43);
            this.zedHits1.Name = "zedHits1";
            this.zedHits1.ScrollGrace = 0;
            this.zedHits1.ScrollMaxX = 0;
            this.zedHits1.ScrollMaxY = 0;
            this.zedHits1.ScrollMaxY2 = 0;
            this.zedHits1.ScrollMinX = 0;
            this.zedHits1.ScrollMinY = 0;
            this.zedHits1.ScrollMinY2 = 0;
            this.zedHits1.Size = new System.Drawing.Size(674, 317);
            this.zedHits1.TabIndex = 1;
            this.zedHits1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedHits1_PointValueEvent);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel2.Controls.Add(this.btnGenerate1);
            this.panel2.Controls.Add(this.cboYear1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 40);
            this.panel2.TabIndex = 0;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnGenerate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate1.Location = new System.Drawing.Point(182, 8);
            this.btnGenerate1.Name = "btnGenerate1";
            this.btnGenerate1.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate1.TabIndex = 2;
            this.btnGenerate1.Text = "Generate";
            this.btnGenerate1.UseVisualStyleBackColor = false;
            this.btnGenerate1.Click += new System.EventHandler(this.btnGenerate1_Click);
            // 
            // cboYear1
            // 
            this.cboYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear1.FormattingEnabled = true;
            this.cboYear1.Location = new System.Drawing.Point(55, 10);
            this.cboYear1.Name = "cboYear1";
            this.cboYear1.Size = new System.Drawing.Size(121, 21);
            this.cboYear1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Year: ";
            // 
            // tabHitsPerMonth
            // 
            this.tabHitsPerMonth.Controls.Add(this.zedHits2);
            this.tabHitsPerMonth.Controls.Add(this.panel3);
            this.tabHitsPerMonth.ImageIndex = 0;
            this.tabHitsPerMonth.Location = new System.Drawing.Point(4, 26);
            this.tabHitsPerMonth.Name = "tabHitsPerMonth";
            this.tabHitsPerMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tabHitsPerMonth.Size = new System.Drawing.Size(682, 365);
            this.tabHitsPerMonth.TabIndex = 1;
            this.tabHitsPerMonth.Text = "Hits per Month";
            this.tabHitsPerMonth.UseVisualStyleBackColor = true;
            // 
            // zedHits2
            // 
            this.zedHits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedHits2.Location = new System.Drawing.Point(3, 43);
            this.zedHits2.Name = "zedHits2";
            this.zedHits2.ScrollGrace = 0;
            this.zedHits2.ScrollMaxX = 0;
            this.zedHits2.ScrollMaxY = 0;
            this.zedHits2.ScrollMaxY2 = 0;
            this.zedHits2.ScrollMinX = 0;
            this.zedHits2.ScrollMinY = 0;
            this.zedHits2.ScrollMinY2 = 0;
            this.zedHits2.Size = new System.Drawing.Size(676, 319);
            this.zedHits2.TabIndex = 2;
            this.zedHits2.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedHits2_PointValueEvent);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.btnGenerate2);
            this.panel3.Controls.Add(this.cboYear2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(676, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.Violet;
            this.btnGenerate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate2.Location = new System.Drawing.Point(182, 8);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate2.TabIndex = 5;
            this.btnGenerate2.Text = "Generate";
            this.btnGenerate2.UseVisualStyleBackColor = false;
            this.btnGenerate2.Click += new System.EventHandler(this.btnGenerate2_Click);
            // 
            // cboYear2
            // 
            this.cboYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear2.FormattingEnabled = true;
            this.cboYear2.Location = new System.Drawing.Point(55, 10);
            this.cboYear2.Name = "cboYear2";
            this.cboYear2.Size = new System.Drawing.Size(121, 21);
            this.cboYear2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Year: ";
            // 
            // tabHitsData
            // 
            this.tabHitsData.Controls.Add(this.dataGridHits);
            this.tabHitsData.Controls.Add(this.panel1);
            this.tabHitsData.ImageIndex = 0;
            this.tabHitsData.Location = new System.Drawing.Point(4, 26);
            this.tabHitsData.Name = "tabHitsData";
            this.tabHitsData.Size = new System.Drawing.Size(682, 365);
            this.tabHitsData.TabIndex = 2;
            this.tabHitsData.Text = "Hits Data";
            this.tabHitsData.UseVisualStyleBackColor = true;
            // 
            // dataGridHits
            // 
            this.dataGridHits.AllowUserToAddRows = false;
            this.dataGridHits.AllowUserToDeleteRows = false;
            this.dataGridHits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHits.Location = new System.Drawing.Point(0, 40);
            this.dataGridHits.Name = "dataGridHits";
            this.dataGridHits.ReadOnly = true;
            this.dataGridHits.Size = new System.Drawing.Size(682, 325);
            this.dataGridHits.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnGenerate3);
            this.panel1.Controls.Add(this.cboYear3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboHitsData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 40);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerate3
            // 
            this.btnGenerate3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate3.Location = new System.Drawing.Point(463, 7);
            this.btnGenerate3.Name = "btnGenerate3";
            this.btnGenerate3.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate3.TabIndex = 6;
            this.btnGenerate3.Text = "Generate";
            this.btnGenerate3.UseVisualStyleBackColor = false;
            this.btnGenerate3.Click += new System.EventHandler(this.btnGenerate3_Click);
            // 
            // cboYear3
            // 
            this.cboYear3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear3.FormattingEnabled = true;
            this.cboYear3.Location = new System.Drawing.Point(336, 9);
            this.cboYear3.Name = "cboYear3";
            this.cboYear3.Size = new System.Drawing.Size(112, 21);
            this.cboYear3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(298, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Year:";
            // 
            // cboHitsData
            // 
            this.cboHitsData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHitsData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHitsData.FormattingEnabled = true;
            this.cboHitsData.Items.AddRange(new object[] {
            "Hits per Day",
            "Hits per Month"});
            this.cboHitsData.Location = new System.Drawing.Point(118, 9);
            this.cboHitsData.Name = "cboHitsData";
            this.cboHitsData.Size = new System.Drawing.Size(174, 21);
            this.cboHitsData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Hits Data:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // backgroundJobHitsDay
            // 
            this.backgroundJobHitsDay.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJobHitsDay_DoWork);
            this.backgroundJobHitsDay.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJobHitsDay_RunWorkerCompleted);
            // 
            // backgroundJobHitsMonth
            // 
            this.backgroundJobHitsMonth.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJobHitsMonth_DoWork);
            this.backgroundJobHitsMonth.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJobHitsMonth_RunWorkerCompleted);
            // 
            // backgroundJobHitsDataGrid
            // 
            this.backgroundJobHitsDataGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundJobHitsDataGrid_DoWork);
            this.backgroundJobHitsDataGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundJobHitsDataGrid_RunWorkerCompleted);
            // 
            // HitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabControl1);
            this.Name = "HitsControl";
            this.Size = new System.Drawing.Size(688, 393);
            this.Resize += new System.EventHandler(this.HitsControl_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabHitPerDay.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabHitsPerMonth.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabHitsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHits)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHitPerDay;
        private System.Windows.Forms.TabPage tabHitsPerMonth;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabHitsData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboHitsData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridHits;
        private ZedGraph.ZedGraphControl zedHits1;
        private System.Windows.Forms.Panel panel2;
        private ZedGraph.ZedGraphControl zedHits2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboYear1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboYear2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundJobHitsDay;
        private System.ComponentModel.BackgroundWorker backgroundJobHitsMonth;
        private System.Windows.Forms.ComboBox cboYear3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerate3;
        private System.ComponentModel.BackgroundWorker backgroundJobHitsDataGrid;

    }
}
