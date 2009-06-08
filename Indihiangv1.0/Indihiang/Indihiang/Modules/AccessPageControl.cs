using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class AccessPageControl : UserControl, BaseControl
    {
        private Dictionary<string, LogCollection> _items;

        public AccessPageControl()
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
            SetSize();
        }
        #endregion
        private void SetGridLayout()
        {
            dataGridAccess.ColumnCount = 2;
            dataGridAccess.Columns[0].Name = "Page Name";
            dataGridAccess.Columns[0].Width = 450;
            dataGridAccess.Columns[1].Name = "Total Access";
            dataGridAccess.Columns[1].Width = 100;            

            dataGridAccess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAccess.MultiSelect = false;
            
        }
        private void GenerateGraph()
        {
            GraphPane pane = zedAccessPage1.GraphPane;

            pane.Title.Text = "The 5 Top of Total Access Page Graph";
            pane.XAxis.Title.Text = "Date";
            pane.XAxis.Scale.Format = "yyyy-MMM-dd";
            pane.YAxis.Title.Text = "Total Hits";
            pane.BarSettings.Type = BarType.Stack;

            if (_items.Count > 0)
            {
                List<double> listX = new List<double>();
                List<string> labels = new List<string>();
                Dictionary<string, List<double>> listBar = new Dictionary<string, List<double>>();

                var items = from k in _items["General"].Colls
                            orderby k.Key ascending
                            select k;

                foreach (KeyValuePair<string, WebLog> item in items)
                {
                    if (item.Value != null)
                    {
                        DateTime date = DateTime.ParseExact(item.Key, "yyyy-MM-dd", null);
                        listX.Add(date.ToOADate());

                        if (!labels.Contains(item.Key))
                            labels.Add(date.ToString("yyyy-MMM-dd"));

                        foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                        {
                            if (listBar.ContainsKey(ilog.Key))
                                listBar[ilog.Key].Add(Convert.ToDouble(ilog.Value));
                            else
                            {
                                List<double> data = new List<double>();
                                data.Add(Convert.ToDouble(ilog.Value));

                                listBar.Add(ilog.Key, data);
                            }
                        }
                    }
                }
                
                if (listBar.Count > 0)
                {
                    int total = 0;
                    bool draw = true;
                    List<Color> listColor = new List<Color>();
                    Random random = new Random();

                    Dictionary<string, List<double>> newList = UserControlUtil.SortList(listBar);
                    foreach (KeyValuePair<string, List<double>> item in newList)
                    {
                        if (draw)
                        {
                            Color color = Color.FromArgb(0, 0, 0);
                            do
                            {
                                color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

                            } while (listColor.Contains(color));
                            listColor.Add(color);

                            BarItem bar = pane.AddBar(item.Key, listX.ToArray(), item.Value.ToArray(), color);
                            bar.Bar.Fill = new Fill(color, Color.White, color);
                            total++;
                            if (total > 4)
                                draw = false;
                        }

                        List<object> data = new List<object>();
                        data.Add(item.Key);
                        data.Add((int)item.Value.Sum());
                        this.dataGridAccess.Rows.Add(data.ToArray());
                        
                    }
                }

                pane.XAxis.Type = AxisType.Date; 
                pane.Chart.Fill = new Fill(Color.White,Color.FromArgb(255, 255, 166), 90F);
                pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            }

            dataGridAccess.Columns[0].DisplayIndex = 0;
            dataGridAccess.Columns[1].DisplayIndex = 1;
            dataGridAccess.Columns[1].ValueType = typeof(System.Int32);

            zedAccessPage1.IsShowPointValues = true;
            zedAccessPage1.AxisChange();

        }

        private void SetSize()
        {
            zedAccessPage1.Location = new Point(10, 10);
            zedAccessPage1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }        

        private void AccessPageControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        
    }
}
