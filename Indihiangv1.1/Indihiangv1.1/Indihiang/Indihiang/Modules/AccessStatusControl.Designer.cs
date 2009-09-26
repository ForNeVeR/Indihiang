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
            this.zedPercentStatus1 = new ZedGraph.ZedGraphControl();
            this.dataGridHttpStatus = new System.Windows.Forms.DataGridView();
            this.tabAccessStatus.SuspendLayout();
            this.tabPercentHttp.SuspendLayout();
            this.tabGridHttp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHttpStatus)).BeginInit();
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
            this.tabAccessStatus.Size = new System.Drawing.Size(763, 434);
            this.tabAccessStatus.TabIndex = 0;
            // 
            // tabPercentHttp
            // 
            this.tabPercentHttp.Controls.Add(this.zedPercentStatus1);
            this.tabPercentHttp.ImageIndex = 0;
            this.tabPercentHttp.Location = new System.Drawing.Point(4, 26);
            this.tabPercentHttp.Name = "tabPercentHttp";
            this.tabPercentHttp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPercentHttp.Size = new System.Drawing.Size(755, 404);
            this.tabPercentHttp.TabIndex = 0;
            this.tabPercentHttp.Text = "Percent HTTP Status";
            this.tabPercentHttp.UseVisualStyleBackColor = true;
            // 
            // tabGridHttp
            // 
            this.tabGridHttp.Controls.Add(this.dataGridHttpStatus);
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
            // zedPercentStatus1
            // 
            this.zedPercentStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedPercentStatus1.Location = new System.Drawing.Point(3, 3);
            this.zedPercentStatus1.Name = "zedPercentStatus1";
            this.zedPercentStatus1.ScrollGrace = 0;
            this.zedPercentStatus1.ScrollMaxX = 0;
            this.zedPercentStatus1.ScrollMaxY = 0;
            this.zedPercentStatus1.ScrollMaxY2 = 0;
            this.zedPercentStatus1.ScrollMinX = 0;
            this.zedPercentStatus1.ScrollMinY = 0;
            this.zedPercentStatus1.ScrollMinY2 = 0;
            this.zedPercentStatus1.Size = new System.Drawing.Size(749, 398);
            this.zedPercentStatus1.TabIndex = 0;
            // 
            // dataGridHttpStatus
            // 
            this.dataGridHttpStatus.AllowUserToAddRows = false;
            this.dataGridHttpStatus.AllowUserToDeleteRows = false;
            this.dataGridHttpStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHttpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHttpStatus.Location = new System.Drawing.Point(3, 3);
            this.dataGridHttpStatus.Name = "dataGridHttpStatus";
            this.dataGridHttpStatus.ReadOnly = true;
            this.dataGridHttpStatus.Size = new System.Drawing.Size(749, 398);
            this.dataGridHttpStatus.TabIndex = 0;
            // 
            // AccessStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabAccessStatus);
            this.Name = "AccessStatusControl";
            this.Size = new System.Drawing.Size(763, 434);
            this.Resize += new System.EventHandler(this.AccessStatusControl_Resize);
            this.tabAccessStatus.ResumeLayout(false);
            this.tabPercentHttp.ResumeLayout(false);
            this.tabGridHttp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHttpStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAccessStatus;
        private System.Windows.Forms.TabPage tabPercentHttp;
        private System.Windows.Forms.TabPage tabGridHttp;
        private System.Windows.Forms.ImageList imageList1;
        private ZedGraph.ZedGraphControl zedPercentStatus1;
        private System.Windows.Forms.DataGridView dataGridHttpStatus;
    }
}
