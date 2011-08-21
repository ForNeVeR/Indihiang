namespace Indihiang.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openRemoteWebServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.openIndihiangReportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportDataToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.visitToIndhiangWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.checkNewVersionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolstatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripOpenLogFile = new System.Windows.Forms.ToolStripButton();
			this.toolStripOpenComputer = new System.Windows.Forms.ToolStripButton();
			this.toolStripOpenReportLogFile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripRunAnalyzer = new System.Windows.Forms.ToolStripButton();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.treeMain = new System.Windows.Forms.TreeView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.openLogFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabWelcome = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ctxTab = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxTree1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeAllToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxTree3 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportDataToDatabaseServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browsePhysicalFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxTree2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openLogFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openRemoteIISServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.closeAllToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.openResultLogFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.findCountryForIPAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMain.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabWelcome.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.ctxTab.SuspendLayout();
			this.ctxTree1.SuspendLayout();
			this.ctxTree3.SuspendLayout();
			this.ctxTree2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(900, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogFileToolStripMenuItem,
            this.openRemoteWebServerToolStripMenuItem,
            this.toolStripMenuItem3,
            this.openIndihiangReportFileToolStripMenuItem,
            this.toolStripMenuItem6,
            this.closeToolStripMenuItem,
            this.closeAllToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openLogFileToolStripMenuItem
			// 
			this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
			this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openLogFileToolStripMenuItem.Text = "Open Log File";
			this.openLogFileToolStripMenuItem.Click += new System.EventHandler(this.openLogFileToolStripMenuItem_Click);
			// 
			// openRemoteWebServerToolStripMenuItem
			// 
			this.openRemoteWebServerToolStripMenuItem.Name = "openRemoteWebServerToolStripMenuItem";
			this.openRemoteWebServerToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openRemoteWebServerToolStripMenuItem.Text = "Open Remote Web Server";
			this.openRemoteWebServerToolStripMenuItem.Click += new System.EventHandler(this.openRemoteWebServerToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(212, 6);
			// 
			// openIndihiangReportFileToolStripMenuItem
			// 
			this.openIndihiangReportFileToolStripMenuItem.Name = "openIndihiangReportFileToolStripMenuItem";
			this.openIndihiangReportFileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.openIndihiangReportFileToolStripMenuItem.Text = "Open Indihiang Report File";
			this.openIndihiangReportFileToolStripMenuItem.Click += new System.EventHandler(this.openIndihiangReportFileToolStripMenuItem_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(212, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// closeAllToolStripMenuItem1
			// 
			this.closeAllToolStripMenuItem1.Name = "closeAllToolStripMenuItem1";
			this.closeAllToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
			this.closeAllToolStripMenuItem1.Text = "Close All";
			this.closeAllToolStripMenuItem1.Click += new System.EventHandler(this.closeAllToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findCountryForIPAddressesToolStripMenuItem,
            this.toolStripMenuItem8,
            this.exportDataToToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// exportDataToToolStripMenuItem
			// 
			this.exportDataToToolStripMenuItem.Name = "exportDataToToolStripMenuItem";
			this.exportDataToToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.exportDataToToolStripMenuItem.Text = "Export Data to Database Server...";
			this.exportDataToToolStripMenuItem.Click += new System.EventHandler(this.exportDataToToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.visitToIndhiangWebsiteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.checkNewVersionToolStripMenuItem1,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// howToUseToolStripMenuItem
			// 
			this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
			this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.howToUseToolStripMenuItem.Text = "How to use";
			this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
			// 
			// visitToIndhiangWebsiteToolStripMenuItem
			// 
			this.visitToIndhiangWebsiteToolStripMenuItem.Name = "visitToIndhiangWebsiteToolStripMenuItem";
			this.visitToIndhiangWebsiteToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.visitToIndhiangWebsiteToolStripMenuItem.Text = "Visit to Indihiang website";
			this.visitToIndhiangWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitToIndhiangWebsiteToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 6);
			// 
			// checkNewVersionToolStripMenuItem1
			// 
			this.checkNewVersionToolStripMenuItem1.Name = "checkNewVersionToolStripMenuItem1";
			this.checkNewVersionToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
			this.checkNewVersionToolStripMenuItem1.Text = "Check New Version";
			this.checkNewVersionToolStripMenuItem1.Click += new System.EventHandler(this.checkNewVersionToolStripMenuItem1_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstatus,
            this.toolProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 448);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(900, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolstatus
			// 
			this.toolstatus.Name = "toolstatus";
			this.toolstatus.Size = new System.Drawing.Size(39, 17);
			this.toolstatus.Text = "Ready";
			this.toolstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolProgressBar
			// 
			this.toolProgressBar.Name = "toolProgressBar";
			this.toolProgressBar.Size = new System.Drawing.Size(100, 16);
			this.toolProgressBar.Visible = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenLogFile,
            this.toolStripOpenComputer,
            this.toolStripOpenReportLogFile,
            this.toolStripSeparator1,
            this.toolStripRunAnalyzer});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(900, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripOpenLogFile
			// 
			this.toolStripOpenLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripOpenLogFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenLogFile.Image")));
			this.toolStripOpenLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripOpenLogFile.Name = "toolStripOpenLogFile";
			this.toolStripOpenLogFile.Size = new System.Drawing.Size(23, 22);
			this.toolStripOpenLogFile.ToolTipText = "Open log file";
			this.toolStripOpenLogFile.Click += new System.EventHandler(this.toolStripOpenLogFile_Click);
			// 
			// toolStripOpenComputer
			// 
			this.toolStripOpenComputer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripOpenComputer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenComputer.Image")));
			this.toolStripOpenComputer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripOpenComputer.Name = "toolStripOpenComputer";
			this.toolStripOpenComputer.Size = new System.Drawing.Size(23, 22);
			this.toolStripOpenComputer.ToolTipText = "View current log file on remote computer";
			this.toolStripOpenComputer.Click += new System.EventHandler(this.toolStripOpenComputer_Click);
			// 
			// toolStripOpenReportLogFile
			// 
			this.toolStripOpenReportLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripOpenReportLogFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenReportLogFile.Image")));
			this.toolStripOpenReportLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripOpenReportLogFile.Name = "toolStripOpenReportLogFile";
			this.toolStripOpenReportLogFile.Size = new System.Drawing.Size(23, 22);
			this.toolStripOpenReportLogFile.ToolTipText = "Open report log file";
			this.toolStripOpenReportLogFile.Click += new System.EventHandler(this.toolStripOpenReportLogFile_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripRunAnalyzer
			// 
			this.toolStripRunAnalyzer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripRunAnalyzer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRunAnalyzer.Image")));
			this.toolStripRunAnalyzer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripRunAnalyzer.Name = "toolStripRunAnalyzer";
			this.toolStripRunAnalyzer.Size = new System.Drawing.Size(23, 22);
			this.toolStripRunAnalyzer.ToolTipText = "Run log file analyzer";
			this.toolStripRunAnalyzer.Visible = false;
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgList.Images.SetKeyName(0, "indhiang.ico");
			this.imgList.Images.SetKeyName(1, "Folder.ico");
			this.imgList.Images.SetKeyName(2, "db.ico");
			this.imgList.Images.SetKeyName(3, "Computers.ico");
			this.imgList.Images.SetKeyName(4, "Globe.ico");
			this.imgList.Images.SetKeyName(5, "server.ico");
			this.imgList.Images.SetKeyName(6, "help.ico");
			this.imgList.Images.SetKeyName(7, "dbs.ico");
			this.imgList.Images.SetKeyName(8, "Messages.ico");
			this.imgList.Images.SetKeyName(9, "SingleMessage.ico");
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.treeMain);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 49);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(238, 399);
			this.panel1.TabIndex = 3;
			// 
			// treeMain
			// 
			this.treeMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeMain.ImageIndex = 0;
			this.treeMain.ImageList = this.imgList;
			this.treeMain.Indent = 20;
			this.treeMain.Location = new System.Drawing.Point(0, 24);
			this.treeMain.Name = "treeMain";
			this.treeMain.SelectedImageIndex = 0;
			this.treeMain.ShowRootLines = false;
			this.treeMain.Size = new System.Drawing.Size(238, 375);
			this.treeMain.TabIndex = 1;
			this.treeMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseDown);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(238, 24);
			this.panel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label1.Location = new System.Drawing.Point(1, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Web Log Explorer";
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Control;
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter1.Location = new System.Drawing.Point(238, 49);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 399);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// openLogFileDialog
			// 
			this.openLogFileDialog.Filter = "Log file|*.log|All log files|*.*";
			this.openLogFileDialog.Multiselect = true;
			this.openLogFileDialog.Title = "Open Log File";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.tabMain);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(241, 49);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(659, 399);
			this.panel3.TabIndex = 5;
			// 
			// tabMain
			// 
			this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabMain.Controls.Add(this.tabWelcome);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.ImageList = this.imgList;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(657, 397);
			this.tabMain.TabIndex = 0;
			this.tabMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseDown);
			this.tabMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseUp);
			// 
			// tabWelcome
			// 
			this.tabWelcome.BackColor = System.Drawing.Color.White;
			this.tabWelcome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabWelcome.Controls.Add(this.pictureBox1);
			this.tabWelcome.ImageIndex = 0;
			this.tabWelcome.Location = new System.Drawing.Point(4, 26);
			this.tabWelcome.Name = "tabWelcome";
			this.tabWelcome.Padding = new System.Windows.Forms.Padding(3);
			this.tabWelcome.Size = new System.Drawing.Size(649, 367);
			this.tabWelcome.TabIndex = 0;
			this.tabWelcome.Text = "Welcome";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Indihiang.Properties.Resources.main2;
			this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(300, 200);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// ctxTab
			// 
			this.ctxTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem1,
            this.closeAllToolStripMenuItem});
			this.ctxTab.Name = "ctxTab";
			this.ctxTab.Size = new System.Drawing.Size(121, 48);
			// 
			// closeToolStripMenuItem1
			// 
			this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
			this.closeToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
			this.closeToolStripMenuItem1.Text = "Close";
			this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			this.closeAllToolStripMenuItem.Text = "Close All";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
			// 
			// ctxTree1
			// 
			this.ctxTree1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem4,
            this.closeAllToolStripMenuItem2});
			this.ctxTree1.Name = "ctxTree1";
			this.ctxTree1.Size = new System.Drawing.Size(161, 54);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.openToolStripMenuItem.Text = "Open Log File(s)";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
			// 
			// closeAllToolStripMenuItem2
			// 
			this.closeAllToolStripMenuItem2.Name = "closeAllToolStripMenuItem2";
			this.closeAllToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.closeAllToolStripMenuItem2.Text = "Close All";
			this.closeAllToolStripMenuItem2.Click += new System.EventHandler(this.closeAllToolStripMenuItem2_Click);
			// 
			// ctxTree3
			// 
			this.ctxTree3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToDatabaseServerToolStripMenuItem,
            this.browsePhysicalFolderToolStripMenuItem,
            this.toolStripMenuItem7,
            this.closeToolStripMenuItem2});
			this.ctxTree3.Name = "contextMenuStrip1";
			this.ctxTree3.Size = new System.Drawing.Size(235, 76);
			// 
			// exportDataToDatabaseServerToolStripMenuItem
			// 
			this.exportDataToDatabaseServerToolStripMenuItem.Name = "exportDataToDatabaseServerToolStripMenuItem";
			this.exportDataToDatabaseServerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.exportDataToDatabaseServerToolStripMenuItem.Text = "Export Data to Database Server";
			this.exportDataToDatabaseServerToolStripMenuItem.Click += new System.EventHandler(this.exportDataToDatabaseServerToolStripMenuItem_Click);
			// 
			// browsePhysicalFolderToolStripMenuItem
			// 
			this.browsePhysicalFolderToolStripMenuItem.Name = "browsePhysicalFolderToolStripMenuItem";
			this.browsePhysicalFolderToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.browsePhysicalFolderToolStripMenuItem.Text = "Browse Physical Folder";
			this.browsePhysicalFolderToolStripMenuItem.Click += new System.EventHandler(this.browsePhysicalFolderToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(231, 6);
			// 
			// closeToolStripMenuItem2
			// 
			this.closeToolStripMenuItem2.Name = "closeToolStripMenuItem2";
			this.closeToolStripMenuItem2.Size = new System.Drawing.Size(234, 22);
			this.closeToolStripMenuItem2.Text = "Close";
			this.closeToolStripMenuItem2.Click += new System.EventHandler(this.closeToolStripMenuItem2_Click);
			// 
			// ctxTree2
			// 
			this.ctxTree2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogFilesToolStripMenuItem,
            this.openRemoteIISServerToolStripMenuItem,
            this.toolStripMenuItem5,
            this.closeAllToolStripMenuItem3});
			this.ctxTree2.Name = "ctxTree2";
			this.ctxTree2.Size = new System.Drawing.Size(198, 76);
			// 
			// openLogFilesToolStripMenuItem
			// 
			this.openLogFilesToolStripMenuItem.Name = "openLogFilesToolStripMenuItem";
			this.openLogFilesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.openLogFilesToolStripMenuItem.Text = "Open Log File(s)";
			this.openLogFilesToolStripMenuItem.Click += new System.EventHandler(this.openLogFilesToolStripMenuItem_Click);
			// 
			// openRemoteIISServerToolStripMenuItem
			// 
			this.openRemoteIISServerToolStripMenuItem.Name = "openRemoteIISServerToolStripMenuItem";
			this.openRemoteIISServerToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.openRemoteIISServerToolStripMenuItem.Text = "Open Remote IIS Server";
			this.openRemoteIISServerToolStripMenuItem.Click += new System.EventHandler(this.openRemoteIISServerToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(194, 6);
			// 
			// closeAllToolStripMenuItem3
			// 
			this.closeAllToolStripMenuItem3.Name = "closeAllToolStripMenuItem3";
			this.closeAllToolStripMenuItem3.Size = new System.Drawing.Size(197, 22);
			this.closeAllToolStripMenuItem3.Text = "Close All";
			this.closeAllToolStripMenuItem3.Click += new System.EventHandler(this.closeAllToolStripMenuItem3_Click);
			// 
			// openResultLogFileDialog
			// 
			this.openResultLogFileDialog.Filter = "Report log file|*.dat|All report files|*.*";
			// 
			// findCountryForIPAddressesToolStripMenuItem
			// 
			this.findCountryForIPAddressesToolStripMenuItem.Checked = global::Indihiang.Properties.Settings.Default.FindCountries;
			this.findCountryForIPAddressesToolStripMenuItem.Name = "findCountryForIPAddressesToolStripMenuItem";
			this.findCountryForIPAddressesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.findCountryForIPAddressesToolStripMenuItem.Text = "Find country for IP addresses";
			this.findCountryForIPAddressesToolStripMenuItem.Click += new System.EventHandler(this.findCountryForIPAddressesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(240, 6);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 470);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.Name = "MainForm";
			this.Text = "Indihiang - Web Log Analyzer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tabWelcome.ResumeLayout(false);
			this.tabWelcome.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ctxTab.ResumeLayout(false);
			this.ctxTree1.ResumeLayout(false);
			this.ctxTree3.ResumeLayout(false);
			this.ctxTree2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitToIndhiangWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolstatus;
        private System.Windows.Forms.ToolStripProgressBar toolProgressBar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView treeMain;
        private System.Windows.Forms.OpenFileDialog openLogFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripOpenLogFile;
        private System.Windows.Forms.ToolStripButton toolStripOpenComputer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabWelcome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripRunAnalyzer;
        private System.Windows.Forms.ContextMenuStrip ctxTab;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openRemoteWebServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip ctxTree1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip ctxTree3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip ctxTree2;
        private System.Windows.Forms.ToolStripMenuItem openLogFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRemoteIISServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem openIndihiangReportFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToToolStripMenuItem;        
        private System.Windows.Forms.ToolStripMenuItem checkNewVersionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportDataToDatabaseServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.OpenFileDialog openResultLogFileDialog;
        private System.Windows.Forms.ToolStripButton toolStripOpenReportLogFile;
        private System.Windows.Forms.ToolStripMenuItem browsePhysicalFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findCountryForIPAddressesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;

    }
}