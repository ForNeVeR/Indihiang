using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

using Indihiang.Cores;
using Indihiang.DomainObject;
using Indihiang.Data;
using Indihiang.Cores.Features;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class AccessStatusControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private long _totalData;
        private List<DumpData> _listTopOf3 = new List<DumpData>();
        private List<DumpData> _listStatus = new List<DumpData>();        
        private List<string> _listYears = new List<string>();  

        public AccessStatusControl()
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

            SetGridLayout();            
            SetSize();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.STATUS, _fileName);
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
            dataGridHttpStatus.ColumnCount = 2;
            dataGridHttpStatus.Columns[0].Name = "HTTP Status";
            dataGridHttpStatus.Columns[0].Width = 200;
            dataGridHttpStatus.Columns[0].ValueType = typeof(System.String);
            dataGridHttpStatus.Columns[1].Name = "Total";
            dataGridHttpStatus.Columns[1].Width = 100;
            dataGridHttpStatus.Columns[0].ValueType = typeof(System.Int32);

            dataGridHttpStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHttpStatus.MultiSelect = false;

        }
        private void GenerateGraph()
        {
            GraphPane pane = this.zedPercentStatus1.GraphPane;
            pane.CurveList.Clear();

            pane.Title.Text = "The 3 Top of HTTP Status Graph";
            pane.Legend.Position = LegendPos.InsideTopRight;
            pane.Chart.Fill = new Fill(Color.White, Color.BurlyWood, Color.White, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listTopOf3.Count > 0)
            {
                Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green,Color.Purple };

                double total = _totalData;
                long itemTotal = 0;
                for (int i = 0; i < _listTopOf3.Count; i++)
                {
                    itemTotal = itemTotal + _listTopOf3[i].Total;
                    pane.AddPieSlice(_listTopOf3[i].Total,
                            colors[i],
                            Color.White, 45f, 0.2,
                            "HTTP Status: " + _listTopOf3[i].Protocol_Status + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf3[i].Total * 100 / total)) + " %)");
                }

                double remains = total - itemTotal;
                if (remains > 0)
                {
                    pane.AddPieSlice(remains,
                            colors[3],
                            Color.White, 45f, 0.2,
                            "Others (" +
                            string.Format("{0:0.##}", (double)(remains * 100 / total)) + " %)");
                } 
            }

            zedPercentStatus1.IsShowPointValues = true;
            zedPercentStatus1.AxisChange();
            SetSize();
        }
        private void GenerateGrid()
        {           
            dataGridHttpStatus.Rows.Clear();
            if (_listStatus.Count > 0)
            {
                for (int i = 0; i < _listStatus.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listStatus[i].Protocol_Status);
                    data.Add(_listStatus[i].Total);

                    dataGridHttpStatus.Rows.Add(data.ToArray());
                }
            }
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);              

                _listTopOf3 = new List<DumpData>(facade.GetHttpStatusAccessByYear(Convert.ToInt32(par), 3));
                _totalData = facade.GetTotalData(Convert.ToInt32(par));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            GenerateGraph();

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listStatus = new List<DumpData>(facade.GetHttpStatusAccessByYear(Convert.ToInt32(par), 0));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            GenerateGrid();

            btnGenerate2.Text = "Generate";
            btnGenerate2.Enabled = true;
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
            backgroundWorker1.RunWorkerAsync(cboParams1.SelectedItem);
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
            backgroundWorker2.RunWorkerAsync(cboParams2.SelectedItem);
        }

    }
}
