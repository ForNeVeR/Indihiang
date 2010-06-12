using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Data;
using Indihiang.DomainObject;
using Indihiang.Cores;
using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class IPAddressControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;        
        private List<string> _listYears = new List<string>();        
        private List<DumpData> _listTopOf5 = new List<DumpData>();
        private List<DumpData> _listIPAddressYear = new List<DumpData>();
        private List<DumpData> _listIPAddressAccessYear = new List<DumpData>();
        private long _totalData;

        public IPAddressControl()
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
            cboParams1.Items.AddRange(_listYears.ToArray());
            cboParams2.Items.AddRange(_listYears.ToArray());
            cboParams3.Items.AddRange(_listYears.ToArray());

            SetGridLayout();
            SetSize();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.IPADDRESS, _fileName);
            _synContext.Post(OnRenderHandler, info);
        }
        #endregion

        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void SetGridLayout()
        {
            dataGridIP.ColumnCount = 3;
            dataGridIP.Columns[0].Name = "IP Address";
            dataGridIP.Columns[0].Width = 200;
            dataGridIP.Columns[0].ValueType = typeof(String);
            dataGridIP.Columns[1].Name = "Country";
            dataGridIP.Columns[1].Width = 200;
            dataGridIP.Columns[1].ValueType = typeof(String);
            dataGridIP.Columns[2].Name = "Total Access";
            dataGridIP.Columns[2].Width = 100;
            dataGridIP.Columns[2].ValueType = typeof(Int32);

            dataGridIP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridIP.MultiSelect = false;

            dataGridIPPage.ColumnCount = 2;
            dataGridIPPage.Columns[0].Name = "Page Name";
            dataGridIPPage.Columns[0].Width = 450;
            dataGridIPPage.Columns[0].ValueType = typeof(String);
            dataGridIPPage.Columns[1].Name = "Total Access";
            dataGridIPPage.Columns[1].Width = 100;
            dataGridIPPage.Columns[1].ValueType = typeof(Int32);

            dataGridIPPage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridIPPage.MultiSelect = false;

        }
        private void GenerateGraph()
        {
            GraphPane pane = zedIPAccess1.GraphPane;
            pane.CurveList.Clear();

            pane.Title.Text = "The 5 Top of IP Access Access Page Graph";
            pane.Legend.Position = LegendPos.InsideTopLeft;

            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 209, 164), Color.White, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listTopOf5.Count > 0)
            {                
                Color[] colors = new Color[] { Color.Red, Color.PowderBlue, Color.SeaGreen, Color.Orange, Color.Yellow, Color.Magenta, Color.Gainsboro };

                double total = _totalData;
                long itemTotal = 0;
                for (int i = 0; i < _listTopOf5.Count; i++)
                {
                    itemTotal = itemTotal + _listTopOf5[i].Total;
                    pane.AddPieSlice(_listTopOf5[i].Total,
                            colors[i],
                            Color.White, 45f, 0.2,
                            "IP: " + _listTopOf5[i].Client_IP + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");
                }

                double remains = total - itemTotal;
                if (remains > 0)
                {
                    pane.AddPieSlice(remains,
                            colors[5],
                            Color.White, 45f, 0.2,
                            "Others (" +
                            string.Format("{0:0.##}", (double)(remains * 100 / total)) + " %)");
                }                
            }            

            zedIPAccess1.IsShowPointValues = true;
            zedIPAccess1.AxisChange();
        }

        private void GenerateGrid1()
        {
            dataGridIP.Rows.Clear();
            if (_listIPAddressYear.Count > 0)
            {
                for (int i = 0; i < _listIPAddressYear.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listIPAddressYear[i].Client_IP);
                    data.Add(_listIPAddressYear[i].IPClientCountry);
                    data.Add(_listIPAddressYear[i].Total);

                    dataGridIP.Rows.Add(data.ToArray());
                }
            }
        }

        private void GenerateGrid2()
        {
            dataGridIPPage.Rows.Clear();
            if (_listIPAddressAccessYear.Count > 0)
            {
                for (int i = 0; i < _listIPAddressAccessYear.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listIPAddressAccessYear[i].Page_Access);
                    data.Add(_listIPAddressAccessYear[i].Total);

                    dataGridIPPage.Rows.Add(data.ToArray());
                }
            }
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

        private void backgroundGraph_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listTopOf5 = new List<DumpData>(facade.GetIPaddressAccessByYear(Convert.ToInt32(par), 5));
                _totalData = facade.GetTotalData(Convert.ToInt32(par));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundGraph_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GenerateGraph();
            SetSize();

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundGrid1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listIPAddressYear = new List<DumpData>(facade.GetIPaddressAccessByYear(Convert.ToInt32(par), 0));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundGrid1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GenerateGrid1();

            btnGenerate2.Text = "Generate";
            btnGenerate2.Enabled = true;
        }

        private void backgroundGrid2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                string[] items = par.Split(new char[] { ';' });
                int year = Convert.ToInt32(items[0]);
                string ipAddress = items[1];

                LogDataFacade facade = new LogDataFacade(_guid);
                _listIPAddressAccessYear = new List<DumpData>(facade.GetIPaddressAccessByYear(year, ipAddress));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundGrid2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GenerateGrid2();

            btnGenerate3.Text = "Generate";
            btnGenerate3.Enabled = true;
        }

        private void cboParams3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogDataFacade facade = new LogDataFacade(_guid);
            List<string> list = new List<string>(facade.GetListIPaddressByYear(Convert.ToInt32(cboParams3.SelectedItem)));

            cmbIPAddress.Items.AddRange(list.ToArray());
        }

        private void btnGenerate1_Click(object sender, EventArgs e)
        {
            if (cboParams1.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate1.Text = "Generating...";
            btnGenerate1.Enabled = false;
            backgroundGraph.RunWorkerAsync(cboParams1.SelectedItem);
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            if (cboParams2.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            btnGenerate2.Text = "Generating...";
            btnGenerate2.Enabled = false;
            backgroundGrid1.RunWorkerAsync(cboParams2.SelectedItem);
        }

        private void btnGenerate3_Click(object sender, EventArgs e)
        {
            if (cboParams3.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose year", "Information");
                return;
            }
            if (cmbIPAddress.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose IP Address", "Information");
                return;
            }
            btnGenerate3.Text = "Generating...";
            btnGenerate3.Enabled = false;
            backgroundGrid2.RunWorkerAsync(string.Format("{0};{1}", cboParams3.SelectedItem, cmbIPAddress.SelectedItem));
        }

    }
}
