using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Data;
using Indihiang.DomainObject;
using Indihiang.Cores.Features;
using Indihiang.Cores;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class HitsControl : UserControl,BaseControl
    {
        private SynchronizationContext _synContext;
        private List<string> _listYears = new List<string>();
        private List<DumpData> _listHits1 = new List<DumpData>();
        private List<DumpData> _listHits2 = new List<DumpData>();
        private List<DumpData> _listHits3 = new List<DumpData>();
        private string _guid;
        private string _fileName;        

        public HitsControl()
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
            cboYear1.Items.AddRange(_listYears.ToArray());
            cboYear2.Items.AddRange(_listYears.ToArray());
            cboYear3.Items.AddRange(_listYears.ToArray());

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.HITS, _fileName);
            _synContext.Post(OnRenderHandler, info);
            
        }
        #endregion
        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void SetGridLayout1()
        {
            dataGridHits.ColumnCount = 2;
            dataGridHits.Columns[0].Name = "Hits";
            dataGridHits.Columns[0].Width = 150;
            dataGridHits.Columns[0].ValueType = typeof(System.DateTime);
            dataGridHits.Columns[0].DefaultCellStyle.Format = "dd MMM yyyy";
            dataGridHits.Columns[1].Name = "Total Hits";
            dataGridHits.Columns[1].Width = 100;
            dataGridHits.Columns[0].ValueType = typeof(System.Int32);

            dataGridHits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHits.MultiSelect = false;
        }
        private void SetGridLayout2()
        {
            dataGridHits.ColumnCount = 2;
            dataGridHits.Columns[0].Name = "Hits (Month)";
            dataGridHits.Columns[0].Width = 150;
            dataGridHits.Columns[0].ValueType = typeof(System.DateTime);
            dataGridHits.Columns[0].DefaultCellStyle.Format = "MMM yyyy";
            dataGridHits.Columns[1].Name = "Total Hits";
            dataGridHits.Columns[1].Width = 100;
            dataGridHits.Columns[0].ValueType = typeof(System.Int32);

            dataGridHits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHits.MultiSelect = false;
        }

        private void GenerateGraphHitsPerDay()
        {
            GraphPane pane = zedHits1.GraphPane;
            pane.CurveList.Clear();

            pane.Title.Text = "Total Hist per Day Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));            

            if (_listHits1.Count>0)
            {
                double x, y;
                PointPairList list1 = new PointPairList();

                string year = cboYear1.SelectedItem.ToString();
                for (int i = 0; i < _listHits1.Count; i++)
                {
                    DateTime date = new DateTime(Convert.ToInt32(year), _listHits1[i].Month, _listHits1[i].Day);
                    x = date.ToOADate();

                    y = Convert.ToDouble(_listHits1[i].Total);
                    list1.Add(x, y);
                }
        

                LineItem line = pane.AddCurve("Hits per Day",list1, Color.Red, SymbolType.Star);
                line.Line.IsSmooth = true;
            }

            zedHits1.IsShowPointValues = true;
            zedHits1.AxisChange();

        }
        private void GenerateGraphHitsPerMonth()
        {
            GraphPane pane = zedHits2.GraphPane;
            pane.CurveList.Clear();

            pane.Title.Text = "Total Hist per Month Graph";
            pane.XAxis.Title.Text = "Month";
            pane.XAxis.Type = AxisType.DateAsOrdinal;
            pane.XAxis.Scale.Format = "MMM";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listHits2.Count > 0)
            {
                double x, y;
                PointPairList list1 = new PointPairList();

                string year = cboYear2.SelectedItem.ToString();
                for (int i = 0; i < _listHits2.Count; i++)
                {
                    DateTime date = new DateTime(Convert.ToInt32(year), _listHits2[i].Month, 1);
                    x = date.ToOADate();

                    y = Convert.ToDouble(_listHits2[i].Total);
                    list1.Add(x, y);
                }

                LineItem line = pane.AddCurve("Hits per Month", list1, Color.Red, SymbolType.Star);
                line.Line.IsSmooth = true;
            }

            zedHits2.IsShowPointValues = true;
            zedHits2.AxisChange();
        }
        private void GenerateGraphHitsGrid()
        {
            string selectedHits = cboHitsData.SelectedItem.ToString();
            if (_listHits3.Count>0)
            {
                dataGridHits.Rows.Clear();
                int year = Convert.ToInt32(cboYear3.SelectedItem);
                if (selectedHits == "Hits per Day")
                {
                    SetGridLayout1();
                    for (int i = 0; i < _listHits3.Count; i++)
                    {
                        DateTime dt = new DateTime(year, _listHits3[i].Month, _listHits3[i].Day);
                        List<object> data = new List<object>();
                        data.Add(dt);
                        data.Add(_listHits3[i].Total);

                        dataGridHits.Rows.Add(data.ToArray());
                    }
                
                }
                if (selectedHits == "Hits per Month")
                {
                    SetGridLayout2();
                    for (int i = 0; i < _listHits3.Count; i++)
                    {
                        DateTime dt = new DateTime(year, _listHits3[i].Month, 1);
                        List<object> data = new List<object>();
                        data.Add(dt);
                        data.Add(_listHits3[i].Total);

                        dataGridHits.Rows.Add(data.ToArray());
                    }
                }
            }
        }

        private void SetSize()
        {
            zedHits1.Location = new Point(10, 10);
            zedHits1.Size = new Size(ClientRectangle.Width - 20,ClientRectangle.Height - 20);

            zedHits2.Location = new Point(10, 10);
            zedHits2.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void HitsControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }     

        private string zedHits1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime date = DateTime.FromOADate(pt.X);

            return String.Format("{0}\r\nTime: {1:yyyy-MMM-dd}\r\nHits: {2:f2}", curve.Label.Text,date, pt.Y);
        }

        private string zedHits2_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime date = DateTime.FromOADate(pt.X);

            return String.Format("[{0:yyyy-MMM} --> {1:f2} Hit(s)]", date, pt.Y);
        }



        //private void backgroundJob_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        LogDataFacade facade = new LogDataFacade(_guid);
        //        _listYears = facade.GetListyearLogFile();
        //    }
        //    catch (Exception err)
        //    {
        //        System.Diagnostics.Debug.WriteLine(err.Message);
        //    }
        //}

        //private void backgroundJob_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    cboYear1.Items.AddRange(_listYears.ToArray());
        //    cboYear2.Items.AddRange(_listYears.ToArray());
        //    cboYear3.Items.AddRange(_listYears.ToArray());

        //    RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.HITS, _fileName);
        //    _synContext.Post(OnRenderHandler, info);
        //}

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            if (cboYear1.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose report year", "Information");
                return;
            }
            btnGenerate1.Text = "Generating...";
            btnGenerate1.Enabled = false;
            backgroundJobHitsDay.RunWorkerAsync(cboYear1.SelectedItem);
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            if (cboYear2.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose report year", "Information");
                return;
            }
            btnGenerate2.Text = "Generating...";
            btnGenerate2.Enabled = false;
            backgroundJobHitsMonth.RunWorkerAsync(cboYear2.SelectedItem);
        }

        private void backgroundJobHitsDay_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listHits1 = new List<DumpData>(facade.GetHitsByParams(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJobHitsDay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listHits1.Count > 0)
            {
                GenerateGraphHitsPerDay();
                SetSize();
            }
            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundJobHitsMonth_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listHits2 = new List<DumpData>(facade.GetMonthHitsByParams(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJobHitsMonth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listHits2.Count > 0)
            {
                GenerateGraphHitsPerMonth();
                SetSize();
            }
            btnGenerate2.Text = "Generate";
            btnGenerate2.Enabled = true;
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            if (cboHitsData.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose report type", "Information");
                return;
            }
            if (cboYear3.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose report year", "Information");
                return;
            }
            btnGenerate3.Text = "Generating...";
            btnGenerate3.Enabled = false;
            backgroundJobHitsDataGrid.RunWorkerAsync(string.Format("{0};{1}", cboHitsData.SelectedItem, cboYear3.SelectedItem));
        }

        private void backgroundJobHitsDataGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                string[] items = par.Split(new char[] { ';' });

                LogDataFacade facade = new LogDataFacade(_guid);

                if (items[0] == "Hits per Day")
                    _listHits3 = new List<DumpData>(facade.GetHitsByParams(Convert.ToInt32(items[1])));

                if (items[0] == "Hits per Month")
                    _listHits3 = new List<DumpData>(facade.GetMonthHitsByParams(Convert.ToInt32(items[1])));
               
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJobHitsDataGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listHits3.Count > 0)
                GenerateGraphHitsGrid();

            btnGenerate3.Text = "Generate";
            btnGenerate3.Enabled = true;
        }
    }
}
