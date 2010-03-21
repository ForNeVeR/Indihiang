namespace Indihiang.Modules
{
    partial class RequestProcessingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestProcessingControl));
            this.tabRequest = new System.Windows.Forms.TabControl();
            this.tabRequestProc = new System.Windows.Forms.TabPage();
            this.dataGridViewRequest = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGenerate1 = new System.Windows.Forms.Button();
            this.cboParams1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbTotal = new System.Windows.Forms.Label();
            this.tabRequest.SuspendLayout();
            this.tabRequestProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRequest
            // 
            this.tabRequest.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabRequest.Controls.Add(this.tabRequestProc);
            this.tabRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRequest.ImageList = this.imageList1;
            this.tabRequest.Location = new System.Drawing.Point(0, 0);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.SelectedIndex = 0;
            this.tabRequest.Size = new System.Drawing.Size(726, 459);
            this.tabRequest.TabIndex = 0;
            // 
            // tabRequestProc
            // 
            this.tabRequestProc.BackColor = System.Drawing.SystemColors.Control;
            this.tabRequestProc.Controls.Add(this.dataGridViewRequest);
            this.tabRequestProc.Controls.Add(this.panel3);
            this.tabRequestProc.ImageIndex = 0;
            this.tabRequestProc.Location = new System.Drawing.Point(4, 26);
            this.tabRequestProc.Name = "tabRequestProc";
            this.tabRequestProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequestProc.Size = new System.Drawing.Size(718, 429);
            this.tabRequestProc.TabIndex = 0;
            this.tabRequestProc.Text = "Request Processing";
            // 
            // dataGridViewRequest
            // 
            this.dataGridViewRequest.AllowUserToAddRows = false;
            this.dataGridViewRequest.AllowUserToDeleteRows = false;
            this.dataGridViewRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRequest.Location = new System.Drawing.Point(3, 45);
            this.dataGridViewRequest.Name = "dataGridViewRequest";
            this.dataGridViewRequest.ReadOnly = true;
            this.dataGridViewRequest.Size = new System.Drawing.Size(712, 381);
            this.dataGridViewRequest.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Controls.Add(this.lbTotal);
            this.panel3.Controls.Add(this.btnGenerate1);
            this.panel3.Controls.Add(this.cboParams1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 42);
            this.panel3.TabIndex = 5;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
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
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(674, 22);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTotal.Size = new System.Drawing.Size(35, 13);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "label1";
            this.lbTotal.Visible = false;
            // 
            // RequestProcessingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabRequest);
            this.Name = "RequestProcessingControl";
            this.Size = new System.Drawing.Size(726, 459);
            this.tabRequest.ResumeLayout(false);
            this.tabRequestProc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRequest;
        private System.Windows.Forms.TabPage tabRequestProc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridViewRequest;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGenerate1;
        private System.Windows.Forms.ComboBox cboParams1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbTotal;
    }
}
