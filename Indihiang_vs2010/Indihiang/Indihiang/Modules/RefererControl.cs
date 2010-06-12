using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Indihiang.Data;
using Indihiang.Cores.Features;
using Indihiang.Cores;
using Indihiang.DomainObject;
using ZedGraph;
namespace Indihiang.Modules
{
    public partial class RefererControl : UserControl,BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private List<string> _listYears = new List<string>();
        private List<DumpData> _listReferer1 = new List<DumpData>();
        private List<DumpData> _listReferer2 = new List<DumpData>();

        public RefererControl()
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

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.REFERER, _fileName);
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
            dataGridViewReferer.ColumnCount = 2;
            dataGridViewReferer.Columns[0].Name = "Referer";
            dataGridViewReferer.Columns[0].Width = 200;
            dataGridViewReferer.Columns[0].ValueType = typeof(String);
            dataGridViewReferer.Columns[1].Name = "Total";
            dataGridViewReferer.Columns[1].Width = 100;
            dataGridViewReferer.Columns[0].ValueType = typeof(Int32);

            dataGridViewReferer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReferer.MultiSelect = false;

        }
        private void SetSize()
        {
            zedReferer.Location = new Point(10, 10);
            zedReferer.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void GenerateGraph()
        {
            GraphPane pane = this.zedReferer.GraphPane;
            pane.CurveList.Clear();

            pane.Title.Text = "The Referer Data Graph";
            pane.Legend.Position = LegendPos.InsideTopRight;
            pane.Chart.Fill = new Fill(Color.White, Color.BurlyWood, Color.White, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listReferer1.Count > 0)
            {
                Color[] colors = new Color[] { Color.Orange, Color.Blue, Color.Green, Color.Gray };

                double totalData = 0;
                long class1=0, class2=0, class3=0, class4 =0;
                for (int i = 0; i < _listReferer1.Count; i++)
                {
                    totalData = totalData + _listReferer1[i].Total;
                    if (_listReferer1[i].RefererClass.Trim() == "Direct Traffic")
                        class1 = class1 + _listReferer1[i].Total;
                    else
                        if (_listReferer1[i].RefererClass.Trim() == "Search Engines")
                        class2 = class2 + _listReferer1[i].Total;
                    else
                            if (_listReferer1[i].RefererClass.Trim() == "Referring Sites")
                        class3 = class3 + _listReferer1[i].Total;
                    else
                        class4 = class4 + _listReferer1[i].Total;
                }

                pane.AddPieSlice(class1,
                            colors[0],
                            Color.White, 45f, 0.2,
                            "Direct Traffic (" +
                            string.Format("{0:0.##}", (double)(class1 * 100 / totalData)) + " %)");
                pane.AddPieSlice(class2,
                            colors[1],
                            Color.White, 45f, 0.2,
                            "Search Engines (" +
                            string.Format("{0:0.##}", (double)(class2 * 100 / totalData)) + " %)");
                pane.AddPieSlice(class3,
                            colors[2],
                            Color.White, 45f, 0.2,
                            "Referring Sites (" +
                            string.Format("{0:0.##}", (double)(class3 * 100 / totalData)) + " %)");
                pane.AddPieSlice(class4,
                            colors[3],
                            Color.White, 45f, 0.2,
                            "Unknown/No Data (" +
                            string.Format("{0:0.##}", (double)(class4 * 100 / totalData)) + " %)");
               
            }

            zedReferer.IsShowPointValues = true;
            zedReferer.AxisChange();
            SetSize();
        }

        private void GenerateGridData()
        {
            dataGridViewReferer.Rows.Clear();
            if (_listReferer2.Count > 0)
            {
                for (int i = 0; i < _listReferer2.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listReferer2[i].Referer);
                    data.Add(_listReferer2[i].Total);

                    dataGridViewReferer.Rows.Add(data.ToArray());
                }
            }
            _listReferer2.Clear();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listReferer1 = new List<DumpData>(facade.GetRefererByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listReferer1!=null)
                GenerateGraph();    

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listReferer2 = new List<DumpData>(facade.GetRefererByYear(Convert.ToInt32(par)));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_listReferer2 != null)
                GenerateGridData();

            btnGenerate2.Text = "Generate";
            btnGenerate2.Enabled = true;
        }



    }
}
