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
            this.tabHitsPerMonth = new System.Windows.Forms.TabPage();
            this.zedHits2 = new ZedGraph.ZedGraphControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabHitsData = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHitsData = new System.Windows.Forms.ComboBox();
            this.dataGridHits = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabHitPerDay.SuspendLayout();
            this.tabHitsPerMonth.SuspendLayout();
            this.tabHitsData.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHits)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(690, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHitPerDay
            // 
            this.tabHitPerDay.Controls.Add(this.zedHits1);
            this.tabHitPerDay.ImageIndex = 0;
            this.tabHitPerDay.Location = new System.Drawing.Point(4, 26);
            this.tabHitPerDay.Name = "tabHitPerDay";
            this.tabHitPerDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabHitPerDay.Size = new System.Drawing.Size(682, 365);
            this.tabHitPerDay.TabIndex = 0;
            this.tabHitPerDay.Text = "Hits per Day";
            this.tabHitPerDay.UseVisualStyleBackColor = true;
            // 
            // zedHits1
            // 
            this.zedHits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedHits1.Location = new System.Drawing.Point(3, 3);
            this.zedHits1.Name = "zedHits1";
            this.zedHits1.ScrollGrace = 0;
            this.zedHits1.ScrollMaxX = 0;
            this.zedHits1.ScrollMaxY = 0;
            this.zedHits1.ScrollMaxY2 = 0;
            this.zedHits1.ScrollMinX = 0;
            this.zedHits1.ScrollMinY = 0;
            this.zedHits1.ScrollMinY2 = 0;
            this.zedHits1.Size = new System.Drawing.Size(676, 359);
            this.zedHits1.TabIndex = 0;
            this.zedHits1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedHits1_PointValueEvent);
            // 
            // tabHitsPerMonth
            // 
            this.tabHitsPerMonth.Controls.Add(this.zedHits2);
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
            this.zedHits2.Location = new System.Drawing.Point(3, 3);
            this.zedHits2.Name = "zedHits2";
            this.zedHits2.ScrollGrace = 0;
            this.zedHits2.ScrollMaxX = 0;
            this.zedHits2.ScrollMaxY = 0;
            this.zedHits2.ScrollMaxY2 = 0;
            this.zedHits2.ScrollMinX = 0;
            this.zedHits2.ScrollMinY = 0;
            this.zedHits2.ScrollMinY2 = 0;
            this.zedHits2.Size = new System.Drawing.Size(676, 359);
            this.zedHits2.TabIndex = 0;
            this.zedHits2.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedHits2_PointValueEvent);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.cboHitsData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Hits Data:";
            // 
            // cboHitsData
            // 
            this.cboHitsData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHitsData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHitsData.FormattingEnabled = true;
            this.cboHitsData.Items.AddRange(new object[] {
            "Hits per Day",
            "Hits per Month"});
            this.cboHitsData.Location = new System.Drawing.Point(118, 12);
            this.cboHitsData.Name = "cboHitsData";
            this.cboHitsData.Size = new System.Drawing.Size(174, 21);
            this.cboHitsData.TabIndex = 1;
            this.cboHitsData.SelectedIndexChanged += new System.EventHandler(this.cboHitsData_SelectedIndexChanged);
            // 
            // dataGridHits
            // 
            this.dataGridHits.AllowUserToAddRows = false;
            this.dataGridHits.AllowUserToDeleteRows = false;
            this.dataGridHits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHits.Location = new System.Drawing.Point(0, 50);
            this.dataGridHits.Name = "dataGridHits";
            this.dataGridHits.ReadOnly = true;
            this.dataGridHits.Size = new System.Drawing.Size(682, 315);
            this.dataGridHits.TabIndex = 1;
            // 
            // HitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "HitsControl";
            this.Size = new System.Drawing.Size(690, 395);
            this.Resize += new System.EventHandler(this.HitsControl_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabHitPerDay.ResumeLayout(false);
            this.tabHitsPerMonth.ResumeLayout(false);
            this.tabHitsData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHitPerDay;
        private System.Windows.Forms.TabPage tabHitsPerMonth;
        private System.Windows.Forms.ImageList imageList1;
        private ZedGraph.ZedGraphControl zedHits1;
        private ZedGraph.ZedGraphControl zedHits2;
        private System.Windows.Forms.TabPage tabHitsData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboHitsData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridHits;

    }
}
