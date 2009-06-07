using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Indihiang.Cores;
using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class WebLogUserControl : UserControl
    {
        private Guid _loadingId = Guid.NewGuid();

        public WebLogUserControl()
        {
            InitializeComponent();
        }

        public void AddLogStatus(string logMessage)
        {
            string temp = txtLog.Text;
            string newLog = String.Format("{0}\r\n{1}", temp, logMessage);

            txtLog.Text = newLog;            
        }
        public void Populate(LogParser parser)
        {            
            string id = "";
            for (int i = 0; i < parser.Features.Count;i++ )
            {
                switch (parser.Features[i].FeatureName)
                {
                    case LogFeature.GENERAL:
                        id = LogFeature.GENERAL.ToString();
                        GeneralControl uc1 = new GeneralControl();
                        uc1.FileNames = IndihiangHelper.ParseFile(parser.FileName);
                        Attach(uc1, id, "General", parser.Features[i].Items); 

                        break;
                    case LogFeature.USERAGENT:
                        id = LogFeature.USERAGENT.ToString();
                        UserAgentControl uc2 = new UserAgentControl();
                        Attach(uc2, id, "User Agent", parser.Features[i].Items); 
                       
                        break;
                    case LogFeature.HITS:
                        id = LogFeature.HITS.ToString();
                        HitsControl uc3 = new HitsControl();
                        Attach(uc3, id, "Hits", parser.Features[i].Items); 

                        break;
                    case LogFeature.ACCESS:
                        id = LogFeature.ACCESS.ToString();
                        AccessPageControl uc4 = new AccessPageControl();
                        Attach(uc4, id, "Access Page", parser.Features[i].Items);                        

                        break;
                    case LogFeature.IPADDRESS:
                        id = LogFeature.IPADDRESS.ToString();
                        IPAddressControl uc5 = new IPAddressControl();
                        Attach(uc5, id, "IP Address", parser.Features[i].Items);

                        break;
                    case LogFeature.STATUS:
                        id = LogFeature.STATUS.ToString();
                        AccessStatusControl uc6 = new AccessStatusControl();
                        Attach(uc6, id, "HTTP Status",parser.Features[i].Items);

                        break;
                }                
            }
            tabMainLog.SelectedTab = tabMainLog.TabPages[LogFeature.GENERAL.ToString()];
        }

        private void Attach(UserControl control, string id,string name,Dictionary<string, LogCollection> dataSource)
        {
            tabMainLog.TabPages.Add(id, name, 0);
            tabMainLog.TabPages[id].Controls.Add(control);
            control.Dock = DockStyle.Fill;
            ((BaseControl)control).DataSource = dataSource;
            ((BaseControl)control).Populate();
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
    }
}
