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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewRequest = new System.Windows.Forms.DataGridView();
            this.tabRequest.SuspendLayout();
            this.tabRequestProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).BeginInit();
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
            this.tabRequest.Size = new System.Drawing.Size(728, 461);
            this.tabRequest.TabIndex = 0;
            // 
            // tabRequestProc
            // 
            this.tabRequestProc.BackColor = System.Drawing.SystemColors.Control;
            this.tabRequestProc.Controls.Add(this.dataGridViewRequest);
            this.tabRequestProc.ImageIndex = 0;
            this.tabRequestProc.Location = new System.Drawing.Point(4, 26);
            this.tabRequestProc.Name = "tabRequestProc";
            this.tabRequestProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequestProc.Size = new System.Drawing.Size(720, 431);
            this.tabRequestProc.TabIndex = 0;
            this.tabRequestProc.Text = "Request Processing";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "grafik.ico");
            // 
            // dataGridViewRequest
            // 
            this.dataGridViewRequest.AllowUserToAddRows = false;
            this.dataGridViewRequest.AllowUserToDeleteRows = false;
            this.dataGridViewRequest.BackgroundColor = System.Drawing.Color.Khaki;
            this.dataGridViewRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRequest.GridColor = System.Drawing.Color.Khaki;
            this.dataGridViewRequest.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRequest.Name = "dataGridViewRequest";
            this.dataGridViewRequest.ReadOnly = true;
            this.dataGridViewRequest.Size = new System.Drawing.Size(714, 425);
            this.dataGridViewRequest.TabIndex = 0;
            // 
            // RequestProcessingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabRequest);
            this.Name = "RequestProcessingControl";
            this.Size = new System.Drawing.Size(728, 461);
            this.tabRequest.ResumeLayout(false);
            this.tabRequestProc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRequest;
        private System.Windows.Forms.TabPage tabRequestProc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridViewRequest;
    }
}
