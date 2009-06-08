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
        }

        public void Populate()
        {
            GenerateGraph();
            SetSize();
        }
        #endregion

        private void GenerateGraph()
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

                LineItem line = pane.AddCurve("Hits",list1, Color.Red, SymbolType.Diamond);
            }

            this.zedHits1.IsShowPointValues = true;
            this.zedHits1.AxisChange();

        }
        private void SetSize()
        {
            zedHits1.Location = new Point(10, 10);
            zedHits1.Size = new Size(ClientRectangle.Width - 20,ClientRectangle.Height - 20);
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
    }
}
