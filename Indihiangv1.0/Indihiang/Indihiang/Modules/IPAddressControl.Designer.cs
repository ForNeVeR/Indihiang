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
            this.tabIPPage = new System.Windows.Forms.TabPage();
            this.zedIPAccess1 = new ZedGraph.ZedGraphControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIPAddress = new System.Windows.Forms.ComboBox();
            this.dataGridIPPage = new System.Windows.Forms.DataGridView();
            this.tabIPAddress.SuspendLayout();
            this.tabIPAccess.SuspendLayout();
            this.tabIPPage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIPPage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabIPAddress
            // 
            this.tabIPAddress.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabIPAddress.Controls.Add(this.tabIPAccess);
            this.tabIPAddress.Controls.Add(this.tabIPPage);
            this.tabIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIPAddress.ImageList = this.imageList1;
            this.tabIPAddress.Location = new System.Drawing.Point(0, 0);
            this.tabIPAddress.Name = "tabIPAddress";
            this.tabIPAddress.SelectedIndex = 0;
            this.tabIPAddress.Size = new System.Drawing.Size(701, 422);
            this.tabIPAddress.TabIndex = 0;
            // 
            // tabIPAccess
            // 
            this.tabIPAccess.Controls.Add(this.zedIPAccess1);
            this.tabIPAccess.ImageIndex = 0;
            this.tabIPAccess.Location = new System.Drawing.Point(4, 26);
            this.tabIPAccess.Name = "tabIPAccess";
            this.tabIPAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabIPAccess.Size = new System.Drawing.Size(693, 392);
            this.tabIPAccess.TabIndex = 0;
            this.tabIPAccess.Text = "IP Access";
            this.tabIPAccess.UseVisualStyleBackColor = true;
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
            // zedIPAccess1
            // 
            this.zedIPAccess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedIPAccess1.Location = new System.Drawing.Point(3, 3);
            this.zedIPAccess1.Name = "zedIPAccess1";
            this.zedIPAccess1.ScrollGrace = 0;
            this.zedIPAccess1.ScrollMaxX = 0;
            this.zedIPAccess1.ScrollMaxY = 0;
            this.zedIPAccess1.ScrollMaxY2 = 0;
            this.zedIPAccess1.ScrollMinX = 0;
            this.zedIPAccess1.ScrollMinY = 0;
            this.zedIPAccess1.ScrollMinY2 = 0;
            this.zedIPAccess1.Size = new System.Drawing.Size(687, 386);
            this.zedIPAccess1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbIPAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 49);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose IP Address:";
            // 
            // cmbIPAddress
            // 
            this.cmbIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIPAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIPAddress.FormattingEnabled = true;
            this.cmbIPAddress.Location = new System.Drawing.Point(119, 13);
            this.cmbIPAddress.Name = "cmbIPAddress";
            this.cmbIPAddress.Size = new System.Drawing.Size(240, 21);
            this.cmbIPAddress.TabIndex = 1;
            // 
            // dataGridIPPage
            // 
            this.dataGridIPPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIPPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridIPPage.Location = new System.Drawing.Point(3, 52);
            this.dataGridIPPage.Name = "dataGridIPPage";
            this.dataGridIPPage.Size = new System.Drawing.Size(687, 337);
            this.dataGridIPPage.TabIndex = 1;
            // 
            // IPAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabIPAddress);
            this.Name = "IPAddressControl";
            this.Size = new System.Drawing.Size(701, 422);
            this.Resize += new System.EventHandler(this.IPAddressControl_Resize);
            this.tabIPAddress.ResumeLayout(false);
            this.tabIPAccess.ResumeLayout(false);
            this.tabIPPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIPPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabIPAddress;
        private System.Windows.Forms.TabPage tabIPAccess;
        private System.Windows.Forms.TabPage tabIPPage;
        private ZedGraph.ZedGraphControl zedIPAccess1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridIPPage;
        private System.Windows.Forms.ComboBox cmbIPAddress;
        private System.Windows.Forms.Label label1;
    }
}
