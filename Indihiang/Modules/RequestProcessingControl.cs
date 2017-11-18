using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using Indihiang.Data;
using Indihiang.DomainObject;
using Indihiang.Cores;
using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class RequestProcessingControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private List<string> _listYears = new List<string>();        
        private List<DumpData> _listData;

        public RequestProcessingControl()
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
        public List<string> ListOfYear
        {
            set
            {
                _listYears = value;
            }
            get
            {
                return _listYears;
            }
        }
        public void Populate()
        {
            cboParams1.Items.AddRange(_listYears.ToArray());
            SetGridLayout();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.REQUEST, _fileName);
            _synContext.Post(OnRenderHandler, info);
        }

        #endregion

        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }
        private void SetGridLayout()
        {
            dataGridViewRequest.ColumnCount = 5;
            dataGridViewRequest.Columns[0].Name = "Page Request";
            dataGridViewRequest.Columns[0].Width = 200;
            dataGridViewRequest.Columns[0].ValueType = typeof(String);
            dataGridViewRequest.Columns[1].Name = "Query String";
            dataGridViewRequest.Columns[1].Width = 120;
            dataGridViewRequest.Columns[1].ValueType = typeof(String);
            dataGridViewRequest.Columns[2].Name = "Mean Bytes Sent";
            dataGridViewRequest.Columns[2].Width = 120;
            dataGridViewRequest.Columns[2].ValueType = typeof(Double);
            dataGridViewRequest.Columns[3].Name = "Mean Bytes Sent";
            dataGridViewRequest.Columns[3].Width = 120;
            dataGridViewRequest.Columns[3].ValueType = typeof(Double);
            dataGridViewRequest.Columns[4].Name = "Mean Time Taken";
            dataGridViewRequest.Columns[4].Width = 120;
            dataGridViewRequest.Columns[4].ValueType = typeof(Double);

            dataGridViewRequest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRequest.MultiSelect = false;
        }

        private void GenerateProcessingData()
        {
            dataGridViewRequest.Rows.Clear();

            if (_listData.Count > 0)
            {
                for (int i = 0; i < _listData.Count; i++)
                {
                    List<object> data = new List<object>();

                    data.Add(_listData[i].Page_Access);
                    data.Add(_listData[i].Query_Page_Access);
                    data.Add((Double)((Double)_listData[i].Bytes_Sent / (Double)_listData[i].Total));
                    data.Add((Double)((Double)_listData[i].Bytes_Received / (Double)_listData[i].Total));
                    data.Add((Double)((Double)_listData[i].TimeTaken / (Double)_listData[i].Total));

                    dataGridViewRequest.Rows.Add(data.ToArray());
                }
            }
            lbTotal.Text = string.Format("Total data: {0}", _listData.Count);
            lbTotal.Visible = true;
            _listData.Clear();
        }

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            if (cboParams1.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate1.Text = "Generating...";
            btnGenerate1.Enabled = false;
            backgroundWorker1.RunWorkerAsync(cboParams1.SelectedItem);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listData = new List<DumpData>(facade.GetRequestProcessingByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listData != null)
            {
                // populate 
                GenerateProcessingData();
            }

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }


    }
}
