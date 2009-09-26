using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class HitsControl : UserControl,BaseControl
    {
        private Dictionary<string, LogCollection> _items;

        public HitsControl()
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
            get
            {
                return _items;
            }
        }

        public void Populate()
        {
            SetGridLayout();
            GenerateGraphHitsPerDay();
            GenerateGraphHitsPerMonth();
            SetSize();
        }
        #endregion

        private void SetGridLayout()
        {
            dataGridHits.ColumnCount = 2;
            dataGridHits.Columns[0].Name = "Hits";
            dataGridHits.Columns[0].Width = 300;
            dataGridHits.Columns[1].Name = "Total Hits";
            dataGridHits.Columns[1].Width = 100;

            dataGridHits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHits.MultiSelect = false;
        }

        private void GenerateGraphHitsPerDay()
        {
            GraphPane pane = zedHits1.GraphPane;

            pane.Title.Text = "Total Hist per Day Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));            

            if (_items.Count > 0)
            {
                double x, y;
                PointPairList list1 = new PointPairList();

                var items = from k in _items["General"].Colls
                            orderby k.Key ascending
                            select k;

                foreach (KeyValuePair<string, WebLog> item in items)
                {
                    if (item.Value != null)
                    {
                        DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                        x = date.ToOADate();

                        if (item.Value.Items[item.Key] != "" && item.Value.Items[item.Key] != "-")
                        {
                            y = Convert.ToDouble(item.Value.Items[item.Key]);
                            list1.Add(x, y);
                        }
                    }
                }                

                LineItem line = pane.AddCurve("Hits per Day",list1, Color.Red, SymbolType.Diamond);
            }

            zedHits1.IsShowPointValues = true;
            zedHits1.AxisChange();

        }
        private void GenerateGraphHitsPerMonth()
        {
            GraphPane pane = zedHits2.GraphPane;

            pane.Title.Text = "Total Hist per Month Graph";
            pane.XAxis.Title.Text = "Month";
            pane.XAxis.Type = AxisType.DateAsOrdinal;
            pane.XAxis.Scale.Format = "yyyy-MMM";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_items.Count > 0)
            {
                double x, y;
                PointPairList list1 = new PointPairList();

                var items = from k in _items["General"].Colls
                            orderby k.Key ascending
                            select k;

                Dictionary<DateTime, int> monthData = new Dictionary<DateTime, int>();
                foreach (KeyValuePair<string, WebLog> item in items)
                {
                    if (item.Value != null)
                    {
                        DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                        DateTime newDate = new DateTime(date.Year, date.Month, 1);

                        if (monthData.ContainsKey(newDate))
                            monthData[newDate] = monthData[newDate] + Convert.ToInt32(item.Value.Items[item.Key]);
                        else
                            monthData.Add(newDate, Convert.ToInt32(item.Value.Items[item.Key]));
                    }
                }
                var items2 = from k in monthData
                        orderby k.Key ascending
                        select k;
                foreach (KeyValuePair<DateTime, int> item in items2)
                {
                    x = item.Key.ToOADate();
                    y = Convert.ToDouble(item.Value);
                    list1.Add(x, y);
                }

                LineItem line = pane.AddCurve("Hits per Month", list1, Color.Red, SymbolType.Diamond);
                BarItem bar = pane.AddBar("Hits per Month", list1, Color.Blue);
                bar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);
                
            }

            zedHits2.IsShowPointValues = true;
            zedHits2.AxisChange();

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

            return String.Format("[{0:yyyy-MMM-dd} --> {1:f2} Hit(s)]", date, pt.Y);
        }

        private string zedHits2_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime date = DateTime.FromOADate(pt.X);

            return String.Format("[{0:yyyy-MMM} --> {1:f2} Hit(s)]", date, pt.Y);
        }

        private void cboHitsData_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHits = cboHitsData.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedHits))
            {
                dataGridHits.Rows.Clear();
                if (selectedHits == "Hits per Day")
                {
                    var items = from k in _items["General"].Colls
                                orderby k.Key ascending
                                select k;

                    foreach (KeyValuePair<string, WebLog> item in items)
                    {
                        if (item.Value != null)
                        {
                            DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                            List<object> data = new List<object>();
                            data.Add(date.ToString("yyyy-MMM-dd"));
                            data.Add(Convert.ToInt32(item.Value.Items[item.Key]));

                            dataGridHits.Rows.Add(data.ToArray());
                        }
                    }                
                }
                if (selectedHits == "Hits per Month")
                {
                    var items = from k in _items["General"].Colls
                                orderby k.Key ascending
                                select k;

                    Dictionary<DateTime, int> monthData = new Dictionary<DateTime, int>();
                    foreach (KeyValuePair<string, WebLog> item in items)
                    {
                        if (item.Value != null)
                        {
                            DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                            DateTime newDate = new DateTime(date.Year, date.Month, 1);

                            if (monthData.ContainsKey(newDate))
                                monthData[newDate] = monthData[newDate] + Convert.ToInt32(item.Value.Items[item.Key]);
                            else
                                monthData.Add(newDate, Convert.ToInt32(item.Value.Items[item.Key]));
                        }
                    }
                    var items2 = from k in monthData
                                 orderby k.Key ascending
                                 select k;
                    foreach (KeyValuePair<DateTime, int> item in items2)
                    {
                        List<object> data = new List<object>();
                        data.Add(item.Key.ToString("yyyy-MMM"));
                        data.Add(Convert.ToInt32(item.Value));

                        dataGridHits.Rows.Add(data.ToArray());
                    }
                }
            }
        }
    }
}
