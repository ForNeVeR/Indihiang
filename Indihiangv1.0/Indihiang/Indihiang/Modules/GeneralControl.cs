using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class GeneralControl : UserControl, BaseControl
    {
        List<string> _listFiles = new List<string>();
        private Dictionary<string, LogCollection> _items;

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
        {
            set
            {
                _items = value;
            }
        }

        public void Populate()
        {
            ShowData();
        }
        #endregion

        private void ShowData()
        {
            if (_items.Count > 0)
            {
                List<DateTime> list = new List<DateTime>();
                foreach (KeyValuePair<string, WebLog> item in _items["General"].Colls)
                {
                    if (item.Key != "" && item.Key != "-" && item.Key!=null)
                        list.Add(DateTime.ParseExact(item.Key, "yyyy-MM-dd", null));
                }
                DateTime startDate = list.Min();
                DateTime endDate = list.Max();

                List<string> list2 = new List<string>();
                foreach (KeyValuePair<string, WebLog> item in _items["IPServer"].Colls)
                {
                    if (item.Key != "" && item.Key != "-" && item.Key != null)
                        list2.Add(item.Key);
                }

                lbTime.Text = startDate.ToString("dd-MMM-yyyy") + " - " + endDate.ToString("dd-MMM-yyyy");
                listBoxFileName.Items.AddRange(_listFiles.ToArray());
                listBoxIPAddress.Items.AddRange(list2.ToArray());
                
            }
        }

    }
}
