using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Indihiang.Cores;
using Indihiang.Modules;
namespace Indihiang.Forms
{
    public partial class MainForm : Form
    {
        private TreeNode _rootNode;
        private TreeNode _logFileaNode;
        //private TreeNode _computersNode;   --> next phase
        //private LogParser _parser = null;
        private Dictionary<string, LogParser> _listParser = new Dictionary<string, LogParser>();

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
                    info = DateTime.Now.ToString("yyyy/MM/dd hh:mm:dd") + "[info]: " + e.Message;
                    break;
                case LogProcessStatus.FAILED:
                    info = DateTime.Now.ToString("yyyy/MM/dd hh:mm:dd") + "[err]: " + e.Message;
                    break;
                case LogProcessStatus.CANCELED:
                    info = DateTime.Now.ToString("yyyy/MM/dd hh:mm:dd") + "[info]: Log analyzer is canceled by user";
                    break;
            }

            ((WebLogUserControl)this.tabMain.TabPages[e.FileName].Controls[0]).AddLogStatus(info);

        }
        internal void OnEndAnalyze(object sender, LogInfoEventArgs e)
        {
            string info = "";
            info = DateTime.Now.ToString("yyyy/MM/dd hh:mm:dd") + "[info]: Finish";

            ((WebLogUserControl)this.tabMain.TabPages[e.FileName].Controls[0]).AddLogStatus(info);
            if (_listParser.ContainsKey(e.FileName))
            {
                LogParser parser = (LogParser)_listParser[e.FileName];
                ((WebLogUserControl)this.tabMain.TabPages[e.FileName].Controls[0]).Populate(parser);
            }
            
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

            // next phase
            //_computersNode = _rootNode.Nodes.Add("Computers", "Computers");
            //_computersNode.ImageIndex = 3;
            //_computersNode.SelectedImageIndex = 3;

            treeMain.Nodes.Add(_rootNode);
            treeMain.ExpandAll();
        }
        private void TestData()
        {
            for (int i = 0; i < 10; i++)
            {
                TreeNode item = _logFileaNode.Nodes.Add("LogFiles" + i.ToString(), "File " + i.ToString());
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
                string logFile = openLogFileDialog.FileName;
                if (!_listParser.ContainsKey(logFile))
                {
                    string name = Path.GetFileName(logFile);

                    TreeNode item = _logFileaNode.Nodes.Add(logFile, name);
                    item.ImageIndex = 2;
                    item.SelectedImageIndex = 2;
                    
                    WebLogUserControl control = new WebLogUserControl();

                    tabMain.TabPages.Add(logFile, name, 2);
                    tabMain.TabPages[logFile].Controls.Add(control);
                    tabMain.TabPages[logFile].Tag = logFile;
                    control.Dock = DockStyle.Fill;

                    LogParser parser = new LogParser();
                    parser.FileName = logFile;
                    parser.AnalyzeLogHandler += new EventHandler<LogInfoEventArgs>(OnAnalyzeLog);
                    parser.EndAnalyzeHandler += new EventHandler<LogInfoEventArgs>(OnEndAnalyze);

                    parser.Analyze();
                    _listParser.Add(logFile, parser);

                    tabMain.SelectedTab = tabMain.TabPages[logFile];
                    _logFileaNode.ExpandAll();
                }
                else
                    tabMain.SelectedTab = tabMain.TabPages[logFile];               
                
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutIndihiang form = new AboutIndihiang();
            form.ShowDialog();
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
                tabMain.ContextMenuStrip = this.ctxTab;

            }
        }

        private void tabMain_MouseUp(object sender, MouseEventArgs e)
        {
            tabMain.ContextMenuStrip = null;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabMain.SelectedTab;
            string key = (string)selectedTab.Tag;
            if (selectedTab.Text!="Welcome")
                tabMain.TabPages.Remove(selectedTab);

            _logFileaNode.Nodes.RemoveByKey(key);
            _listParser.Remove(key);
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
            _listParser.Clear();
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
