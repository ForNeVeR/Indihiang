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
    public partial class UserAgentControl : UserControl,BaseControl
    {
 
        private LogCollection<int> _items;

        public UserAgentControl()
        {
            InitializeComponent();
        }

        #region BaseControl Members



        public Indihiang.Cores.Features.LogCollection<int> Items
        {
            set { throw new NotImplementedException(); }
        }

        public void Populate()
        {
            GenerateGraph();
        }

        #endregion

        private void GenerateGraph()
        {
            GraphPane pane = this.zedUserAgent.GraphPane;

            // Set the Titles
            pane.Title.Text = "User Agent Graph";
            pane.XAxis.Title.Text = "Date";
            pane.YAxis.Title.Text = "Total Access";

            // Make up some data arrays based on the Sine function
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = pane.AddCurve("Porsche",
                  list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            LineItem myCurve2 = pane.AddCurve("Piper",
                  list2, Color.Blue, SymbolType.Circle);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            this.zedUserAgent.AxisChange();

        }

        private void UserAgentControl_Resize(object sender, EventArgs e)
        {

        }
    }
}
