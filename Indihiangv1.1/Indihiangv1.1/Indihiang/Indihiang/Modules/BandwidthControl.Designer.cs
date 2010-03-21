namespace Indihiang.Modules
{
    partial class BandwidthControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BandwidthControl));
            this.tabBandwidth = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.lbBytesReceived = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbBytesSent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageBWHit = new System.Windows.Forms.TabPage();
            this.zedGraphBytesInOut = new ZedGraph.ZedGraphControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.tabPageBWHitGrid = new System.Windows.Forms.TabPage();
            this.dataGridViewBytes2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewBytes1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.cboParams2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageBWHitGrid2 = new System.Windows.Forms.TabPage();
            this.dataGridViewByteReceived2 = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridViewByteReceived1 = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnGenerate3 = new System.Windows.Forms.Button();
            this.cboParams3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabBWIPClientGrid = new System.Windows.Forms.TabPage();
            this.dataGridViewIPClient = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnGenerate4 = new System.Windows.Forms.Button();
            this.cboParams4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.tabBandwidth.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageBWHit.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPageBWHitGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageBWHitGrid2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewByteReceived2)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewByteReceived1)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabBWIPClientGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIPClient)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBandwidth
            // 
            this.tabBandwidth.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabBandwidth.Controls.Add(this.tabPageGeneral);
            this.tabBandwidth.Controls.Add(this.tabPageBWHit);
            this.tabBandwidth.Controls.Add(this.tabPageBWHitGrid);
            this.tabBandwidth.Controls.Add(this.tabPageBWHitGrid2);
            this.tabBandwidth.Controls.Add(this.tabBWIPClientGrid);
            this.tabBandwidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBandwidth.ImageList = this.imageList1;
            this.tabBandwidth.Location = new System.Drawing.Point(0, 0);
            this.tabBandwidth.Name = "tabBandwidth";
            this.tabBandwidth.SelectedIndex = 0;
            this.tabBandwidth.Size = new System.Drawing.Size(809, 432);
            this.tabBandwidth.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPageGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageGeneral.Controls.Add(this.lbBytesReceived);
            this.tabPageGeneral.Controls.Add(this.label5);
            this.tabPageGeneral.Controls.Add(this.lbBytesSent);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.lbTotal);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.ImageIndex = 0;
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(801, 402);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // lbBytesReceived
            // 
            this.lbBytesReceived.AutoSize = true;
            this.lbBytesReceived.Location = new System.Drawing.Point(154, 89);
            this.lbBytesReceived.Name = "lbBytesReceived";
            this.lbBytesReceived.Size = new System.Drawing.Size(13, 13);
            this.lbBytesReceived.TabIndex = 5;
            this.lbBytesReceived.Text = "[]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Bytes Received:";
            // 
            // lbBytesSent
            // 
            this.lbBytesSent.AutoSize = true;
            this.lbBytesSent.Location = new System.Drawing.Point(154, 63);
            this.lbBytesSent.Name = "lbBytesSent";
            this.lbBytesSent.Size = new System.Drawing.Size(13, 13);
            this.lbBytesSent.TabIndex = 3;
            this.lbBytesSent.Text = "[]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Bytes Sent:";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(154, 40);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(13, 13);
            this.lbTotal.TabIndex = 1;
            this.lbTotal.Text = "[]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Bytes:";
            // 
            // tabPageBWHit
            // 
            this.tabPageBWHit.Controls.Add(this.zedGraphBytesInOut);
            this.tabPageBWHit.Controls.Add(this.panel9);
            this.tabPageBWHit.ImageIndex = 0;
            this.tabPageBWHit.Location = new System.Drawing.Point(4, 26);
            this.tabPageBWHit.Name = "tabPageBWHit";
            this.tabPageBWHit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBWHit.Size = new System.Drawing.Size(801, 402);
            this.tabPageBWHit.TabIndex = 1;
            this.tabPageBWHit.Text = "Bytes In/Out";
            this.tabPageBWHit.UseVisualStyleBackColor = true;
            // 
            // zedGraphBytesInOut
            // 
            this.zedGraphBytesInOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphBytesInOut.Location = new System.Drawing.Point(3, 45);
            this.zedGraphBytesInOut.Name = "zedGraphBytesInOut";
            this.zedGraphBytesInOut.ScrollGrace = 0;
            this.zedGraphBytesInOut.ScrollMaxX = 0;
            this.zedGraphBytesInOut.ScrollMaxY = 0;
            this.zedGraphBytesInOut.ScrollMaxY2 = 0;
            this.zedGraphBytesInOut.ScrollMinX = 0;
            this.zedGraphBytesInOut.ScrollMinY = 0;
            this.zedGraphBytesInOut.ScrollMinY2 = 0;
            this.zedGraphBytesInOut.Size = new System.Drawing.Size(795, 354);
            this.zedGraphBytesInOut.TabIndex = 5;
            this.zedGraphBytesInOut.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedGraphBytesInOut_PointValueEvent);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.RosyBrown;
            this.panel9.Controls.Add(this.btnGenerate1);
            this.panel9.Controls.Add(this.cboParams1);
            this.panel9.Controls.Add(this.lbParam);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(795, 42);
            this.panel9.TabIndex = 4;
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
            // tabPageBWHitGrid
            // 
            this.tabPageBWHitGrid.Controls.Add(this.dataGridViewBytes2);
            this.tabPageBWHitGrid.Controls.Add(this.panel3);
            this.tabPageBWHitGrid.Controls.Add(this.splitter1);
            this.tabPageBWHitGrid.Controls.Add(this.panel2);
            this.tabPageBWHitGrid.Controls.Add(this.panel1);
            this.tabPageBWHitGrid.ImageIndex = 0;
            this.tabPageBWHitGrid.Location = new System.Drawing.Point(4, 26);
            this.tabPageBWHitGrid.Name = "tabPageBWHitGrid";
            this.tabPageBWHitGrid.Size = new System.Drawing.Size(801, 402);
            this.tabPageBWHitGrid.TabIndex = 3;
            this.tabPageBWHitGrid.Text = "Bytes Sent Per Request Data";
            this.tabPageBWHitGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBytes2
            // 
            this.dataGridViewBytes2.AllowUserToAddRows = false;
            this.dataGridViewBytes2.AllowUserToDeleteRows = false;
            this.dataGridViewBytes2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewBytes2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBytes2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBytes2.Location = new System.Drawing.Point(405, 76);
            this.dataGridViewBytes2.Name = "dataGridViewBytes2";
            this.dataGridViewBytes2.ReadOnly = true;
            this.dataGridViewBytes2.Size = new System.Drawing.Size(396, 326);
            this.dataGridViewBytes2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(405, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 34);
            this.panel3.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bytes Sent Data per Request Page";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.SlateGray;
            this.splitter1.Location = new System.Drawing.Point(395, 42);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 360);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridViewBytes1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 360);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewBytes1
            // 
            this.dataGridViewBytes1.AllowUserToAddRows = false;
            this.dataGridViewBytes1.AllowUserToDeleteRows = false;
            this.dataGridViewBytes1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewBytes1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBytes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBytes1.Location = new System.Drawing.Point(0, 34);
            this.dataGridViewBytes1.Name = "dataGridViewBytes1";
            this.dataGridViewBytes1.ReadOnly = true;
            this.dataGridViewBytes1.Size = new System.Drawing.Size(395, 326);
            this.dataGridViewBytes1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MistyRose;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(395, 34);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bytes Sent Data per Day";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.btnGenerate2);
            this.panel1.Controls.Add(this.cboParams2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.BackColor = System.Drawing.Color.Moccasin;
            this.btnGenerate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate2.Location = new System.Drawing.Point(141, 12);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate2.TabIndex = 7;
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
            this.cboParams2.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Year:";
            // 
            // tabPageBWHitGrid2
            // 
            this.tabPageBWHitGrid2.Controls.Add(this.dataGridViewByteReceived2);
            this.tabPageBWHitGrid2.Controls.Add(this.panel8);
            this.tabPageBWHitGrid2.Controls.Add(this.splitter2);
            this.tabPageBWHitGrid2.Controls.Add(this.panel6);
            this.tabPageBWHitGrid2.Controls.Add(this.panel5);
            this.tabPageBWHitGrid2.ImageIndex = 0;
            this.tabPageBWHitGrid2.Location = new System.Drawing.Point(4, 26);
            this.tabPageBWHitGrid2.Name = "tabPageBWHitGrid2";
            this.tabPageBWHitGrid2.Size = new System.Drawing.Size(801, 402);
            this.tabPageBWHitGrid2.TabIndex = 4;
            this.tabPageBWHitGrid2.Text = "Bytes Received Per Request Data";
            this.tabPageBWHitGrid2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewByteReceived2
            // 
            this.dataGridViewByteReceived2.AllowUserToAddRows = false;
            this.dataGridViewByteReceived2.AllowUserToDeleteRows = false;
            this.dataGridViewByteReceived2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewByteReceived2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewByteReceived2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewByteReceived2.Location = new System.Drawing.Point(390, 76);
            this.dataGridViewByteReceived2.Name = "dataGridViewByteReceived2";
            this.dataGridViewByteReceived2.ReadOnly = true;
            this.dataGridViewByteReceived2.Size = new System.Drawing.Size(411, 326);
            this.dataGridViewByteReceived2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.MistyRose;
            this.panel8.Controls.Add(this.label9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(390, 42);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(411, 34);
            this.panel8.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Bytes Received Data per Request Page";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.SlateGray;
            this.splitter2.Location = new System.Drawing.Point(380, 42);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 360);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridViewByteReceived1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(380, 360);
            this.panel6.TabIndex = 2;
            // 
            // dataGridViewByteReceived1
            // 
            this.dataGridViewByteReceived1.AllowUserToAddRows = false;
            this.dataGridViewByteReceived1.AllowUserToDeleteRows = false;
            this.dataGridViewByteReceived1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewByteReceived1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewByteReceived1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewByteReceived1.Location = new System.Drawing.Point(0, 34);
            this.dataGridViewByteReceived1.Name = "dataGridViewByteReceived1";
            this.dataGridViewByteReceived1.ReadOnly = true;
            this.dataGridViewByteReceived1.Size = new System.Drawing.Size(380, 326);
            this.dataGridViewByteReceived1.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MistyRose;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(380, 34);
            this.panel7.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Bytes Received Data per Day";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RosyBrown;
            this.panel5.Controls.Add(this.btnGenerate3);
            this.panel5.Controls.Add(this.cboParams3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(801, 42);
            this.panel5.TabIndex = 1;
            // 
            // btnGenerate3
            // 
            this.btnGenerate3.BackColor = System.Drawing.Color.Moccasin;
            this.btnGenerate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate3.Location = new System.Drawing.Point(141, 12);
            this.btnGenerate3.Name = "btnGenerate3";
            this.btnGenerate3.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate3.TabIndex = 10;
            this.btnGenerate3.Text = "Generate";
            this.btnGenerate3.UseVisualStyleBackColor = false;
            this.btnGenerate3.Click += new System.EventHandler(this.btnGenerate3_Click);
            // 
            // cboParams3
            // 
            this.cboParams3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams3.FormattingEnabled = true;
            this.cboParams3.Location = new System.Drawing.Point(47, 12);
            this.cboParams3.Name = "cboParams3";
            this.cboParams3.Size = new System.Drawing.Size(81, 21);
            this.cboParams3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Year:";
            // 
            // tabBWIPClientGrid
            // 
            this.tabBWIPClientGrid.Controls.Add(this.dataGridViewIPClient);
            this.tabBWIPClientGrid.Controls.Add(this.panel10);
            this.tabBWIPClientGrid.ImageIndex = 0;
            this.tabBWIPClientGrid.Location = new System.Drawing.Point(4, 26);
            this.tabBWIPClientGrid.Name = "tabBWIPClientGrid";
            this.tabBWIPClientGrid.Size = new System.Drawing.Size(801, 402);
            this.tabBWIPClientGrid.TabIndex = 5;
            this.tabBWIPClientGrid.Text = "Bytes In/Out Per IP Client";
            this.tabBWIPClientGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridViewIPClient
            // 
            this.dataGridViewIPClient.AllowUserToAddRows = false;
            this.dataGridViewIPClient.AllowUserToDeleteRows = false;
            this.dataGridViewIPClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIPClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIPClient.Location = new System.Drawing.Point(0, 42);
            this.dataGridViewIPClient.Name = "dataGridViewIPClient";
            this.dataGridViewIPClient.ReadOnly = true;
            this.dataGridViewIPClient.Size = new System.Drawing.Size(801, 360);
            this.dataGridViewIPClient.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.RosyBrown;
            this.panel10.Controls.Add(this.btnGenerate4);
            this.panel10.Controls.Add(this.cboParams4);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(801, 42);
            this.panel10.TabIndex = 5;
            // 
            // btnGenerate4
            // 
            this.btnGenerate4.BackColor = System.Drawing.Color.Moccasin;
            this.btnGenerate4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate4.Location = new System.Drawing.Point(141, 12);
            this.btnGenerate4.Name = "btnGenerate4";
            this.btnGenerate4.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate4.TabIndex = 4;
            this.btnGenerate4.Text = "Generate";
            this.btnGenerate4.UseVisualStyleBackColor = false;
            this.btnGenerate4.Click += new System.EventHandler(this.btnGenerate4_Click);
            // 
            // cboParams4
            // 
            this.cboParams4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParams4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParams4.FormattingEnabled = true;
            this.cboParams4.Location = new System.Drawing.Point(47, 12);
            this.cboParams4.Name = "cboParams4";
            this.cboParams4.Size = new System.Drawing.Size(81, 21);
            this.cboParams4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Year:";
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
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // backgroundWorker5
            // 
            this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
            this.backgroundWorker5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker5_RunWorkerCompleted);
            // 
            // BandwidthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabBandwidth);
            this.Name = "BandwidthControl";
            this.Size = new System.Drawing.Size(809, 432);
            this.Resize += new System.EventHandler(this.BandwidthControl_Resize);
            this.tabBandwidth.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageBWHit.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tabPageBWHitGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageBWHitGrid2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewByteReceived2)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewByteReceived1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabBWIPClientGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIPClient)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBandwidth;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageBWHit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPageBWHitGrid;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbBytesReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbBytesSent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewBytes2;
        private System.Windows.Forms.DataGridView dataGridViewBytes1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageBWHitGrid2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridViewByteReceived1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewByteReceived2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabBWIPClientGrid;
        private ZedGraph.ZedGraphControl zedGraphBytesInOut;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label lbParam;
        private System.Windows.Forms.Button btnGenerate2;
        private System.Windows.Forms.ComboBox cboParams2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGenerate3;
        private System.Windows.Forms.ComboBox cboParams3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewIPClient;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnGenerate4;
        private System.Windows.Forms.ComboBox cboParams4;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
    }
}
