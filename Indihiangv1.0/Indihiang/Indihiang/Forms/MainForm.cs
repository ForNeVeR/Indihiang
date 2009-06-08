using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Indihiang.DomainObject;
using Indihiang.Cores;
using Indihiang.Modules;
namespace Indihiang.Forms
{
    public partial class MainForm : Form
    {
        private TreeNode _rootNode;
        private TreeNode _logFileaNode;
        private TreeNode _computersNode;   
        //private LogParser _parser = null;
        private Dictionary<string, LogParser> _listParser = new Dictionary<string, LogParser>();
        private int _consolidationId;

        public MainForm()
        {
            InitializeComponent();

            //_parser = new LogParser();
            //_parser.AnalyzeLogHandler += new EventHandler<LogInfoEventArgs>(OnAnalyzeLog);            
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
            UpdateInfoLogStatus(e.FileName, "Analyzing is done");
            UpdateInfoLogStatus(e.FileName, "Rendering the result of analyzing");

            if (_listParser.ContainsKey(e.FileName))
            {
                LogParser parser = (LogParser)_listParser[e.FileName];

                if (tabMain.TabPages.ContainsKey(e.FileName))
                {
                    ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).HideLoadingControl();
                    ((WebLogUserControl)tabMain.TabPages[e.FileName].Controls[0]).Populate(parser);
                }
                UpdateInfoLogStatus(e.FileName, "Rendering the result of analyzing is done");
                UpdateInfoLogStatus(e.FileName, string.Format("Total Analyzing Process Duration: {0:0.###} seconds", parser.ProcessDuration));
                UpdateInfoLogStatus(e.FileName, "Finish");                   

            }
            
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
            //TestData();
            
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

            treeMain.Nodes.Add(_rootNode);
            treeMain.ExpandAll();
        }
        private void TestData()
        {
            for (int i = 0; i < 10; i++)
            {
                TreeNode item = _logFileaNode.Nodes.Add(String.Format("LogFiles{0}", i), String.Format("File {0}", i));
                item.ImageIndex = 2;
                item.SelectedImageIndex = 2;

                //TreeNode item2 = _computersNode.Nodes.Add("Computers" + i.ToString(), "File " + i.ToString());
                //item2.ImageIndex = 4;
                //item2.SelectedImageIndex = 4;
            }
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

                            while (name1 == "")
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

                        TreeNode item =CreateNewNode(name1, name1,7);                        

                        for (int i = 0; i < logFiles.Length; i++)
                        {
                            key = String.Format("{0}{1};", key,logFiles[i]);
                            string name2 = Path.GetFileName(logFiles[i]);
                            TreeNode childItem = item.Nodes.Add(logFiles[i], name2);
                            childItem.ImageIndex = 2;
                            childItem.SelectedImageIndex = 2;
                        }

                        AttachUserControl(key, name1,7);
                        AttachLogParser(key);                       
                        tabMain.SelectedTab = tabMain.TabPages[key];
                        _logFileaNode.ExpandAll();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(logFiles[0]))
                        {
                            if (!_listParser.ContainsKey(logFiles[0]))
                            {
                                string name = Path.GetFileName(logFiles[0]);

                                CreateNewNode(logFiles[0], name, 2);                                
                                AttachUserControl(logFiles[0], name,2);
                                AttachLogParser(logFiles[0]);                                

                                tabMain.SelectedTab = tabMain.TabPages[logFiles[0]];
                                _logFileaNode.ExpandAll();
                            }
                            else
                                tabMain.SelectedTab = tabMain.TabPages[logFiles[0]];
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
                    string name = iis.IISInfoDisplay;

                    if (!_listParser.ContainsKey(key))
                    {
                        CreateNewIISRemoteNode(key, name, 4);
                        // $$--> Remote IIS node key
                        AttachUserControl(key, name, 4);
                        AttachIISRemoteLogParser(key, iis);

                        tabMain.SelectedTab = tabMain.TabPages[key];
                        _computersNode.ExpandAll();
                    }
                    else
                        tabMain.SelectedTab = tabMain.TabPages[key];
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
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("http://www.codeplex.com/indihiang");
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
                TCHITTESTINFO HTI = new TCHITTESTINFO(e.X, e.Y);
                TabPage hotTab = tabMain.TabPages[SendMessage(tabMain.Handle, TCM_HITTEST, IntPtr.Zero, ref HTI)];
                tabMain.ContextMenuStrip = ctxTab;

            }
        }

        private void tabMain_MouseUp(object sender, MouseEventArgs e)
        {
            tabMain.ContextMenuStrip = null;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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

                    if (selectedTab.Text != "Welcome")
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
            while (tabMain.TabPages.Count > 1)
            {
                
                int index = tabMain.TabPages.Count-1;
                if(tabMain.TabPages[index].Text!="Welcome")
                    tabMain.TabPages.RemoveAt(index);
            }

            _logFileaNode.Nodes.Clear();
            _computersNode.Nodes.Clear();
            _listParser.Clear();
        }
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // version 0.2
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("http://indihiang.aguskurniawan.net");
            System.Diagnostics.Process.Start(startInfo);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private TreeNode CreateNewNode(string key,string name,int imageIndex)
        {
            TreeNode item = _logFileaNode.Nodes.Add(key, name);
            item.ImageIndex = imageIndex;
            item.SelectedImageIndex = imageIndex;

            return item;
        }
        private TreeNode CreateNewIISRemoteNode(string key, string name, int imageIndex)
        {
            TreeNode item = _computersNode.Nodes.Add(key, name);
            item.ImageIndex = imageIndex;
            item.SelectedImageIndex = imageIndex;

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
        private void AttachLogParser(string fileNames)
        {
            LogParser parser = new LogParser { FileName = fileNames };
            parser.AnalyzeLogHandler += OnAnalyzeLog;
            parser.EndAnalyzeHandler += OnEndAnalyze;

            parser.Analyze();
            _listParser.Add(fileNames, parser);
        }
        private void AttachIISRemoteLogParser(string name,IISInfo info)
        {
            LogParser parser = new LogParser(info) { FileName = name };
            parser.AnalyzeLogHandler += OnAnalyzeLog;
            parser.EndAnalyzeHandler += OnEndAnalyze;

            parser.Analyze();
            _listParser.Add(name, parser);
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

        ///////////////////////////////////////////////////
    }
}
