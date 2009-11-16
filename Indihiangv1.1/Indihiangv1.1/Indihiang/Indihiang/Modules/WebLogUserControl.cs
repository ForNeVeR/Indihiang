using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Indihiang.Cores;
using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class WebLogUserControl : UserControl
    {
        public const int EM_REPLACESEL = 0xc2;
        public const int EM_SETMODIFY = 0xb9;

        private Guid _loadingId = Guid.NewGuid();
        private int _totalControls = 0;

        public event EventHandler<RenderInfoEventArgs> EndRenderHandler;

        public WebLogUserControl()
        {
            InitializeComponent();
        }

        protected virtual void OnEndRenderHandler(RenderInfoEventArgs e)
        {
            if (EndRenderHandler != null)
                EndRenderHandler(this,e);

        }


        public void AddLogStatus(string logMessage)
        {
            string newLog = String.Format("\r\n{0}", logMessage);
            if (txtLog.IsHandleCreated)
            {
                txtLog.Select(txtLog.TextLength, txtLog.TextLength);
                SendMessage(txtLog.Handle, EM_REPLACESEL, new IntPtr(-1), newLog);
                SendMessage(txtLog.Handle, EM_SETMODIFY, new IntPtr(0), IntPtr.Zero);
            }
            else
                txtLog.AppendText(newLog);                      
        }
        public void Populate(LogParser parser)
        {
            PopulateParalel(parser);
        }        

        private void PopulateParalel(LogParser parser)
        {
            string id = "";
            string info = string.Empty;

            _totalControls = 3;
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on GENERAL...");
            AddLogStatus(info);
            id = LogFeature.GENERAL.ToString();
            GeneralControl uc1 = new GeneralControl();
            uc1.FileName = parser.FileName;
            uc1.FeatureGuid = parser.LogParserId.ToString();
            uc1.FileNames = IndihiangHelper.ParseFile(parser.FileName);
            Attach(uc1, id, "General");

            
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on USERAGENT...");
            AddLogStatus(info);
            id = LogFeature.USERAGENT.ToString();
            UserAgentControl uc2 = new UserAgentControl();
            uc2.FileName = parser.FileName;
            uc2.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc2, id, "User Agent");

           
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on HITS...");
            AddLogStatus(info);
            id = LogFeature.HITS.ToString();
            HitsControl uc3 = new HitsControl();
            uc3.FileName = parser.FileName;
            uc3.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc3, id, "Hits");

            /*
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on ACCESS...");
            AddLogStatus(info);
            id = LogFeature.ACCESS.ToString();
            AccessPageControl uc4 = new AccessPageControl();
            uc4.FileName = parser.FileName;
            uc4.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc4, id, "Access Page");

            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on IPADDRESS...");
            AddLogStatus(info);
            id = LogFeature.IPADDRESS.ToString();
            IPAddressControl uc5 = new IPAddressControl();
            uc5.FileName = parser.FileName;
            uc5.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc5, id, "IP Address");

            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on STATUS...");
            AddLogStatus(info);
            id = LogFeature.STATUS.ToString();
            AccessStatusControl uc6 = new AccessStatusControl();
            uc6.FileName = parser.FileName;
            uc6.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc6, id, "HTTP Status");

            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on BANDWIDTH...");
            AddLogStatus(info);
            id = LogFeature.BANDWIDTH.ToString();
            BandwidthControl uc7 = new BandwidthControl();
            uc7.FileName = parser.FileName;
            uc7.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc7, id, "Bandwidth");

            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on REQUEST...");
            AddLogStatus(info);
            id = LogFeature.REQUEST.ToString();
            RequestProcessingControl uc8 = new RequestProcessingControl();
            uc8.FileName = parser.FileName;
            uc8.FeatureGuid = parser.LogParserId.ToString();
            Attach(uc8, id, "Processing Request");

            */
            tabMainLog.SelectedTab = tabMainLog.TabPages[LogFeature.GENERAL.ToString()];
        }

        private void Attach(UserControl control, string id, string name)
        {
            tabMainLog.TabPages.Add(id, name, 0);
            tabMainLog.TabPages[id].Controls.Add(control);
            control.Dock = DockStyle.Fill;
            ((BaseControl)control).Populate();
            ((BaseControl)control).RenderHandler += WebLogUserControl_RenderHandler;
        }

        private void WebLogUserControl_RenderHandler(object sender, RenderInfoEventArgs e)
        {
            string info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: Populated data on {1} was done", DateTime.Now, e.Feature.ToString());
            AddLogStatus(info);
            _totalControls--;

            if (_totalControls <= 0)
            {
                OnEndRenderHandler(e);
            }
        }

        public void ShowLoadingControl()
        {
            LoadingControl uc = new LoadingControl();
            tabMainLog.TabPages.Add(_loadingId.ToString(), "Analyzing...", 1);
            tabMainLog.TabPages[_loadingId.ToString()].Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.Start();

            tabMainLog.SelectedTab = tabMainLog.TabPages[_loadingId.ToString()];

        }
        public void HideLoadingControl()
        {
            for (int i = 0; i < tabMainLog.TabPages[_loadingId.ToString()].Controls.Count; i++)
                if (tabMainLog.TabPages[_loadingId.ToString()].Controls[i] is LoadingControl)
                {
                    ((LoadingControl)tabMainLog.TabPages[_loadingId.ToString()].Controls[i]).Stop();
                    break;
                }

            tabMainLog.TabPages.Clear();
        }

        private void WebLogUserControl_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            cboStatus.SelectedIndex = 0;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, String lParam);

    }
}
