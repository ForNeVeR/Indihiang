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
        string _fileName;
        private Dictionary<string, LogCollection> _items;

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (_fileName == value)
                    return;
                _fileName = value;
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
                    list.Add(DateTime.ParseExact(item.Key, "yyyy-MM-dd", null));
                }
                DateTime startDate = list.Min();
                DateTime endDate = list.Max();

                lbTime.Text = startDate.ToString("dd-MMM-yyyy") + " - " + endDate.ToString("dd-MMM-yyyy");
                lbFileName.Text = Path.GetFileName(_fileName);
                lbDirectory.Text = Path.GetDirectoryName(_fileName);
            }
        }

    }
}
