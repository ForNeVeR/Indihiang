using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Data;
using Indihiang.Cores.Features;
using Indihiang.Cores;
using Indihiang.DomainObject;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class UserAgentControl : UserControl,BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private List<string> _listYears = new List<string>();
        private List<string> _listYearMonth = new List<string>();
        private List<DumpData> _listAgentData = new List<DumpData>();
        private Dictionary<string, long> _listPerAgent = new Dictionary<string, long>();

        public UserAgentControl()
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
            backgroundJob.RunWorkerAsync();            
        }
        #endregion

        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void GenerateGraphUserAgent1()
        {
            GraphPane pane = zedUserAgent1.GraphPane;
            pane.CurveList.Clear();

            if (cboReport.SelectedIndex == 0)
            {
                pane.Title.Text = String.Format("Total Hist/Month by User Agent for Year {0} Graph", cboParams.SelectedValue);
                pane.XAxis.Type = AxisType.DateAsOrdinal;
                pane.XAxis.Scale.Format = "MMM-yyyy";
            }
            else
            {
                pane.Title.Text = String.Format("Total Hist/Day by User Agent for {0} Graph", cboParams.SelectedValue);
                pane.XAxis.Type = AxisType.DateAsOrdinal;
                pane.XAxis.Scale.Format = "MMM-dd-yyyy";
            }
            
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Legend.Position = LegendPos.Bottom;
            pane.Chart.Fill = new Fill(Color.White,Color.SkyBlue, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listAgentData.Count > 0)
            {
                double x;
                Dictionary<string, PointPairList> list = new Dictionary<string, PointPairList>();

                if (cboReport.SelectedIndex == 0)
                {
                    int year = Convert.ToInt32(cboParams.SelectedItem);
                    for (int i = 0; i < _listAgentData.Count; i++)
                    {
                        DateTime date = new DateTime(year, _listAgentData[i].Month, 1);
                        x = date.ToOADate();

                        if (!list.ContainsKey(_listAgentData[i].User_Agent))
                        {
                            PointPairList tmp = new PointPairList();
                            tmp.Add(x, Convert.ToDouble(_listAgentData[i].Total));
                            list.Add(_listAgentData[i].User_Agent, tmp);
                        }
                        else
                        {
                            list[_listAgentData[i].User_Agent].Add(x, Convert.ToDouble(_listAgentData[i].Total));
                        }
                    }
                }
                else
                {
                    string itm = cboParams.SelectedItem.ToString();
                    string[] ls = itm.Split(new char[] { '-' });
                    int year = Convert.ToInt32(ls[1]);
                    for (int i = 0; i < _listAgentData.Count; i++)
                    {
                        DateTime date = new DateTime(year, _listAgentData[i].Month, _listAgentData[i].Day);
                        x = date.ToOADate();

                        if (!list.ContainsKey(_listAgentData[i].User_Agent))
                        {
                            PointPairList tmp = new PointPairList();
                            tmp.Add(x, Convert.ToDouble(_listAgentData[i].Total));
                            list.Add(_listAgentData[i].User_Agent, tmp);
                        }
                        else
                        {
                            list[_listAgentData[i].User_Agent].Add(x, Convert.ToDouble(_listAgentData[i].Total));
                        }
                    }
                }
           
                foreach (KeyValuePair<string, PointPairList> item in list)
                {
                    LineItem curve = null;
                    if (item.Key == "MS Internet Explorer")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Blue, SymbolType.Diamond);
                    if (item.Key == "Firefox")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Red, SymbolType.Diamond);

                    if (item.Key == "Safari")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Green, SymbolType.Diamond);

                    if (item.Key == "Google Chrome")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Cyan, SymbolType.Diamond);

                    if (item.Key == "Mozilla")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Yellow, SymbolType.Diamond);

                    if (item.Key == "Netscape")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Brown, SymbolType.Diamond);

                    if (item.Key == "Mobile Browser")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Magenta, SymbolType.Diamond);

                    if (item.Key == "Unknown")
                        curve = pane.AddCurve(item.Key, item.Value, Color.Black, SymbolType.Diamond);
                    if (curve != null)
                    {
                        curve.Line.IsSmooth = true;
                        curve.Line.SmoothTension = 0.5F;
                    }
                    
                }
             
            }

            zedUserAgent1.IsShowPointValues = true;
            zedUserAgent1.AxisChange();
        }
        private void GenerateGraphUserAgent2()
        {
            GraphPane pane = zedUserAgent2.GraphPane;

            pane.Title.Text = "User Agent Percent Graph";            
            pane.Legend.Position = LegendPos.InsideTopRight;
            pane.Chart.Fill = new Fill(Color.White, Color.SkyBlue, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listPerAgent.Count > 0)
            {
                double total = _listPerAgent.Values.Sum();                
                foreach (KeyValuePair<string, long> item in _listPerAgent)
                {                    
                    if (item.Key == "MS Internet Explorer")
                        pane.AddPieSlice(item.Value, 
                            Color.Blue, 
                            Color.White, 45f, 0.2, 
                            item.Key + " (" + 
                            string.Format("{0:0.##}",(double)(item.Value*100/total))+ " %)");
                    if (item.Key == "Firefox")
                        pane.AddPieSlice(item.Value, 
                            Color.Red, 
                            Color.White, 45f, 0, 
                            item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Safari")
                        pane.AddPieSlice(item.Value, 
                            Color.Green, 
                            Color.White, 45f, 0, 
                            item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Google Chrome")
                        pane.AddPieSlice(item.Value, 
                            Color.Cyan,
                            Color.White, 45f, 0, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Opera")
                        pane.AddPieSlice(item.Value, 
                            Color.Purple, 
                            Color.White, 45f, 0, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Netscape")
                        pane.AddPieSlice(item.Value, 
                            Color.Brown, 
                            Color.White, 45f, 0, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Mobile Browser")
                        pane.AddPieSlice(item.Value,
                            Color.Magenta,
                            Color.White, 45f, 0, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                    if (item.Key == "Unknown")
                        pane.AddPieSlice(item.Value, Color.Black, 
                            Color.White, 45f, 0.2, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                }

            }

            zedUserAgent2.AxisChange();
        }
        private void SetSize()
        {
            zedUserAgent1.Location = new Point(10, 10);
            zedUserAgent1.Size = new Size(ClientRectangle.Width - 20,ClientRectangle.Height - 20);
            zedUserAgent2.Location = new Point(10, 10);
            zedUserAgent2.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void UserAgentControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private string zedUserAgent1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime date = DateTime.FromOADate(pt.X);
            string sdate = date.ToString("MMM-dd-yyyy");

            return String.Format("{0}\r\nTime: {1}\r\nTotal: {2:f2} Hit(s)", curve.Label.Text,sdate, pt.Y);

        }

        private void backgroundJob_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LogDataFacade facade = new LogDataFacade(_guid);
                _listPerAgent = facade.GetTotalPerUserAgent();
                //_listYears = facade.GetListyearLogFile();

                for (int i = 0; i < _listYears.Count; i++)
                {
                    List<string> list = facade.GetMonthLogFileListByYear(_listYears[i]);
                    for (int j = 0; j < list.Count; j++)
                    {
                        string monthYear = string.Format("{0}-{1}", IndihiangHelper.GetMonth(Convert.ToInt32(list[j])), _listYears[i]);
                        _listYearMonth.Add(monthYear);
                    }
                }
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);
                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJob_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            cboReport.SelectedIndex = 0;
            GenerateGraphUserAgent2();
            SetSize();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.USERAGENT, _fileName);
            _synContext.Post(OnRenderHandler, info);
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboParams.Items.Clear();
            if (cboReport.SelectedIndex == 0)
            {
                if (_listYears != null)
                {
                    cboParams.Items.AddRange(_listYears.ToArray());
					if (cboParams.Items.Count > 0)
						cboParams.SelectedIndex = 0;
                }
            }
            if (cboReport.SelectedIndex == 1)
            {
                if (_listYearMonth != null)
                {
                    cboParams.Items.AddRange(_listYearMonth.ToArray());
					if (cboParams.Items.Count > 0)
						cboParams.SelectedIndex = 0;
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboReport.SelectedIndex < 0 || cboParams.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose report type and its parameter", "Information");
                return;
            }
            if (cboReport.SelectedIndex >=0)
            {
                btnGenerate.Enabled = false;
                lbStatus.Visible = true;

                backgroundReportJob.RunWorkerAsync(cboParams.SelectedItem);
            }
           

        }

        private void backgroundReportJob_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                if (par.Contains("-"))
                {
                    string[] items = par.Split(new char[] { '-' });
                    int month = IndihiangHelper.GetMonth(items[0]);
                    _listAgentData = facade.GetTotalPerUserAgentByParams(Convert.ToInt32(items[1]), month);
                }
                else
                {
                    _listAgentData = facade.GetTotalPerUserAgentByParams(Convert.ToInt32(par));
                }
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundReportJob_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGenerate.Enabled = true;
            lbStatus.Visible = false;

            GenerateGraphUserAgent1();
            SetSize();
        }
    }
}
