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
        private TreeNode _computersNode;
        private LogParser _parser = null;
        private Dictionary<string, LogParser> _listParser = new Dictionary<string, LogParser>();

        public MainForm()
        {
            InitializeComponent();

            _parser = new LogParser();
            _parser.AnalyzeLogHandler += new EventHandler<LogInfoEventArgs>(OnAnalyzeLog);            
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
            TestData();
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
            _computersNode = _rootNode.Nodes.Add("Computers", "Computers");
            _computersNode.ImageIndex = 3;
            _computersNode.SelectedImageIndex = 3;

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

                TreeNode item2 = _computersNode.Nodes.Add("Computers" + i.ToString(), "File " + i.ToString());
                item2.ImageIndex = 4;
                item2.SelectedImageIndex = 4;
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
                    WebLogUserControl control = new WebLogUserControl();                    

                    tabMain.TabPages.Add(logFile, name,2);
                    tabMain.TabPages[logFile].Controls.Add(control);
                    control.Dock = DockStyle.Fill;

                    LogParser parser = new LogParser();
                    parser.FileName = logFile;
                    parser.AnalyzeLogHandler += new EventHandler<LogInfoEventArgs>(OnAnalyzeLog);
                    parser.EndAnalyzeHandler += new EventHandler<LogInfoEventArgs>(OnEndAnalyze); 
                    

                    parser.Analyze();
                    _listParser.Add(logFile, parser);

                    tabMain.SelectedTab = tabMain.TabPages[logFile];
                }
                
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (KeyValuePair<string, LogParser> parser in _listParser)
            {
                if (parser.Value!=null)
                    ((LogParser)parser.Value).CancelAnalyze();
            }
                
        }

        private void toolStripOpenLogFile_Click(object sender, EventArgs e)
        {
            openLogFileToolStripMenuItem_Click(sender, e);
        }

        
    }
}
