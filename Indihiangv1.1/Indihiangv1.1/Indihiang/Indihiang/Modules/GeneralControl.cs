using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class GeneralControl : UserControl, BaseControl
    {
        List<string> _listFiles = new List<string>();

        public List<string> FileNames
        {
            get
            {
                return _listFiles;
            }
            set
            {
                if (_listFiles == value)
                    return;

                _listFiles = value;                
            }
        }
        public GeneralControl()
        {
            InitializeComponent();
        }

        #region BaseControl Members

        public Dictionary<string, Indihiang.Cores.Features.LogCollection> DataSource 
        { get; set; }

        public void Populate()
        {
            ShowData();
        }
        #endregion
        

        private void ShowData()
        {
            if (DataSource.Count > 0)
            {
                List<DateTime> list = new List<DateTime>();
                foreach (KeyValuePair<string, WebLog> item in DataSource["General"].Colls)
                {
                    if (!string.IsNullOrEmpty(item.Key) && item.Key != "-" )
                        list.Add(DateTime.ParseExact(item.Key, "yyyy-MM-dd", null));
                }
                if (list.Count > 0)
                {
                    DateTime startDate = list.Min();
                    DateTime endDate = list.Max();
                    lbTime.Text = String.Format("{0:dd-MMM-yyyy} - {1:dd-MMM-yyyy}", startDate, endDate);
                }
                else
                    lbTime.Text = "-";

                List<string> list2 = new List<string>();
                foreach (KeyValuePair<string, WebLog> item in DataSource["IPServer"].Colls)
                {
                    if (!string.IsNullOrEmpty(item.Key) && item.Key != "-")
                        list2.Add(item.Key);
                }

                if (DataSource["TotalData"].Colls.Count > 0)
                {
                    int total = Convert.ToInt32(DataSource["TotalData"].Colls["TotalData"].Items["TotalData"]);
                    lbTotalData.Text = String.Format("{0} rows data", total);
                }
                else
                    lbTotalData.Text = "No row data";
                
                listBoxFileName.Items.AddRange(_listFiles.ToArray());
                listBoxIPAddress.Items.AddRange(list2.ToArray());
                lbTotalFile.Text = String.Format("{0} files", _listFiles.Count);
            }
        }

    }
}
