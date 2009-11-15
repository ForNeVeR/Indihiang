using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Indihiang.Cores;
using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class AccessStatusControl : UserControl, BaseControl
    {
        private string _guid;
        private string _fileName;
        private Dictionary<string, LogCollection> _items;

        public AccessStatusControl()
        {
            InitializeComponent();
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
        public void Populate()
        {
            SetGridLayout();
            GenerateGraph();
            SetSize();
        }

        #endregion
        private void SetGridLayout()
        {
            dataGridHttpStatus.ColumnCount = 2;
            dataGridHttpStatus.Columns[0].Name = "HTTP Status";
            dataGridHttpStatus.Columns[0].Width = 200;
            dataGridHttpStatus.Columns[1].Name = "Total";
            dataGridHttpStatus.Columns[1].Width = 100;

            dataGridHttpStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHttpStatus.MultiSelect = false;

        }
        private void GenerateGraph()
        {
            GraphPane pane = this.zedPercentStatus1.GraphPane;

            pane.Title.Text = "The 3 Top of HTTP Status Graph";
            pane.Legend.Position = LegendPos.InsideTopRight;
            pane.Chart.Fill = new Fill(Color.White, Color.BurlyWood, Color.White);
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
                list = CollectionHelper.SortList(list);
                int iTotal = 0;
                double another = 0d;
                Color[] colors = new Color[] {Color.Blue,Color.Red,Color.Green,Color.Gainsboro};
                foreach (KeyValuePair<string, int> item in list)
                {
                    if (iTotal < 3)
                    {
                        pane.AddPieSlice(item.Value,
                            colors[iTotal],
                            Color.White, 45f, 0,
                            "HTTP " + item.Key + " (" +
                            string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");

                    }
                    else
                    {
                        another = another + (double)item.Value;
                    }
                    iTotal++;

                    List<object> data = new List<object>();
                    data.Add(item.Key);
                    data.Add(item.Value);
                    dataGridHttpStatus.Rows.Add(data.ToArray());
                }

                pane.AddPieSlice(another,
                            colors[3],
                            Color.White, 45f, 0.2, "Others (" +
                            string.Format("{0:0.##}", (double)(another * 100 / total)) + " %)");

            }

            dataGridHttpStatus.Columns[0].DisplayIndex = 0;
            dataGridHttpStatus.Columns[1].DisplayIndex = 1;
            dataGridHttpStatus.Columns[1].ValueType = typeof(System.Int32);

            zedPercentStatus1.AxisChange();
        }
        private void SetSize()
        {
            zedPercentStatus1.Location = new Point(10, 10);
            zedPercentStatus1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }
        private void AccessStatusControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

    }
}
