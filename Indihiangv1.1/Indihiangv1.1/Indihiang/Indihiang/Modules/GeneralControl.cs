using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Data;
using Indihiang.Cores.Features;
using Indihiang.Cores;
namespace Indihiang.Modules
{
    public partial class GeneralControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        List<string> _listFiles = new List<string>();
        List<string> _listServers = new List<string>();
        private string _guid;
        private string _fileName;

        public List<string> FileNames
        {
            get
            {
                return _listFiles;
            }
            set
            {
                if (_listFiles == value)
                    return;

                _listFiles = value;                
            }
        }

        public GeneralControl()
        {
            InitializeComponent();
            _synContext = AsyncOperationManager.SynchronizationContext;
        }

        #region BaseControl Members
        public event EventHandler<RenderInfoEventArgs> RenderHandler;

        public string FeatureGuid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }
        public void Populate()
        {
            backgroundJob.RunWorkerAsync();
        }
        #endregion

        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void ShowData()
        {
            listBoxFileName.Items.AddRange(_listFiles.ToArray());
            listBoxIPAddress.Items.AddRange(_listServers.ToArray());
            lbTotalFile.Text = String.Format("{0} files", _listFiles.Count);

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.GENERAL, _fileName);
            _synContext.Post(OnRenderHandler, info);

            /*
            if (DataSource.Count > 0)
            {
                List<DateTime> list = new List<DateTime>();
                foreach (KeyValuePair<string, WebLog> item in DataSource["General"].Colls)
                {
                    if (!string.IsNullOrEmpty(item.Key) && item.Key != "-" )
                        list.Add(DateTime.ParseExact(item.Key, "yyyy-MM-dd", null));
                }
                if (list.Count > 0)
                {
                    DateTime startDate = list.Min();
                    DateTime endDate = list.Max();
                    lbTime.Text = String.Format("{0:dd-MMM-yyyy} - {1:dd-MMM-yyyy}", startDate, endDate);
                }
                else
                    lbTime.Text = "-";

                List<string> list2 = new List<string>();
                foreach (KeyValuePair<string, WebLog> item in DataSource["IPServer"].Colls)
                {
                    if (!string.IsNullOrEmpty(item.Key) && item.Key != "-")
                        list2.Add(item.Key);
                }

                if (DataSource["TotalData"].Colls.Count > 0)
                {
                    int total = Convert.ToInt32(DataSource["TotalData"].Colls["TotalData"].Items["TotalData"]);
                    lbTotalData.Text = String.Format("{0} rows data", total);
                }
                else
                    lbTotalData.Text = "No row data";
                
                listBoxFileName.Items.AddRange(_listFiles.ToArray());
                listBoxIPAddress.Items.AddRange(list2.ToArray());
                lbTotalFile.Text = String.Format("{0} files", _listFiles.Count);
            }

            */
        }

        private void backgroundJob_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            LogDataFacade facade = new LogDataFacade(_guid);
            _listServers = facade.GetServerList();
            _listFiles = facade.GetLogFileList();

        }

        private void backgroundJob_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ShowData();
        }


       
    }
}
