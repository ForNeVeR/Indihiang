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
    public partial class AccessPageControl : UserControl, BaseControl
    {
        private SynchronizationContext _synContext;
        private string _guid;
        private string _fileName;
        private List<string> _listYears = new List<string>();
        private List<string> _listYearMonth = new List<string>();
        private List<DumpData> _listTopOf5 = new List<DumpData>();
        private List<DumpData> _listAccessPage = new List<DumpData>();
        private long _totalAccessYear;

        public AccessPageControl()
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
            backgroundJob.RunWorkerAsync();            
        }
        #endregion
        protected virtual void OnRenderHandler(RenderInfoEventArgs e)
        {
            if (RenderHandler != null)
                RenderHandler(this, e);
        }

        private void SetIntialLayout()
        {
            dataGridAccess.ColumnCount = 3;
            dataGridAccess.Columns[0].Name = "Page Name";
            dataGridAccess.Columns[0].Width = 450;
            dataGridAccess.Columns[0].ValueType = typeof(System.String);
            dataGridAccess.Columns[1].Name = "Day";
            dataGridAccess.Columns[1].Width = 80;
            dataGridAccess.Columns[1].ValueType = typeof(System.Int32);
            dataGridAccess.Columns[2].Name = "Total Access";
            dataGridAccess.Columns[2].Width = 100;
            dataGridAccess.Columns[2].ValueType = typeof(System.Int32);

            dataGridAccess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAccess.MultiSelect = false;
        }
        private void GenerateGraph()
        {
            GraphPane pane = zedAccessPage1.GraphPane;
            pane.Title.Text = "The 5 Top of Total Access Page Graph";
            pane.CurveList.Clear();
            
            pane.Legend.Position = LegendPos.InsideTopLeft;
            pane.Chart.Fill = new Fill(Color.White, Color.Orange, 90F);
            pane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            if (_listTopOf5.Count > 0)
            {
                double total = _totalAccessYear;
                double itemTotal = 0;
                for (int i = 0; i < _listTopOf5.Count;i++ )
                {
                    itemTotal = itemTotal + _listTopOf5[i].Total;
                    switch(i)
                    {
                        case 0:
                            pane.AddPieSlice(_listTopOf5[i].Total,
                            Color.Blue,
                            Color.White, 45f, 0.2,
                            _listTopOf5[i].Page_Access + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");
                            break;
                        case 1:
                            pane.AddPieSlice(_listTopOf5[i].Total,
                            Color.Red,
                            Color.White, 45f, 0.2,
                            _listTopOf5[i].Page_Access + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");
                            break;
                        case 2:
                            pane.AddPieSlice(_listTopOf5[i].Total,
                            Color.Green,
                            Color.White, 45f, 0.2,
                            _listTopOf5[i].Page_Access + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");
                            break;
                        case 3: 
                            pane.AddPieSlice(_listTopOf5[i].Total,
                            Color.Cyan,
                            Color.White, 45f, 0.2,
                            _listTopOf5[i].Page_Access + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");
                            break;
                        case 4:
                            pane.AddPieSlice(_listTopOf5[i].Total,
                            Color.Purple,
                            Color.White, 45f, 0.2,
                            _listTopOf5[i].Page_Access + " (" +
                            string.Format("{0:0.##}", (double)(_listTopOf5[i].Total * 100 / total)) + " %)");                            
                            break;

                    }
                    
                }
                double remains = total - itemTotal;
                if (remains > 0)
                {
                    pane.AddPieSlice(remains,
                            Color.Purple,
                            Color.White, 45f, 0.2,
                            "Others (" +
                            string.Format("{0:0.##}", (double)(remains * 100 / total)) + " %)");
                }

            }

            zedAccessPage1.IsShowPointValues = true;
            zedAccessPage1.AxisChange();

        }
        private void GenerateGrid()
        {
            dataGridAccess.Rows.Clear();
            if (_listAccessPage.Count > 0)
            {
                for (int i = 0; i < _listAccessPage.Count; i++)
                {
                    List<object> data = new List<object>();
                    data.Add(_listAccessPage[i].Page_Access);
                    data.Add(_listAccessPage[i].Day);
                    data.Add(_listAccessPage[i].Total);

                    dataGridAccess.Rows.Add(data.ToArray());
                }
            }
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

        private void backgroundJob_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                LogDataFacade facade = new LogDataFacade(_guid);                                

                for (int i = 0; i < _listYears.Count; i++)
                {
                    List<string> list = facade.GetMonthLogFileListByYear(_listYears[i]);
                    for (int j = 0; j < list.Count; j++)
                    {
                        string monthYear = string.Format("{0}-{1}", IndihiangHelper.GetMonth(Convert.ToInt32(list[j])), _listYears[i]);
                        _listYearMonth.Add(monthYear);
                    }
                }
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJob_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboParams1.Items.AddRange(_listYears.ToArray());
            cboParams2.Items.AddRange(_listYearMonth.ToArray());

            SetIntialLayout();
            SetSize();

            RenderInfoEventArgs info = new RenderInfoEventArgs(_guid, LogFeature.ACCESS, _fileName);
            _synContext.Post(OnRenderHandler, info);
        }

        private void backgroundJobGraph_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                LogDataFacade facade = new LogDataFacade(_guid);

                _listTopOf5 = new List<DumpData>(facade.GetTop5OfAccessPageByYear(Convert.ToInt32(par)));
                _totalAccessYear = facade.GetTotalData(Convert.ToInt32(par));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJobGraph_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GenerateGraph();
            SetSize();

            btnGenerate1.Text = "Generate";
            btnGenerate1.Enabled = true;
        }

        private void backgroundJobGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string par = e.Argument.ToString();
                string[] items = par.Split(new char[] { '-' });
                int month = IndihiangHelper.GetMonth(items[0]);
                int year = Convert.ToInt32(items[1]); 

                LogDataFacade facade = new LogDataFacade(_guid);
                _listAccessPage = new List<DumpData>(facade.GetAccessPageByYearMonth(year,month));
            }
            catch (Exception err)
            {
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

                System.Diagnostics.Debug.WriteLine(err.Message);
            }
        }

        private void backgroundJobGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            backgroundJobGraph.RunWorkerAsync(cboParams1.SelectedItem);
        }

        private void btnGenerate2_Click(object sender, EventArgs e)
        {
            if (cboParams2.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose time", "Information");
                return;
            }
            btnGenerate2.Text = "Generating...";
            btnGenerate2.Enabled = false;
            backgroundJobGrid.RunWorkerAsync(cboParams2.SelectedItem);
        }


    }
}
