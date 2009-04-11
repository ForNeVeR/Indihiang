using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            GraphPane pane = this.zedHits1.GraphPane;

            // Set the Titles
            pane.Title.Text = "Total Hist per Day User Agent Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Hits";
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));


            // Make up some data arrays based on the Sine function
            if (_items.Count > 0)
            {
                double x, y;
                PointPairList list1 = new PointPairList();
                PointPairList list2 = new PointPairList();

                foreach (KeyValuePair<string, WebLog> item in _items["General"].Colls)
                {
                    if (item.Value != null)
                    {
                        DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                        x = date.ToOADate();

                        y = Convert.ToDouble(item.Value.Items[item.Key]);                                              
                        list1.Add(x, y);
                    }
                }

                LineItem line = pane.AddCurve("Hits",list1, Color.Red, SymbolType.Diamond);
            }

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
    }
}
