namespace Indihiang.Modules
{
    partial class IPAddressControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPAddressControl));
            this.tabIPAddress = new System.Windows.Forms.TabControl();
            this.tabIPAccess = new System.Windows.Forms.TabPage();
            this.zedIPAccess1 = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.tabIPGrid = new System.Windows.Forms.TabPage();
            this.dataGridIP = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboParams2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabIPPage = new System.Windows.Forms.TabPage();
            this.dataGridIPPage = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate3 = new System.Windows.Forms.Button();
            this.cboParams3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIPAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundGraph = new System.ComponentModel.BackgroundWorker();
            this.backgroundGrid1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundGrid2 = new System.ComponentModel.BackgroundWorker();
            this.tabIPAddress.SuspendLayout();
            this.tabIPAccess.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabIPGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIP)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabIPPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIPPage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabIPAddress
            // 
            this.tabIPAddress.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabIPAddress.Controls.Add(this.tabIPAccess);
            this.tabIPAddress.Controls.Add(this.tabIPGrid);
            this.tabIPAddress.Controls.Add(this.tabIPPage);
            this.tabIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIPAddress.ImageList = this.imageList1;
            this.tabIPAddress.Location = new System.Drawing.Point(0, 0);
            this.tabIPAddress.Name = "tabIPAddress";
            this.tabIPAddress.SelectedIndex = 0;
            this.tabIPAddress.Size = new System.Drawing.Size(699, 420);
            this.tabIPAddress.TabIndex = 0;
            // 
            // tabIPAccess
            // 
            this.tabIPAccess.Controls.Add(this.zedIPAccess1);
            this.tabIPAccess.Controls.Add(this.panel2);
            this.tabIPAccess.ImageIndex = 0;
            this.tabIPAccess.Location = new System.Drawing.Point(4, 26);
            this.tabIPAccess.Name = "tabIPAccess";
            this.tabIPAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabIPAccess.Size = new System.Drawing.Size(691, 390);
            this.tabIPAccess.TabIndex = 0;
            this.tabIPAccess.Text = "IP Access";
            this.tabIPAccess.UseVisualStyleBackColor = true;
            // 
            // zedIPAccess1
            // 
            this.zedIPAccess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedIPAccess1.Location = new System.Drawing.Point(3, 45);
            this.zedIPAccess1.Name = "zedIPAccess1";
            this.zedIPAccess1.ScrollGrace = 0;
            this.zedIPAccess1.ScrollMaxX = 0;
            this.zedIPAccess1.ScrollMaxY = 0;
            this.zedIPAccess1.ScrollMaxY2 = 0;
            this.zedIPAccess1.ScrollMinX = 0;
            this.zedIPAccess1.ScrollMinY = 0;
            this.zedIPAccess1.ScrollMinY2 = 0;
            this.zedIPAccess1.Size = new System.Drawing.Size(685, 342);
            this.zedIPAccess1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCoral;
            this.panel2.Controls.Add(this.btnGenerate1);
            this.panel2.Controls.Add(this.cboParams1);
            this.panel2.Controls.Add(this.lbParam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 42);
            this.panel2.TabIndex = 2;
            // 
            // btnGenerate1
            // 
            this.btnGenerate1.BackColor = System.Drawing.Color.Moccasin;
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
            // tabIPGrid
            // 
            this.tabIPGrid.Controls.Add(this.dataGridIP);
            this.tabIPGrid.Controls.Add(this.panel3);
            this.tabIPGrid.ImageIndex = 0;
            this.tabIPGrid.Location = new System.Drawing.Point(4, 26);
            this.tabIPGrid.Name = "tabIPGrid";
            this.tabIPGrid.Size = new System.Drawing.Size(693, 392);
            this.tabIPGrid.TabIndex = 2;
            this.tabIPGrid.Text = "IP Access Grid";
            this.tabIPGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridIP
            // 
            this.dataGridIP.AllowUserToAddRows = false;
            this.dataGridIP.AllowUserToDeleteRows = false;
            this.dataGridIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridIP.Location = new System.Drawing.Point(0, 42);
            this.dataGridIP.Name = "dataGridIP";
            this.dataGridIP.ReadOnly = true;
            this.dataGridIP.Size = new System.Drawing.Size(693, 350);
            this.dataGridIP.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Controls.Add(this.btnGenerate2);
            this.panel3.Controls.Add(this.cboParams2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(693, 42);
            this.panel3.TabIndex = 3;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.Moccasin;
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
            // tabIPPage
            // 
            this.tabIPPage.Controls.Add(this.dataGridIPPage);
            this.tabIPPage.Controls.Add(this.panel1);
            this.tabIPPage.ImageIndex = 0;
            this.tabIPPage.Location = new System.Drawing.Point(4, 26);
            this.tabIPPage.Name = "tabIPPage";
            this.tabIPPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabIPPage.Size = new System.Drawing.Size(693, 392);
            this.tabIPPage.TabIndex = 1;
            this.tabIPPage.Text = "IP/Page Access";
            this.tabIPPage.UseVisualStyleBackColor = true;
            // 
            // dataGridIPPage
            // 
            this.dataGridIPPage.AllowUserToAddRows = false;
            this.dataGridIPPage.AllowUserToDeleteRows = false;
            this.dataGridIPPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIPPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridIPPage.Location = new System.Drawing.Point(3, 45);
            this.dataGridIPPage.Name = "dataGridIPPage";
            this.dataGridIPPage.ReadOnly = true;
            this.dataGridIPPage.Size = new System.Drawing.Size(687, 344);
            this.dataGridIPPage.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.btnGenerate3);
            this.panel1.Controls.Add(this.cboParams3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbIPAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerate3
            // 
            this.btnGenerate3.BackColor = System.Drawing.Color.PeachPuff;
            this.btnGenerate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate3.Location = new System.Drawing.Point(438, 10);
            this.btnGenerate3.Name = "btnGenerate3";
            this.btnGenerate3.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate3.TabIndex = 6;
            this.btnGenerate3.Text = "Generate";
            this.btnGenerate3.UseVisualStyleBackColor = false;
            this.btnGenerate3.Click += new System.EventHandler(this.btnGenerate3_Click);
            // 
            // cboParams3
            // 
            this.cboParams3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams3.FormattingEnabled = true;
            this.cboParams3.Location = new System.Drawing.Point(51, 11);
            this.cboParams3.Name = "cboParams3";
            this.cboParams3.Size = new System.Drawing.Size(81, 21);
            this.cboParams3.TabIndex = 5;
            this.cboParams3.SelectedIndexChanged += new System.EventHandler(this.cboParams3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year:";
            // 
            // cmbIPAddress
            // 
            this.cmbIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIPAddress.FormattingEnabled = true;
            this.cmbIPAddress.Location = new System.Drawing.Point(253, 11);
            this.cmbIPAddress.Name = "cmbIPAddress";
            this.cmbIPAddress.Size = new System.Drawing.Size(174, 21);
            this.cmbIPAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(144, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose IP Address:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // backgroundGraph
            // 
            this.backgroundGraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundGraph_DoWork);
            this.backgroundGraph.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundGraph_RunWorkerCompleted);
            // 
            // backgroundGrid1
            // 
            this.backgroundGrid1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundGrid1_DoWork);
            this.backgroundGrid1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundGrid1_RunWorkerCompleted);
            // 
            // backgroundGrid2
            // 
            this.backgroundGrid2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundGrid2_DoWork);
            this.backgroundGrid2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundGrid2_RunWorkerCompleted);
            // 
            // IPAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabIPAddress);
            this.Name = "IPAddressControl";
            this.Size = new System.Drawing.Size(699, 420);
            this.Resize += new System.EventHandler(this.IPAddressControl_Resize);
            this.tabIPAddress.ResumeLayout(false);
            this.tabIPAccess.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabIPGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIP)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabIPPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIPPage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabIPAddress;
        private System.Windows.Forms.TabPage tabIPAccess;
        private System.Windows.Forms.TabPage tabIPPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridIPPage;
        private System.Windows.Forms.ComboBox cmbIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabIPGrid;
        private ZedGraph.ZedGraphControl zedIPAccess1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label lbParam;
        private System.Windows.Forms.DataGridView dataGridIP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboParams2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParams3;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundGraph;
        private System.ComponentModel.BackgroundWorker backgroundGrid1;
        private System.ComponentModel.BackgroundWorker backgroundGrid2;
        private System.Windows.Forms.Button btnGenerate3;
    }
}
