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
    public partial class LightIndihiangForm : Form
    {       
        private string _fileName = "";
        private LogParser _parser = new LogParser();

        private delegate void UpdateText(string data);
        private UpdateText _delegate;
        private delegate void UpdateControl();
        private UpdateControl _delegateControl;

        public LightIndihiangForm(string fileName)
        {
            _fileName = fileName;
            InitializeComponent();

            _delegate = new UpdateText(UpdateTextMethod);
            _delegateControl = new UpdateControl(UpdateControlMethod);
        }

        private void LightIndihiangForm_Load(object sender, EventArgs e)
        {
            _parser.AnalyzeLogHandler += new EventHandler<LogInfoEventArgs>(OnAnalyzeLog);
            _parser.EndAnalyzeHandler += new EventHandler<LogInfoEventArgs>(OnEndAnalyze);

            if (File.Exists(_fileName))
                RunAnalyer();
            else
                this.Text = "Indihiang - No IIS log file..";
        }

        private void RunAnalyer()
        {
            string name = Path.GetFileName(_fileName);

            this.Text = "Indihiang - " + name;
            _parser.FileName = _fileName;           
            _parser.Analyze();           
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

            this.Invoke(this._delegate, new object[] { info });
        }
        internal void OnEndAnalyze(object sender, LogInfoEventArgs e)
        {
            string info = "";
            info = DateTime.Now.ToString("yyyy/MM/dd hh:mm:dd") + "[info]: Finish";

            this.Invoke(this._delegate, new object[] { info });
            this.Invoke(this._delegateControl);
        }

        private void UpdateTextMethod(string data)
        {
            this.webLogUserControl1.AddLogStatus(data);
        }
        private void UpdateControlMethod()
        {
            this.webLogUserControl1.Populate(_parser);
        }

        private void LightIndihiangForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure to exit?",
                                    "Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                _parser.CancelAnalyze();
            }
            else
                e.Cancel = true;
        }
    }
}
