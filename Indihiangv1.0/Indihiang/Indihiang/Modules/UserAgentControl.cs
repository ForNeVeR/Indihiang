using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class UserAgentControl : UserControl,BaseControl
    {
        private Dictionary<string, LogCollection> _items;

        public UserAgentControl()
        {
            InitializeComponent();
        }

        #region BaseControl Members
        public Dictionary<string, LogCollection> DataSource
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
            GenerateGraphUserAgent1();
            GenerateGraphUserAgent2();
            SetSize();
        }
        #endregion

        private void GenerateGraphUserAgent1()
        {
            GraphPane pane = this.zedUserAgent1.GraphPane;

            pane.Title.Text = "Total Hist per Day by User Agent Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Legend.Position = LegendPos.Bottom;
            pane.Chart.Fill = new Fill(Color.White,Color.SkyBlue, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_items.Count > 0)
            {
                double x;
                Dictionary<string, PointPairList> list = new Dictionary<string, PointPairList>();
                
                var items = from k in _items["General"].Colls
                            orderby k.Key ascending
                            select k;

                foreach (KeyValuePair<string, WebLog> item in items)               
                //foreach (KeyValuePair<string, WebLog> item in _items["General"].Colls)
                {
                    if (item.Value != null)
                    {
                        DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                        x = date.ToOADate();

                        foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                        {
                            if (list.ContainsKey(ilog.Key))
                                list[ilog.Key].Add(x, Convert.ToDouble(ilog.Value));
                            else
                            {
                                PointPairList tmp = new PointPairList();
                                tmp.Add(x,Convert.ToDouble(ilog.Value));
                                list.Add(ilog.Key, tmp);
                            }
                        }                       
                    }
                }
                foreach (KeyValuePair<string, PointPairList> item in list)
                {
                    if(item.Key=="MS Internet Explorer")
                        pane.AddCurve(item.Key, item.Value, Color.Blue, SymbolType.Diamond);
                    if (item.Key == "Firefox")
                        pane.AddCurve(item.Key, item.Value, Color.Red, SymbolType.Diamond);
                    if (item.Key == "Safari")
                        pane.AddCurve(item.Key, item.Value, Color.Green, SymbolType.Diamond);
                    if (item.Key == "Google Chrome")
                        pane.AddCurve(item.Key, item.Value, Color.Cyan, SymbolType.Diamond);
                    if (item.Key == "Mozilla")
                        pane.AddCurve(item.Key, item.Value, Color.Yellow, SymbolType.Diamond);
                    if (item.Key == "Opera")
                        pane.AddCurve(item.Key, item.Value, Color.Purple, SymbolType.Diamond);
                    if (item.Key == "Netscape")
                        pane.AddCurve(item.Key, item.Value, Color.Brown, SymbolType.Diamond);
                    if (item.Key == "Unknown")
                        pane.AddCurve(item.Key, item.Value, Color.Black, SymbolType.Diamond);
                }
             
            }

            this.zedUserAgent1.IsShowPointValues = true;
            this.zedUserAgent1.AxisChange();
        }
        private void GenerateGraphUserAgent2()
        {
            GraphPane pane = this.zedUserAgent2.GraphPane;

            pane.Title.Text = "User Agent Percent Graph";            
            pane.Legend.Position = LegendPos.InsideTopRight;
            pane.Chart.Fill = new Fill(Color.White, Color.SkyBlue, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_items.Count > 0)
            {
                Dictionary<string, int> list = new Dictionary<string, int>();
                double total = 0.0;
                foreach (KeyValuePair<string, WebLog> item in _items["General"].Colls)
                {
                    if (item.Value != null)
                    {
                        foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                        {
                            if (list.ContainsKey(ilog.Key))
                            {
                                list[ilog.Key] = list[ilog.Key] + Convert.ToInt32(ilog.Value);
                            }
                            else
                                list.Add(ilog.Key, Convert.ToInt32(ilog.Value));

                            total = total + Convert.ToInt32(ilog.Value);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> item in list)
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
                    if (item.Key == "Mozilla")
                        pane.AddPieSlice(item.Value, 
                            Color.Yellow,
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
                    if (item.Key == "Unknown")
                        pane.AddPieSlice(item.Value, Color.Black, 
                            Color.White, 45f, 0.2, item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");
                }

            }

            this.zedUserAgent2.AxisChange();
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

            return String.Format("[{0:yyyy-MMM-dd} --> {1:f2} Hit(s)]", date, pt.Y);

        }
    }
}
