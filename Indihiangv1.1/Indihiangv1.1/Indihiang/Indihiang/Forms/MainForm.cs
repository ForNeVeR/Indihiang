using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Indihiang.DomainObject;
using Indihiang.Cores;
using Indihiang.Modules;
using System.Diagnostics;
namespace Indihiang.Forms
{
    public partial class MainForm : Form
    {
        private TreeNode _rootNode;
        private TreeNode _logFileaNode;
        private TreeNode _computersNode;
        private TreeNode _reportFileNode;
        private Dictionary<string, LogParser> _listParser = new Dictionary<string, LogParser>();
        private int _consolidationId;

        public MainForm()
        {
            InitializeComponent();

        }

        internal void OnAnalyzeLog(object sender, LogInfoEventArgs e)
        {
            string info = "";

            switch (e.LogStatus)
            {
                case LogProcessStatus.SUCCESS:
                    info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, e.Message);
                    break;
                case LogProcessStatus.FAILED:
                    info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[err]: {1}", DateTime.Now, e.Message);
                    break;
                case LogProcessStatus.CANCELED:
                    info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: Log analyzer is canceled by user", DateTime.Now);
                    break;
            }

            if(tabMain.TabPages.ContainsKey(e.FileName))
                ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).AddLogStatus(info);

        }
        internal void OnEndAnalyze(object sender, LogInfoEventArgs e)
        {
            try
            {                
                UpdateInfoLogStatus(e.FileName, "Rendering reports...");

                if (_listParser.ContainsKey(e.FileName))
                {
                    LogParser parser = (LogParser)_listParser[e.FileName];

                    if (tabMain.TabPages.ContainsKey(e.FileName))
                    {
                        ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).HideLoadingControl();                        
                        ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).Populate(parser);
                        ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).EndRenderHandler += MainForm_EndRenderHandler;

                    }
                    

                }
            }
            catch (Exception err)
            {
                UpdateInfoLogStatus(e.FileName, err.Message);
                UpdateInfoLogStatus(e.FileName, err.StackTrace);
            }
        }

        void MainForm_EndRenderHandler(object sender, RenderInfoEventArgs e)
        {
            LogParser parser = (LogParser)_listParser[e.Id];
            parser.StopTickCounter();

            UpdateInfoLogStatus(e.Id, "Rendering the result of analyzing is done");
            UpdateInfoLogStatus(e.Id, string.Format("Total Analyzing Process Duration: {0:0.###} seconds", parser.ProcessDuration));
            UpdateInfoLogStatus(e.Id, "Finish");
        }      

        private void UpdateInfoLogStatus(string tabId,string msg)
        {
            string info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now,msg);

            if (tabMain.TabPages.ContainsKey(tabId))
                ((WebLogUserControl)tabMain.TabPages[tabId].Controls[0]).AddLogStatus(info);            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitTreeMenu();
            
        }
        private void InitTreeMenu()
        {
            _rootNode = new TreeNode();
            _rootNode.Text = "Web Log Analyzer";
            _rootNode.ImageIndex = 0;
            _rootNode.SelectedImageIndex = 0;
            _logFileaNode = _rootNode.Nodes.Add("LogFiles", "Web Log Files");
            _logFileaNode.ImageIndex = 1;
            _logFileaNode.SelectedImageIndex = 1;

            _computersNode = _rootNode.Nodes.Add("Remote Web Servers", "Remote Web Servers");
            _computersNode.ImageIndex = 3;
            _computersNode.SelectedImageIndex = 3;

            _reportFileNode = _rootNode.Nodes.Add("Report Log Files", "Report Log Files");
            _reportFileNode.ImageIndex = 8;
            _reportFileNode.SelectedImageIndex = 8;

            treeMain.Nodes.Add(_rootNode);
            treeMain.ExpandAll();
        }      
  
        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openLogFileDialog.ShowDialog() == DialogResult.OK)
            {                
                string[] logFiles = openLogFileDialog.FileNames;

                if (logFiles != null)
                {
                    if (logFiles.Length > 1)
                    {
                        GenerateConsolidateName();
                        string key = "--"; //magic number
                        string name1 = "Consolidation #" + _consolidationId;

                        using (ConsolidateForm frm = new ConsolidateForm { ConsolidationName = name1 })
                        {
                            name1 = "";

                            while (String.Compare(name1, "", false) == 0)
                            {                                
                                if (frm.ShowDialog() != DialogResult.OK)
                                {
                                    _consolidationId--;
                                    return;
                                }                                

                                if (!_logFileaNode.Nodes.ContainsKey(frm.ConsolidationName))
                                {
                                    name1 = frm.ConsolidationName;

                                    if (!frm.ConsolidationName.Equals("Consolidation #" + _consolidationId))
                                        _consolidationId--;
                                }
                                else
                                    MessageBox.Show("Log Name cannot duplicate", "Information");

                            }
                        }

                        Guid id = Guid.NewGuid();
                        TreeNode item = CreateNewNode(id.ToString(), name1, 7);

                        key = "--";
                        for (int i = 0; i < logFiles.Length; i++)
                        {
                            key = String.Format("{0}{1};", key,logFiles[i]);
                            string name2 = Path.GetFileName(logFiles[i]);
                            TreeNode childItem = item.Nodes.Add(logFiles[i], name2);
                            childItem.ImageIndex = 2;
                            childItem.SelectedImageIndex = 2;
                        }

                        
                        //AttachUserControl(key, name1,7);
                        AttachUserControl(id.ToString(), name1, 7);                                           
                        tabMain.SelectedTab = tabMain.TabPages[id.ToString()];
                        _logFileaNode.ExpandAll();

                        AttachLogParser(key, id);    
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(logFiles[0]))
                        {
                            string name = Path.GetFileName(logFiles[0]);

                            Guid id = Guid.NewGuid();
                            CreateNewNode(id.ToString(), name, 2);
                            AttachUserControl(id.ToString(), name, 2);
                            AttachLogParser(logFiles[0], id);

                            tabMain.SelectedTab = tabMain.TabPages[id.ToString()];
                            _logFileaNode.ExpandAll();

                        }
                    }
                }
                
            }
        }

        private void toolStripOpenComputer_Click(object sender, EventArgs e)
        {
            OpenRemoteIISForm frm = new OpenRemoteIISForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IISSelected != null)
                {                    
                    IISInfo iis = frm.IISSelected;
                    string key = string.Format("$${0}", iis.IISInfoDisplay);
                    Guid guidKey = Guid.NewGuid();
                    string name = iis.IISInfoDisplay;

                    if (!_listParser.ContainsKey(guidKey.ToString()))
                    {
                        CreateNewIISRemoteNode(guidKey.ToString(), name, 4);
                        // $$--> Remote IIS node key
                        AttachUserControl(guidKey.ToString(), name, 4);
                        tabMain.SelectedTab = tabMain.TabPages[guidKey.ToString()];
                        _computersNode.ExpandAll();

                        AttachIISRemoteLogParser(key, iis,guidKey);                       
                    }
                    else
                        tabMain.SelectedTab = tabMain.TabPages[guidKey.ToString()];
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure to exit?", 
                                    "Confirmation", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                if (_listParser.Keys.Count > 0)
                {                   
                    foreach (KeyValuePair<string, LogParser> parser in _listParser)
                    {
                        if (parser.Value != null)
                            ((LogParser)parser.Value).CancelAnalyze();
                    }
                    _listParser.Clear();
                }
            }
            else
                e.Cancel = true;
        }

        private void toolStripOpenLogFile_Click(object sender, EventArgs e)
        {
            openLogFileToolStripMenuItem_Click(sender, e);
        }
        private void openRemoteWebServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripOpenComputer_Click(sender, e);
        } 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutIndihiang form = new AboutIndihiang())
            {
                form.ShowDialog();
            }
        }

        private void visitToIndhiangWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("http://www.indihiang.com");
            System.Diagnostics.Process.Start(startInfo);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeToolStripMenuItem1_Click(sender, e);
        }

        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //TCHITTESTINFO HTI = new TCHITTESTINFO(e.X, e.Y);
                //TabPage hotTab = tabMain.TabPages[SendMessage(tabMain.Handle, TCM_HITTEST, IntPtr.Zero, ref HTI)];
                tabMain.ContextMenuStrip = ctxTab;

            }
        }        

        private void tabMain_MouseUp(object sender, MouseEventArgs e)
        {
            tabMain.ContextMenuStrip = null;
        }
        
        private void treeMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo hit = treeMain.HitTest(e.X, e.Y);
                if (hit != null)
                {
                    if (hit.Node != null)
                    {
                        treeMain.SelectedNode = hit.Node;
                        if (hit.Node.Equals(_logFileaNode) || hit.Node.Equals(_computersNode) || hit.Node.Equals(_reportFileNode))
                        {                            
                            if (hit.Node.Equals(_logFileaNode))
                                ctxTree1.Items[0].Text = "Open Log File(s)";
                            else
                                if (hit.Node.Equals(_computersNode))
                                    ctxTree1.Items[0].Text = "Open Remote IIS Server";
                                else
                                    if (hit.Node.Equals(_reportFileNode))
                                        ctxTree1.Items[0].Text = "Open Report Log File";

                            ctxTree1.Show(treeMain, e.Location);
                            
                        }
                        else
                            if (hit.Node.Equals(_rootNode))
                            {
                                ctxTree2.Show(treeMain, e.Location);
                            }
                            else
                            {
                                if (hit.Node.Parent.Equals(_logFileaNode) || hit.Node.Parent.Equals(_computersNode) || hit.Node.Parent.Equals(_reportFileNode))
                                {
                                    ctxTree3.Show(treeMain, e.Location);
                                }
                            }

                    }
                }
                
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // close from tab 

            TabPage selectedTab = tabMain.SelectedTab;
            if (selectedTab != null)
            {
                string key = (string)selectedTab.Tag;
                if (!string.IsNullOrEmpty(key))
                {
                    if (_listParser.ContainsKey(key))
                    {
                        if (_listParser[key].IsBusy)
                        {
                            DialogResult result = MessageBox.Show("Log parser still is running in this form. Are you sure to close this?", 
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                                return;

                            UpdateInfoLogStatus(key, "Cancelling log parser...");
                            _listParser[key].CancelAnalyze();
                            UpdateInfoLogStatus(key, "Log parser is stopped by user");
                        }
                    }

                    if (String.Compare(selectedTab.Text, "Welcome", false) != 0)
                        tabMain.TabPages.Remove(selectedTab);

                    if (key.StartsWith("$$"))
                        _computersNode.Nodes.RemoveByKey(key);
                    else
                        _logFileaNode.Nodes.RemoveByKey(key);
                    _listParser.Remove(key);
                }
            }
        }

        private void closeAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeAllToolStripMenuItem_Click(sender, e);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure to close all log analyzing?",
                                    "Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                while (tabMain.TabPages.Count > 1)
                {

                    int index = tabMain.TabPages.Count - 1;
                    if (String.Compare(tabMain.TabPages[index].Text, "Welcome", false) != 0)
                        tabMain.TabPages.RemoveAt(index);
                }

                _logFileaNode.Nodes.Clear();
                _computersNode.Nodes.Clear();
                _reportFileNode.Nodes.Clear();
                _listParser.Clear();
            }
        }

        private void closeAllToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // close all
            closeAllToolStripMenuItem_Click(sender, e);
        }
        private void closeAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {            
            // close all log files or remote IIS
            if (treeMain.SelectedNode != null)
            {
                DialogResult dlg = MessageBox.Show("Are you sure to close all log analyzing?",
                                    "Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                if (dlg == DialogResult.No)
                    return;
            

                bool logFileSelected = false;
                if (treeMain.SelectedNode.Equals(_logFileaNode))
                    logFileSelected = true;
                                
                List<string> keys = new List<string>();
                int totalTabs = tabMain.TabPages.Count;
                for (int i = 0; i < totalTabs; i++)
                {
                    if (String.Compare(tabMain.TabPages[i].Text, "Welcome", false) != 0)
                    {
                        if (!tabMain.TabPages[i].Tag.ToString().StartsWith("$$"))
                        {
                            if (logFileSelected)
                                keys.Add(tabMain.TabPages[i].Tag.ToString());
                        }
                        else
                        {
                            if (!logFileSelected)
                                keys.Add(tabMain.TabPages[i].Tag.ToString());
                        }
                    }
                }

                while (keys.Count>0)
                {
                    string key = keys[0];
                    if (tabMain.TabPages.ContainsKey(key))
                    {
                        tabMain.TabPages.RemoveByKey(key);
                    }
                    if (_listParser.ContainsKey(key))
                    {
                        if (_listParser[key].IsBusy)
                            _listParser[key].CancelAnalyze();

                        _listParser.Remove(key);
                    }
                    keys.RemoveAt(0);
                }

                if (treeMain.SelectedNode.Equals(_logFileaNode))
                    _logFileaNode.Nodes.Clear();
                else
                    _computersNode.Nodes.Clear();


            }
        }
        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // close from tree menu

            TreeNode selected = treeMain.SelectedNode;
            if (selected != null)
            {
                string key = (string)selected.Tag;
                if (!string.IsNullOrEmpty(key))
                {
                    if (_listParser.ContainsKey(key))
                    {
                        if (_listParser[key].IsBusy)
                        {
                            DialogResult result = MessageBox.Show("Log parser still is running in this form. Are you sure to close this?",
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                                return;

                            UpdateInfoLogStatus(key, "Cancelling log parser...");
                            _listParser[key].CancelAnalyze();
                            UpdateInfoLogStatus(key, "Log parser is stopped by user");
                        }
                    }


                    if (key.StartsWith("$$") || key.StartsWith("!!"))
                    {
                        tabMain.TabPages.RemoveByKey(key.Substring(2));
                        _computersNode.Nodes.RemoveByKey(key);
                    }
                    else
                    {
                        tabMain.TabPages.RemoveByKey(key);
                        _logFileaNode.Nodes.RemoveByKey(key);
                    }

                    _listParser.Remove(key);
                }
            }

            TabPage selectedTab = tabMain.SelectedTab;
            if (selectedTab != null)
            {
                
            }
        }
        private void openLogFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open log file
            openLogFileToolStripMenuItem_Click(sender, e);
        }

        private void openRemoteIISServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open remote IIS 
            toolStripOpenComputer_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open log file or remote IIS or report log file
            if (treeMain.SelectedNode.Equals(_logFileaNode))
                openLogFileToolStripMenuItem_Click(sender, e);
            else
                if (treeMain.SelectedNode.Equals(_computersNode))
                    toolStripOpenComputer_Click(sender, e);
                else
                    if (treeMain.SelectedNode.Equals(_reportFileNode))
                        openIndihiangReportFileToolStripMenuItem_Click(sender, e);
        }

        private void toolStripOpenReportLogFile_Click(object sender, EventArgs e)
        {
            openIndihiangReportFileToolStripMenuItem_Click(sender, e);
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // version 1.0
            ProcessStartInfo startInfo = new ProcessStartInfo("http://wiki.indihiang.com");
            System.Diagnostics.Process.Start(startInfo);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkNewVersionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckLatestVersionForm frm = new CheckLatestVersionForm();
            frm.ShowDialog();
        }


        private void exportDataToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeMain.SelectedNode;
            if (selected != null)
            {
                if (selected.Tag == null)
                {
                    MessageBox.Show("Choice log data that you want to export", "Information");
                    return;
                }
                string key = (string)selected.Tag;
                if (key.StartsWith("$$") || key.StartsWith("!!"))
                    key = key.Substring(2);

                if (!string.IsNullOrEmpty(key))
                {
                    if (_listParser.ContainsKey(key))
                    {
                        string path = _listParser[key].LogFilePath;
                        List<string> files = new List<string>(Directory.GetFiles(path, "*.dat"));

                        ExportDataForm frm = new ExportDataForm();
                        frm.LogFiles = files;
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Choice log data that you want to export", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Choice log data that you want to export", "Information");
                }
            }
            else
            {
                MessageBox.Show("Choice log data that you want to export", "Information");
            }
        }
        private void browsePhysicalFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeMain.SelectedNode;
            if (selected != null)
            {
                if (selected.Tag == null)
                    return;
                string key = (string)selected.Tag;
                if (key.StartsWith("$$") || key.StartsWith("!!"))
                    key = key.Substring(2);

                if (!string.IsNullOrEmpty(key))
                {
                    if (_listParser.ContainsKey(key))
                    {
                        string path = _listParser[key].LogFilePath;
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(path);
                        System.Diagnostics.Process.Start(startInfo);
                    }
                    else
                    {
                        MessageBox.Show("Choice log data that you want to browse", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Choice log data that you want to browse", "Information");
                }
            }
            else
            {
                MessageBox.Show("Choice log data that you want to browse", "Information");
            }
        }

        private void exportDataToDatabaseServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportDataToToolStripMenuItem_Click(sender, e);
        }

        private void openIndihiangReportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openResultLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                string reportFile = openResultLogFileDialog.FileName;
                if (!string.IsNullOrEmpty(reportFile))
                {
                    string name = Path.GetFileName(reportFile);

                    Guid id = Guid.NewGuid();
                    CreateNewReportNode(id.ToString(), name, 9);
                    AttachUserControl(id.ToString(), name, 9);
                    AttachReportLogParser(reportFile, id);

                    tabMain.SelectedTab = tabMain.TabPages[id.ToString()];
                    _logFileaNode.ExpandAll();

                }
            }
        }

        private TreeNode CreateNewNode(string key,string name,int imageIndex)
        {
            TreeNode item = _logFileaNode.Nodes.Add(key, name);
            item.ImageIndex = imageIndex;
            item.SelectedImageIndex = imageIndex;
            item.Tag = key;

            return item;
        }
        private TreeNode CreateNewIISRemoteNode(string key, string name, int imageIndex)
        {
            TreeNode item = _computersNode.Nodes.Add(String.Format("$${0}", key), name);
            item.ImageIndex = imageIndex;
            item.SelectedImageIndex = imageIndex;
            item.Tag = String.Format("$${0}", key); // $$ --> remote IIS

            return item;
        }
        private TreeNode CreateNewReportNode(string key, string name, int imageIndex)
        {
            TreeNode item = _reportFileNode.Nodes.Add(key, name);
            item.ImageIndex = imageIndex;
            item.SelectedImageIndex = imageIndex;
            item.Tag = String.Format("!!{0}", key); // $$ --> report log file

            _reportFileNode.ExpandAll();

            return item;
        }
        private void AttachUserControl(string key,string name,int imgIndex)
        {
            WebLogUserControl control = new WebLogUserControl();

            tabMain.TabPages.Add(key, name, imgIndex);
            tabMain.TabPages[key].Controls.Add(control);
            tabMain.TabPages[key].Tag = key;
            control.Dock = DockStyle.Fill;
            control.ShowLoadingControl();
        }
        private void AttachLogParser(string fileNames,Guid id)
        {
            LogParser parser = new LogParser { 
                FileName = fileNames,
                UseExistData = false,
                UseParallel = true, 
                LogParserId = id };

            parser.AnalyzeLogHandler += OnAnalyzeLog;
            parser.EndAnalyzeHandler += OnEndAnalyze;

            parser.Analyze();
            _listParser.Add(id.ToString(), parser);
        }
        private void AttachIISRemoteLogParser(string name,IISInfo info,Guid id)
        {
            LogParser parser = new LogParser(info)
            {
                FileName = name,
                UseExistData = false,
                UseParallel = true,
                LogParserId = id
                
            };            
            parser.AnalyzeLogHandler += OnAnalyzeLog;
            parser.EndAnalyzeHandler += OnEndAnalyze;

            parser.Analyze();
            _listParser.Add(id.ToString(), parser);
        }
        private void AttachReportLogParser(string fileNames, Guid id)
        {
            LogParser parser = new LogParser
            {
                FileName = fileNames,      
                UseExistData = true,
                UseParallel = true,
                LogParserId = id
            };

            parser.AnalyzeLogHandler += OnAnalyzeLog;
            parser.EndAnalyzeHandler += OnEndAnalyze;

            parser.Analyze();
            _listParser.Add(id.ToString(), parser);
        }

        private void GenerateConsolidateName()
        {
            _consolidationId++;
            while (_logFileaNode.Nodes.ContainsKey("Consolidation #" + _consolidationId))
            {
                _consolidationId++;
            }
        }


        /// <summary>
        /// this code is taken from http://dotnetrix.co.uk/tabcontrol.htm
        /// </summary>

        [Flags()]
        private enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        private const int TCM_HITTEST = 0x130D;

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct TCHITTESTINFO
        {
            public Point pt;
            public TCHITTESTFLAGS flags;
            public TCHITTESTINFO(int x, int y)
            {
                pt = new Point(x, y);
                flags = TCHITTESTFLAGS.TCHT_ONITEM;
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TCHITTESTINFO lParam);

		private void findCountryForIPAddressesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			findCountryForIPAddressesToolStripMenuItem.Checked = !findCountryForIPAddressesToolStripMenuItem.Checked;
			Indihiang.Properties.Settings.Default.FindCountries = !Indihiang.Properties.Settings.Default.FindCountries;
		}
        
        ///////////////////////////////////////////////////
    }
}
