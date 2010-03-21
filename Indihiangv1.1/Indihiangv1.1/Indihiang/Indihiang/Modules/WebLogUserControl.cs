using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Indihiang.Cores;
using Indihiang.Data;
using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class WebLogUserControl : UserControl
    {
        public const int EM_REPLACESEL = 0xc2;
        public const int EM_SETMODIFY = 0xb9;

        private Guid _loadingId = Guid.NewGuid();
        private Guid _guidReportId;
        private bool _useExistingData;
        private int _totalControls;

        public event EventHandler<RenderInfoEventArgs> EndRenderHandler;

        public WebLogUserControl()
        {
            InitializeComponent();
        }

        protected virtual void OnEndRenderHandler(RenderInfoEventArgs e)
        {
            if (EndRenderHandler != null)
            {
                if (_useExistingData)
                    e.Id = _guidReportId.ToString();

                EndRenderHandler(this, e);
            }
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
            _guidReportId = parser.LogParserId;
            _useExistingData = parser.UseExistData;

            PopulateParalel(parser);
        }

        private List<string> GetListOfYear(string guid)
        {
            LogDataFacade facade = new LogDataFacade(guid);
            
            return facade.GetListyearLogFile();
        }

        private void PopulateParalel(LogParser parser)
        {
            string id = "";
            string info = string.Empty;

            List<string> listOfYear = new List<string>();

            if (!parser.UseExistData)
                listOfYear = GetListOfYear(parser.LogParserId.ToString());
            else
                listOfYear.Add(IndihiangHelper.GetYearDataIndihiangFile(parser.FileName));


            _totalControls = 9;
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on GENERAL...");
            AddLogStatus(info);
            id = LogFeature.GENERAL.ToString();
            GeneralControl uc1 = new GeneralControl();
            uc1.FileName = parser.FileName;
            if (!parser.UseExistData)
                uc1.FeatureGuid = parser.LogParserId.ToString();
            else
                uc1.FeatureGuid = string.Format("!!{0}", parser.FileName);
            Attach(uc1, id, "General");

            
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on USERAGENT...");
            AddLogStatus(info);
            id = LogFeature.USERAGENT.ToString();
            UserAgentControl uc2 = new UserAgentControl();
            uc2.FileName = parser.FileName;
            if (!parser.UseExistData)
                uc2.FeatureGuid = parser.LogParserId.ToString();
            else
                uc2.FeatureGuid = string.Format("!!{0}", parser.FileName);
            uc2.ListOfYear = listOfYear;
            Attach(uc2, id, "User Agent");

           
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on HITS...");
            AddLogStatus(info);
            id = LogFeature.HITS.ToString();
            HitsControl uc3 = new HitsControl();
            uc3.FileName = parser.FileName;
            if (!parser.UseExistData)
                uc3.FeatureGuid = parser.LogParserId.ToString();
            else
                uc3.FeatureGuid = string.Format("!!{0}", parser.FileName);
            uc3.ListOfYear = listOfYear;
            Attach(uc3, id, "Hits");

           
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on ACCESS...");
            AddLogStatus(info);
            id = LogFeature.ACCESS.ToString();
            AccessPageControl uc4 = new AccessPageControl();
            uc4.FileName = parser.FileName;
            if (!parser.UseExistData)
                uc4.FeatureGuid = parser.LogParserId.ToString();
            else
                uc4.FeatureGuid = string.Format("!!{0}", parser.FileName);
            uc4.ListOfYear = listOfYear;
            Attach(uc4, id, "Access Page");

            
            info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on IPADDRESS...");
            AddLogStatus(info);
            id = LogFeature.IPADDRESS.ToString();
            IPAddressControl uc5 = new IPAddressControl();
            uc5.FileName = parser.FileName;
            if (!parser.UseExistData)
                uc5.FeatureGuid = parser.LogParserId.ToString();
            else
                uc5.FeatureGuid = string.Format("!!{0}", parser.FileName);
            uc5.ListOfYear = listOfYear;
            Attach(uc5, id, "IP Address");

           info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on STATUS...");
           AddLogStatus(info);
           id = LogFeature.STATUS.ToString();
           AccessStatusControl uc6 = new AccessStatusControl();
           uc6.FileName = parser.FileName;
           if (!parser.UseExistData)
               uc6.FeatureGuid = parser.LogParserId.ToString();
           else
               uc6.FeatureGuid = string.Format("!!{0}", parser.FileName);
           uc6.ListOfYear = listOfYear;
           Attach(uc6, id, "HTTP Status");

            
           info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on BANDWIDTH...");
           AddLogStatus(info);
           id = LogFeature.BANDWIDTH.ToString();
           BandwidthControl uc7 = new BandwidthControl();
           uc7.FileName = parser.FileName;
           if (!parser.UseExistData)
               uc7.FeatureGuid = parser.LogParserId.ToString();
           else
               uc7.FeatureGuid = string.Format("!!{0}", parser.FileName);
           uc7.ListOfYear = listOfYear;
           Attach(uc7, id, "Bandwidth");

             
           info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on REQUEST...");
           AddLogStatus(info);
           id = LogFeature.REQUEST.ToString();
           RequestProcessingControl uc8 = new RequestProcessingControl();
           uc8.FileName = parser.FileName;
           if (!parser.UseExistData)
               uc8.FeatureGuid = parser.LogParserId.ToString();
           else
               uc8.FeatureGuid = string.Format("!!{0}", parser.FileName);
           uc8.ListOfYear = listOfYear;
           Attach(uc8, id, "Processing Request");

           info = String.Format("{0:yyyy/MM/dd HH:mm:ss}[info]: {1}", DateTime.Now, "Populating data on REFERER...");
           AddLogStatus(info);
           id = LogFeature.REFERER.ToString();
           RefererControl uc9 = new RefererControl();
           uc9.FileName = parser.FileName;
           if (!parser.UseExistData)
               uc9.FeatureGuid = parser.LogParserId.ToString();
           else
               uc9.FeatureGuid = string.Format("!!{0}", parser.FileName);
           uc9.ListOfYear = listOfYear;
           Attach(uc9, id, "Referer");
           
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
