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
            this.zedHits1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedHits1
            // 
            this.zedHits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedHits1.Location = new System.Drawing.Point(0, 0);
            this.zedHits1.Name = "zedHits1";
            this.zedHits1.ScrollGrace = 0;
            this.zedHits1.ScrollMaxX = 0;
            this.zedHits1.ScrollMaxY = 0;
            this.zedHits1.ScrollMaxY2 = 0;
            this.zedHits1.ScrollMinX = 0;
            this.zedHits1.ScrollMinY = 0;
            this.zedHits1.ScrollMinY2 = 0;
            this.zedHits1.Size = new System.Drawing.Size(690, 395);
            this.zedHits1.TabIndex = 0;
            this.zedHits1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zedHits1_PointValueEvent);
            // 
            // HitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zedHits1);
            this.Name = "HitsControl";
            this.Size = new System.Drawing.Size(690, 395);
            this.Resize += new System.EventHandler(this.HitsControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedHits1;
    }
}
