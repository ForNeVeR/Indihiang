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
            this.tabPageGrid = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.zedAccessPage1 = new ZedGraph.ZedGraphControl();
            this.dataGridAccess = new System.Windows.Forms.DataGridView();
            this.tabAccessPage.SuspendLayout();
            this.tabPageAccess.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccess)).BeginInit();
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
            this.tabAccessPage.Size = new System.Drawing.Size(785, 440);
            this.tabAccessPage.TabIndex = 0;
            // 
            // tabPageAccess
            // 
            this.tabPageAccess.Controls.Add(this.zedAccessPage1);
            this.tabPageAccess.ImageIndex = 0;
            this.tabPageAccess.Location = new System.Drawing.Point(4, 26);
            this.tabPageAccess.Name = "tabPageAccess";
            this.tabPageAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccess.Size = new System.Drawing.Size(777, 410);
            this.tabPageAccess.TabIndex = 0;
            this.tabPageAccess.Text = "Access Page";
            this.tabPageAccess.UseVisualStyleBackColor = true;
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Controls.Add(this.dataGridAccess);
            this.tabPageGrid.ImageIndex = 0;
            this.tabPageGrid.Location = new System.Drawing.Point(4, 26);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrid.Size = new System.Drawing.Size(777, 410);
            this.tabPageGrid.TabIndex = 1;
            this.tabPageGrid.Text = "Grid Data";
            this.tabPageGrid.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // zedAccessPage1
            // 
            this.zedAccessPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedAccessPage1.Location = new System.Drawing.Point(3, 3);
            this.zedAccessPage1.Name = "zedAccessPage1";
            this.zedAccessPage1.ScrollGrace = 0;
            this.zedAccessPage1.ScrollMaxX = 0;
            this.zedAccessPage1.ScrollMaxY = 0;
            this.zedAccessPage1.ScrollMaxY2 = 0;
            this.zedAccessPage1.ScrollMinX = 0;
            this.zedAccessPage1.ScrollMinY = 0;
            this.zedAccessPage1.ScrollMinY2 = 0;
            this.zedAccessPage1.Size = new System.Drawing.Size(771, 404);
            this.zedAccessPage1.TabIndex = 0;
            // 
            // dataGridAccess
            // 
            this.dataGridAccess.AllowUserToAddRows = false;
            this.dataGridAccess.AllowUserToDeleteRows = false;
            this.dataGridAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAccess.Location = new System.Drawing.Point(3, 3);
            this.dataGridAccess.Name = "dataGridAccess";
            this.dataGridAccess.ReadOnly = true;
            this.dataGridAccess.Size = new System.Drawing.Size(771, 404);
            this.dataGridAccess.TabIndex = 0;
            // 
            // AccessPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabAccessPage);
            this.Name = "AccessPageControl";
            this.Size = new System.Drawing.Size(785, 440);
            this.Resize += new System.EventHandler(this.AccessPageControl_Resize);
            this.tabAccessPage.ResumeLayout(false);
            this.tabPageAccess.ResumeLayout(false);
            this.tabPageGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAccessPage;
        private System.Windows.Forms.TabPage tabPageAccess;
        private System.Windows.Forms.TabPage tabPageGrid;
        private System.Windows.Forms.ImageList imageList1;
        private ZedGraph.ZedGraphControl zedAccessPage1;
        private System.Windows.Forms.DataGridView dataGridAccess;

    }
}
