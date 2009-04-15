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
    public partial class IPAddressControl : UserControl, BaseControl
    {
        private Dictionary<string, LogCollection> _items;
        public IPAddressControl()
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
            this.dataGridIP.ColumnCount = 2;
            this.dataGridIP.Columns[0].Name = "IP Address";
            this.dataGridIP.Columns[0].Width = 300;
            this.dataGridIP.Columns[1].Name = "Total Access";
            this.dataGridIP.Columns[1].Width = 100;

            this.dataGridIP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIP.MultiSelect = false;

            this.dataGridIPPage.ColumnCount = 2;
            this.dataGridIPPage.Columns[0].Name = "Page Name";
            this.dataGridIPPage.Columns[0].Width = 450;
            this.dataGridIPPage.Columns[1].Name = "Total Access";
            this.dataGridIPPage.Columns[1].Width = 100;

            this.dataGridIPPage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIPPage.MultiSelect = false;

        }
        private void GenerateGraph()
        {
            GraphPane pane = this.zedIPAccess1.GraphPane;

            pane.Title.Text = "The 3 Top of IP Access Access Page Graph";
            pane.Legend.Position = LegendPos.InsideTopLeft;

            if (_items.Count > 0)
            {
                double total = 0d;
                List<string> labels = new List<string>();
                Dictionary<string, int> listBar = new Dictionary<string, int>();
                List<string> listIP = new List<string>();

                foreach (KeyValuePair<string, WebLog> item in _items["General"].Colls)
                {
                    if (item.Value != null)
                    {
                        if (!labels.Contains(item.Key))
                            labels.Add(item.Key);

                        listBar.Add(item.Key, Convert.ToInt32(item.Value.Items[item.Key]));
                        listIP.Add(item.Key);
                        total = total + Convert.ToInt32(item.Value.Items[item.Key]);
                    }
                }

                if (listBar.Count > 0)
                {
                    List<Color> listColor = new List<Color>();
                    Random random = new Random();

                    int iTotal = 0;
                    double another = 0d;
                    Color[] colors = new Color[] { Color.Red, Color.PowderBlue, Color.SeaGreen, Color.Gainsboro };

                    Dictionary<string, int> newList = UserControlUtil.SortList(listBar);
                    foreach (KeyValuePair<string, int> item in newList)
                    {                                               
                        if (iTotal < 3)
                        {
                            pane.AddPieSlice(item.Value,
                                colors[iTotal],
                                Color.White, 45f, 0,
                                "IP: " + item.Key + " (" +
                                string.Format("{0:0.##}", (double)(item.Value * 100 / total)) + " %)");

                        }
                        else
                        {
                            another = another + (double)item.Value;
                        }
                        iTotal++;

                        List<object> data = new List<object>();
                        data.Add(item.Key);
                        data.Add((int)item.Value);
                        this.dataGridIP.Rows.Add(data.ToArray());

                    }

                    pane.AddPieSlice(another,
                            colors[3],
                            Color.White, 45f, 0.2, "Others (" +
                            string.Format("{0:0.##}", (double)(another * 100 / total)) + " %)");
                }
                
                pane.Chart.Fill = new Fill(Color.White, Color.Honeydew, 40F);
                pane.Fill = new Fill(Color.FromArgb(250, 250, 255));


                this.cmbIPAddress.DataSource = listIP;
                if (listIP.Count > 0)
                    this.cmbIPAddress.SelectedIndex = 0;
            }

            this.dataGridIP.Columns[0].DisplayIndex = 0;
            this.dataGridIP.Columns[1].DisplayIndex = 1;
            this.dataGridIP.Columns[1].ValueType = typeof(System.Int32);

            this.zedIPAccess1.IsShowPointValues = true;
            this.zedIPAccess1.AxisChange();

           
        }

        private void SetSize()
        {
            zedIPAccess1.Location = new Point(10, 10);
            zedIPAccess1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void IPAddressControl_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void cmbIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedIP = cmbIPAddress.SelectedValue.ToString();
            if (_items["IPPage"].Colls.ContainsKey(selectedIP))
            {

                this.dataGridIPPage.Rows.Clear();
                foreach (KeyValuePair<string, string> item in _items["IPPage"].Colls[selectedIP].Items)
                {
                    List<object> data = new List<object>();
                    data.Add(item.Key);
                    data.Add(Convert.ToInt32(item.Value));
                    this.dataGridIPPage.Rows.Add(data.ToArray());
                }

                this.dataGridIPPage.Columns[0].DisplayIndex = 0;
                this.dataGridIPPage.Columns[1].DisplayIndex = 1;
                this.dataGridIPPage.Columns[1].ValueType = typeof(System.Int32);

            }
        }

    }
}
