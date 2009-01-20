using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Indihiang.Forms
{
    public partial class MainForm : Form
    {
        private TreeNode _rootNode;
        private TreeNode _logFileaNode;
        private TreeNode _computersNode;

        public MainForm()
        {
            InitializeComponent();
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
            }
        }
    }
}
