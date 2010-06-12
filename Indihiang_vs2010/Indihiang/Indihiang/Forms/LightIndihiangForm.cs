using System;
using System.Windows.Forms;
using System.IO;

using Indihiang.Cores;
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

            _delegate = UpdateTextMethod;
            _delegateControl = UpdateControlMethod;
        }
        public LightIndihiangForm()
        {
            
        }         

        private void LightIndihiangForm_Load(object sender, EventArgs e)
        {
            _parser.AnalyzeLogHandler += OnAnalyzeLog;
            _parser.EndAnalyzeHandler += OnEndAnalyze;

            if (File.Exists(_fileName))
                RunAnalyer();
            else
                this.Text = "Indihiang - No IIS log file..";
        }

        private void RunAnalyer()
        {
            string name = Path.GetFileName(_fileName);

            Text = String.Format("Indihiang - {0}", name);
            _parser.FileName = _fileName;
            _parser.UseExistData = false;
            _parser.LogParserId = Guid.NewGuid();
            _parser.UseParallel = true;
            _parser.Analyze();           
        }
        internal void OnAnalyzeLog(object sender, LogInfoEventArgs e)
        {
            string info = "";

            switch (e.LogStatus)
            {
                case LogProcessStatus.SUCCESS:
                    info = String.Format("{0:yyyy/MM/dd hh:mm:dd}[info]: {1}", DateTime.Now, e.Message);
                    break;
                case LogProcessStatus.FAILED:
                    info = String.Format("{0:yyyy/MM/dd hh:mm:dd}[err]: {1}", DateTime.Now, e.Message);
                    break;
                case LogProcessStatus.CANCELED:
                    info = String.Format("{0:yyyy/MM/dd hh:mm:dd}[info]: Log analyzer is canceled by user", DateTime.Now);
                    break;
            }

            Invoke(this._delegate, new object[] { info });
        }
        internal void OnEndAnalyze(object sender, LogInfoEventArgs e)
        {
            string info = "";
            info = String.Format("{0:yyyy/MM/dd hh:mm:dd}[info]: Finish", DateTime.Now);

            Invoke(_delegate, new object[] { info });
            Invoke(_delegateControl);
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
