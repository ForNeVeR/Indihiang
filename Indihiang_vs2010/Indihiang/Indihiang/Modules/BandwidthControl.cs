using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Data;
using Indihiang.DomainObject;
using Indihiang.Cores;
using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class BandwidthControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private List<string> _listYears = new List<string>(); 
        private long _totalBytesSent;
        private long _totalBytesReceived;
        private List<DumpData> _listSentReceivedBytesByYear;
        private List<DumpData> _listSentBytesPageByYear1;
        private List<DumpData> _listSentBytesPageByYear2;
        private List<DumpData> _listReceivedBytesPageByYear1;
        private List<DumpData> _listReceivedBytesPageByYear2;
        private List<DumpData> _listSentReceivedBytesIPClientByYear;        
        public BandwidthControl()
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
            cboParams2.Items.AddRange(_listYears.ToArray());
            cboParams3.Items.AddRange(_listYears.ToArray());
            cboParams4.Items.AddRange(_listYears.ToArray());            

            SetGridLayout();
            backgroundWorker1.RunWorkerAsync();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.BANDWIDTH, _fileName);
            _synContext.Post(OnRenderHandler, info);
        }

        #endregion

        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void PopulateGeneral()
        {
            lbBytesSent.Text = IndihiangHelper.BytesFormat(_totalBytesSent);
            lbBytesReceived.Text = IndihiangHelper.BytesFormat(_totalBytesReceived);
            lbTotal.Text = IndihiangHelper.BytesFormat(_totalBytesSent + _totalBytesReceived);
        }
        private void SetGridLayout()
        {
            dataGridViewBytes1.ColumnCount = 2;
            dataGridViewBytes1.Columns[0].Name = "Date Time";
            dataGridViewBytes1.Columns[0].Width = 150;
            dataGridViewBytes1.Columns[0].ValueType = typeof(DateTime);
            dataGridViewBytes1.Columns[0].DefaultCellStyle.Format = "dd MMM yyyy";
            dataGridViewBytes1.Columns[1].Name = "Total Bytes";
            dataGridViewBytes1.Columns[1].Width = 120;
            dataGridViewBytes1.Columns[1].ValueType = typeof(Int64);

            dataGridViewBytes1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBytes1.MultiSelect = false;

            dataGridViewBytes2.ColumnCount = 2;
            dataGridViewBytes2.Columns[0].Name = "Request Page";
            dataGridViewBytes2.Columns[0].Width = 150;
            dataGridViewBytes2.Columns[0].ValueType = typeof(String);
            dataGridViewBytes2.Columns[1].Name = "Total Bytes";
            dataGridViewBytes2.Columns[1].Width = 120;
            dataGridViewBytes2.Columns[1].ValueType = typeof(Int64);

            dataGridViewBytes2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBytes2.MultiSelect = false;


            dataGridViewByteReceived1.ColumnCount = 2;
            dataGridViewByteReceived1.Columns[0].Name = "Date Time";
            dataGridViewByteReceived1.Columns[0].Width = 150;
            dataGridViewByteReceived1.Columns[0].ValueType = typeof(DateTime);
            dataGridViewByteReceived1.Columns[0].DefaultCellStyle.Format = "dd MMM yyyy";
            dataGridViewByteReceived1.Columns[1].Name = "Total Bytes";
            dataGridViewByteReceived1.Columns[1].Width = 120;
            dataGridViewByteReceived1.Columns[1].ValueType = typeof(Int64);

            dataGridViewByteReceived1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewByteReceived1.MultiSelect = false;

            dataGridViewByteReceived2.ColumnCount = 2;
            dataGridViewByteReceived2.Columns[0].Name = "Request Page";
            dataGridViewByteReceived2.Columns[0].Width = 150;
            dataGridViewByteReceived2.Columns[0].ValueType = typeof(String);
            dataGridViewByteReceived2.Columns[1].Name = "Total Bytes";
            dataGridViewByteReceived2.Columns[1].Width = 120;
            dataGridViewByteReceived1.Columns[1].ValueType = typeof(Int64);

            dataGridViewByteReceived2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewByteReceived2.MultiSelect = false;

            dataGridViewIPClient.ColumnCount = 5;
            dataGridViewIPClient.Columns[0].Name = "IP Client";
            dataGridViewIPClient.Columns[0].Width = 120;
            dataGridViewIPClient.Columns[0].ValueType = typeof(String);
            dataGridViewIPClient.Columns[1].Name = "Country";
            dataGridViewIPClient.Columns[1].Width = 120;
            dataGridViewIPClient.Columns[1].ValueType = typeof(String);
            dataGridViewIPClient.Columns[2].Name = "Total Bytes Sent";
            dataGridViewIPClient.Columns[2].Width = 120;
            dataGridViewIPClient.Columns[2].ValueType = typeof(Int64);
            dataGridViewIPClient.Columns[3].Name = "Total Bytes Received";
            dataGridViewIPClient.Columns[3].Width = 120;
            dataGridViewIPClient.Columns[3].ValueType = typeof(Int64);
            dataGridViewIPClient.Columns[4].Name = "Total Bytes";
            dataGridViewIPClient.Columns[4].Width = 120;
            dataGridViewIPClient.Columns[4].ValueType = typeof(Int64);

            dataGridViewIPClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIPClient.MultiSelect = false;

        }

        private void GenerateSentReceivedBytesByYear()
        {
            GraphPane pane = zedGraphBytesInOut.GraphPane;           
            pane.CurveList.Clear();

            pane.Title.Text = "The Bytes Sent and Received Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Type = AxisType.DateAsOrdinal;
            pane.XAxis.Scale.Format = "MMM-dd";
            pane.YAxis.Title.Text = "Total Bytes";            
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));


            if (_listSentReceivedBytesByYear.Count > 0)
            {
                double x, y1,y2;
                PointPairList list1 = new PointPairList();
                PointPairList list2 = new PointPairList();

                string year = cboParams1.SelectedItem.ToString();
                for (int i = 0; i < _listSentReceivedBytesByYear.Count; i++)
                {
                    DateTime date = new DateTime(Convert.ToInt32(year), _listSentReceivedBytesByYear[i].Month, _listSentReceivedBytesByYear[i].Day);
                    x = date.ToOADate();

                    y1 = Convert.ToDouble(_listSentReceivedBytesByYear[i].Bytes_Sent);
                    y2 = Convert.ToDouble(_listSentReceivedBytesByYear[i].Bytes_Received);
                    list1.Add(x, y1);
                    list2.Add(x, y2);
                }


                LineItem line1 = pane.AddCurve("Bytes Sent", list1, Color.Red, SymbolType.Star);
                LineItem line2 = pane.AddCurve("Bytes Received", list2, Color.FromArgb(0, 128, 0), SymbolType.Star);

                line1.Line.IsSmooth = true;
                line2.Line.IsSmooth = true;
            }

            zedGraphBytesInOut.IsShowPointValues = true;
            zedGraphBytesInOut.AxisChange();
            SetSize();
            _listSentReceivedBytesByYear.Clear();
        }

        
        private void GenerateSentBytesPageByYear()
        {
            dataGridViewBytes1.Rows.Clear();
            dataGridViewBytes2.Rows.Clear();
            
            string selectedYear = cboParams2.SelectedItem.ToString();
            int year = Convert.ToInt32(selectedYear);
            if (_listSentBytesPageByYear1.Count > 0)
            {                
                for (int i = 0; i < _listSentBytesPageByYear1.Count; i++)
                {
                    DateTime dt = new DateTime(year, _listSentBytesPageByYear1[i].Month, _listSentBytesPageByYear1[i].Day);
                    List<object> data = new List<object>();
                    data.Add(dt);
                    data.Add(_listSentBytesPageByYear1[i].Bytes_Sent);

                    dataGridViewBytes1.Rows.Add(data.ToArray());
                }
            }
            if (_listSentBytesPageByYear2.Count > 0)
            {
                for (int i = 0; i < _listSentBytesPageByYear2.Count; i++)
                {                    
                    List<object> data = new List<object>();
                    data.Add(_listSentBytesPageByYear2[i].Page_Access);
                    data.Add(_listSentBytesPageByYear2[i].Bytes_Sent);

                    dataGridViewBytes2.Rows.Add(data.ToArray());
                }
            }
            _listSentBytesPageByYear1.Clear();
            _listSentBytesPageByYear2.Clear();
        }
        private void GenerateReceivedBytesPageByYear()
        {
            dataGridViewByteReceived1.Rows.Clear();
            dataGridViewByteReceived2.Rows.Clear();

            string selectedYear = cboParams3.SelectedItem.ToString();
            int year = Convert.ToInt32(selectedYear);
            if (_listReceivedBytesPageByYear1.Count > 0)
            {
                for (int i = 0; i < _listReceivedBytesPageByYear1.Count; i++)
                {
                    DateTime dt = new DateTime(year, _listReceivedBytesPageByYear1[i].Month, _listReceivedBytesPageByYear1[i].Day);
                    List<object> data = new List<object>();
                    data.Add(dt);
                    data.Add(_listReceivedBytesPageByYear1[i].Bytes_Received);

                    dataGridViewByteReceived1.Rows.Add(data.ToArray());
                }
            }
            if (_listReceivedBytesPageByYear2.Count > 0)
            {
                for (int i = 0; i < _listReceivedBytesPageByYear2.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listReceivedBytesPageByYear2[i].Page_Access);
                    data.Add(_listReceivedBytesPageByYear2[i].Bytes_Received);

                    dataGridViewByteReceived2.Rows.Add(data.ToArray());
                }
            }
            _listReceivedBytesPageByYear1.Clear();
            _listReceivedBytesPageByYear2.Clear();
        }

        private void GenerateIPClientReceivedBytesByYear()
        {
            dataGridViewIPClient.Rows.Clear();            

            if (_listSentReceivedBytesIPClientByYear.Count > 0)
            {
                for (int i = 0; i < _listSentReceivedBytesIPClientByYear.Count; i++)
                {                    
                    List<object> data = new List<object>();

                    data.Add(_listSentReceivedBytesIPClientByYear[i].Client_IP);
                    data.Add(_listSentReceivedBytesIPClientByYear[i].IPClientCountry);
                    data.Add(_listSentReceivedBytesIPClientByYear[i].Bytes_Sent);
                    data.Add(_listSentReceivedBytesIPClientByYear[i].Bytes_Received);
                    long total = _listSentReceivedBytesIPClientByYear[i].Bytes_Sent + _listSentReceivedBytesIPClientByYear[i].Bytes_Received;
                    data.Add(total);

                    dataGridViewIPClient.Rows.Add(data.ToArray());
                }
            }

            _listSentReceivedBytesIPClientByYear.Clear();
        }


        private void SetSize()
        {
            zedGraphBytesInOut.Location = new Point(10, 10);
            zedGraphBytesInOut.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);

            zedGraphBytesInOut.Location = new Point(10, 10);
            zedGraphBytesInOut.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void BandwidthControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private string zedGraphBytesInOut_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime date = DateTime.FromOADate(pt.X);

            return String.Format("[{0:yyyy-MMM-dd} --> {1}]", date, IndihiangHelper.BytesFormat((long)pt.Y));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LogDataFacade facade = new LogDataFacade(_guid);
                _totalBytesSent = 0;
                _totalBytesReceived = 0;

                for (int i = 0; i < _listYears.Count; i++)
                {
                    List<long> list = new List<long>(facade.GetTotalSentReceivedBytesByYear(Convert.ToInt32(_listYears[i])));
                    _totalBytesSent = _totalBytesSent + list[0];
                    _totalBytesReceived = _totalBytesReceived + list[1];
                }

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
            PopulateGeneral();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listSentReceivedBytesByYear = new List<DumpData>(facade.GetSentReceivedBytesByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listSentReceivedBytesByYear != null)
            {
                // populate 
                GenerateSentReceivedBytesByYear();
            }

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listSentBytesPageByYear1 = new List<DumpData>(facade.GetSentReceivedBytesByYear(Convert.ToInt32(par)));
                _listSentBytesPageByYear2 = new List<DumpData>(facade.GetPageAccessSentReceivedBytesByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listSentBytesPageByYear1 != null || _listSentBytesPageByYear2!=null)
            {
                // populate 
                GenerateSentBytesPageByYear();
            }

            btnGenerate2.Text = "Generate";
            btnGenerate2.Enabled = true;
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listReceivedBytesPageByYear1 = new List<DumpData>(facade.GetSentReceivedBytesByYear(Convert.ToInt32(par)));
                _listReceivedBytesPageByYear2 = new List<DumpData>(facade.GetPageAccessSentReceivedBytesByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listReceivedBytesPageByYear1 != null || _listReceivedBytesPageByYear2 != null)
            {
                // populate 
                GenerateReceivedBytesPageByYear();
            }

            btnGenerate3.Text = "Generate";
            btnGenerate3.Enabled = true;
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listSentReceivedBytesIPClientByYear = new List<DumpData>(facade.GetClientIPSentReceivedBytesByYear(Convert.ToInt32(par)));                
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listSentReceivedBytesIPClientByYear != null)
            {
                // populate 
                GenerateIPClientReceivedBytesByYear();
            }

            btnGenerate4.Text = "Generate";
            btnGenerate4.Enabled = true;
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
            backgroundWorker2.RunWorkerAsync(cboParams1.SelectedItem);
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            if (cboParams2.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate2.Text = "Generating...";
            btnGenerate2.Enabled = false;
            backgroundWorker3.RunWorkerAsync(cboParams2.SelectedItem);
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            if (cboParams3.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate3.Text = "Generating...";
            btnGenerate3.Enabled = false;
            backgroundWorker4.RunWorkerAsync(cboParams3.SelectedItem);
        }

        private void btnGenerate4_Click(object sender, EventArgs e)
        {
            if (cboParams4.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate4.Text = "Generating...";
            btnGenerate4.Enabled = false;
            backgroundWorker5.RunWorkerAsync(cboParams4.SelectedItem);
        }

        

   
    }
}
