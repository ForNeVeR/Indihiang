using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Cores;
using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class BandwidthControl : UserControl, BaseControl
    {        
        private long _totalBytesSent;
        private long _totalBytesReceived;
        private Dictionary<string, LogCollection> _items;
        public BandwidthControl()
        {
            InitializeComponent();
        }

        #region BaseControl Members

        public Dictionary<string, Indihiang.Cores.Features.LogCollection> DataSource
        {
            set
            {
                _items = value;
            }
        }

        public void Populate()
        {
            SetGridLayout();
            GenerateGraph();            
            PopulateGeneral();
            GenerateGridIPClient();
        }

        #endregion

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
            dataGridViewBytes1.Columns[1].Name = "Total Bytes";
            dataGridViewBytes1.Columns[1].Width = 200;

            dataGridViewBytes1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBytes1.MultiSelect = false;

            dataGridViewBytes2.ColumnCount = 2;
            dataGridViewBytes2.Columns[0].Name = "Request Page";
            dataGridViewBytes2.Columns[0].Width = 150;
            dataGridViewBytes2.Columns[1].Name = "Total Bytes";
            dataGridViewBytes2.Columns[1].Width = 200;

            dataGridViewBytes2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBytes2.MultiSelect = false;


            dataGridViewByteReceived1.ColumnCount = 2;
            dataGridViewByteReceived1.Columns[0].Name = "Date Time";
            dataGridViewByteReceived1.Columns[0].Width = 150;
            dataGridViewByteReceived1.Columns[1].Name = "Total Bytes";
            dataGridViewByteReceived1.Columns[1].Width = 200;

            dataGridViewByteReceived1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewByteReceived1.MultiSelect = false;

            dataGridViewByteReceived2.ColumnCount = 2;
            dataGridViewByteReceived2.Columns[0].Name = "Request Page";
            dataGridViewByteReceived2.Columns[0].Width = 150;
            dataGridViewByteReceived2.Columns[1].Name = "Total Bytes";
            dataGridViewByteReceived2.Columns[1].Width = 200;

            dataGridViewByteReceived2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewByteReceived2.MultiSelect = false;

            dataGridViewIPClient.ColumnCount = 4;
            dataGridViewIPClient.Columns[0].Name = "IP Client";
            dataGridViewIPClient.Columns[0].Width = 120;
            dataGridViewIPClient.Columns[1].Name = "Total Bytes Sent";
            dataGridViewIPClient.Columns[1].Width = 200;
            dataGridViewIPClient.Columns[2].Name = "Total Bytes Received";
            dataGridViewIPClient.Columns[2].Width = 200;
            dataGridViewIPClient.Columns[3].Name = "Total Bytes";
            dataGridViewIPClient.Columns[3].Width = 200;

            dataGridViewIPClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIPClient.MultiSelect = false;

        }
        private void GenerateGraph()
        {
            GraphPane pane = zedGraphBytesInOut.GraphPane;

            pane.Title.Text = "The Bytes Sent and Received Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Bytes";
            pane.BarSettings.Type = BarType.Stack;

            if (_items.Count > 0)
            {                
                PointPairList list1 = GenerateBytesSent();
                PointPairList list2 = GenerateBytesReceived();
                
                pane.XAxis.Type = AxisType.Date;
                pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
                pane.Fill = new Fill(Color.White,Color.FromArgb(195, 227, 96));
                
                pane.AddCurve("Bytes Sent per Day", list1, Color.Red, SymbolType.Diamond);
                pane.AddCurve("Bytes Received per Day", list2, Color.Blue, SymbolType.XCross);
            }

            dataGridViewBytes1.Columns[0].DisplayIndex = 0;
            dataGridViewBytes1.Columns[1].DisplayIndex = 1;
            dataGridViewBytes2.Columns[0].DisplayIndex = 0;
            dataGridViewBytes2.Columns[1].DisplayIndex = 1;
            dataGridViewByteReceived1.Columns[0].DisplayIndex = 0;
            dataGridViewByteReceived1.Columns[1].DisplayIndex = 1;
            dataGridViewByteReceived2.Columns[0].DisplayIndex = 0;
            dataGridViewByteReceived2.Columns[1].DisplayIndex = 1;

            zedGraphBytesInOut.IsShowPointValues = true;
            zedGraphBytesInOut.AxisChange();

        }

        private void GenerateGridIPClient()
        {
            if (!_items.ContainsKey("ByteIPClient"))
                return;

            var items = from k in _items["ByteIPClient"].Colls
                        orderby k.Key ascending
                        select k;

            foreach (KeyValuePair<string, WebLog> item in items)
            {
                if (item.Value != null)
                {
                    long totalBytes1 = 0;
                    List<object> list = new List<object>();

                    list.Add(item.Key);
                    if (item.Value.Items.ContainsKey("Sent"))
                        if (!string.IsNullOrEmpty(item.Value.Items["Sent"]))
                            totalBytes1 = Convert.ToInt64(item.Value.Items["Sent"]);

                    list.Add(IndihiangHelper.BytesFormat(totalBytes1));

                    long totalBytes2 = 0;
                    if (item.Value.Items.ContainsKey("Received"))
                        if (!string.IsNullOrEmpty(item.Value.Items["Received"]))
                            totalBytes2 = Convert.ToInt64(item.Value.Items["Received"]);

                    list.Add(IndihiangHelper.BytesFormat(totalBytes2));
                    list.Add(IndihiangHelper.BytesFormat(totalBytes1 + totalBytes2));

                    dataGridViewIPClient.Rows.Add(list.ToArray());
                }
            }

            dataGridViewIPClient.Columns[0].DisplayIndex = 0;
            dataGridViewIPClient.Columns[1].DisplayIndex = 1;
            dataGridViewIPClient.Columns[2].DisplayIndex = 2;
            dataGridViewIPClient.Columns[3].DisplayIndex = 3;
        }

        private PointPairList GenerateBytesSent()
        {            
            _totalBytesSent = 0;
            PointPairList list1 = new PointPairList();
            Dictionary<string, List<double>> listData1 = new Dictionary<string, List<double>>();

            if (!_items.ContainsKey("BytesSent"))
                return list1;

            var items = from k in _items["BytesSent"].Colls
                        orderby k.Key ascending
                        select k;

            foreach (KeyValuePair<string, WebLog> item in items)
            {
                if (item.Value != null)
                {
                    DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);

                    double totalBytes = 0;
                    foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                    {
                        if (listData1.ContainsKey(ilog.Key))
                            listData1[ilog.Key].Add(Convert.ToDouble(ilog.Value));
                        else
                        {
                            List<double> data = new List<double>();
                            data.Add(Convert.ToDouble(ilog.Value));

                            listData1.Add(ilog.Key, data);
                        }

                        totalBytes = totalBytes + Convert.ToDouble(ilog.Value);
                    }
                    _totalBytesSent = _totalBytesSent + (int)totalBytes;
                    list1.Add(date.ToOADate(), totalBytes);

                    List<object> data1 = new List<object>();
                    data1.Add(date.ToString("yyyy-MMM-dd"));
                    data1.Add(IndihiangHelper.BytesFormat((long)totalBytes));
                    dataGridViewBytes1.Rows.Add(data1.ToArray());
                }
            }

            if (listData1.Count > 0)
            {

                Dictionary<string, List<double>> newList = CollectionHelper.SortList(listData1);
                foreach (KeyValuePair<string, List<double>> item in newList)
                {
                    List<object> data = new List<object>();
                    data.Add(item.Key);
                    data.Add(IndihiangHelper.BytesFormat((long)item.Value.Sum()));
                    dataGridViewBytes2.Rows.Add(data.ToArray());

                }
            }

            return list1;
        }
        private PointPairList GenerateBytesReceived()
        {
            _totalBytesReceived = 0;
            PointPairList list1 = new PointPairList();
            Dictionary<string, List<double>> listData1 = new Dictionary<string, List<double>>();

            if (!_items.ContainsKey("ByteReceived"))
                return list1;


            var items = from k in _items["ByteReceived"].Colls
                        orderby k.Key ascending
                        select k;

            foreach (KeyValuePair<string, WebLog> item in items)
            {
                if (item.Value != null)
                {
                    DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);

                    double totalBytes = 0;
                    foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                    {
                        if (listData1.ContainsKey(ilog.Key))
                            listData1[ilog.Key].Add(Convert.ToDouble(ilog.Value));
                        else
                        {
                            List<double> data = new List<double>();
                            data.Add(Convert.ToDouble(ilog.Value));

                            listData1.Add(ilog.Key, data);
                        }

                        totalBytes = totalBytes + Convert.ToDouble(ilog.Value);
                    }
                    _totalBytesReceived = _totalBytesReceived + (long)totalBytes;
                    list1.Add(date.ToOADate(), totalBytes);

                    List<object> data1 = new List<object>();
                    data1.Add(date.ToString("yyyy-MMM-dd"));
                    data1.Add(IndihiangHelper.BytesFormat((long)totalBytes));
                    dataGridViewByteReceived1.Rows.Add(data1.ToArray());
                }
            }

            if (listData1.Count > 0)
            {

                Dictionary<string, List<double>> newList = CollectionHelper.SortList(listData1);
                foreach (KeyValuePair<string, List<double>> item in newList)
                {
                    List<object> data = new List<object>();
                    data.Add(item.Key);
                    data.Add(IndihiangHelper.BytesFormat((long)item.Value.Sum()));
                    dataGridViewByteReceived2.Rows.Add(data.ToArray());

                }
            }

            return list1;
        }

        private void SetSize()
        {
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

   
    }
}
