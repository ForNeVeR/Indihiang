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
        public WebLogUserControl()
        {
            InitializeComponent();
        }

        public void AddLogStatus(string logMessage)
        {
            string temp = this.txtLog.Text;
            string newLog = temp + "\r\n" + logMessage;

            this.txtLog.Text = newLog;            
        }
        public void Populate(LogParser parser)
        {
            string id = "";
            for (int i = 0; i < parser.Features.Count;i++ )
            {
                switch (parser.Features[i].FeatureName)
                {
                    case LogFeature.USERAGENT:
                        id = LogFeature.USERAGENT.ToString();
                        UserAgentControl uc1 = new UserAgentControl();

                        tabMainLog.TabPages.Add(id, "User Agent", 0);
                        tabMainLog.TabPages[id].Controls.Add(uc1);
                        uc1.Dock = DockStyle.Fill;
                        uc1.DataSource = parser.Features[i].Items;
                        uc1.Populate();
                        tabMainLog.SelectedTab = tabMainLog.TabPages[id];

                        break;
                    case LogFeature.HITS:
                        id = LogFeature.HITS.ToString();
                        HitsControl uc2 = new HitsControl();

                        tabMainLog.TabPages.Add(id, "Hits", 0);
                        tabMainLog.TabPages[id].Controls.Add(uc2);
                        uc2.Dock = DockStyle.Fill;
                        uc2.DataSource = parser.Features[i].Items;
                        uc2.Populate();
                        tabMainLog.SelectedTab = tabMainLog.TabPages[id];

                        break;
                }
            }
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
