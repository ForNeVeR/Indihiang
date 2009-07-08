using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Indihiang.Cores;
using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class RequestProcessingControl : UserControl, BaseControl
    {
        private Dictionary<string, LogCollection> _items;

        public RequestProcessingControl()
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
            get
            {
                return _items;
            }
        }

        public void Populate()
        {
            SetGridLayout();
            GenerateData();
        }

        #endregion

        private void SetGridLayout()
        {            
            dataGridViewRequest.ColumnCount = 3;
            dataGridViewRequest.Columns[0].Name = "Request Time";
            dataGridViewRequest.Columns[0].Width = 120;
            dataGridViewRequest.Columns[1].Name = "Page Request";
            dataGridViewRequest.Columns[1].Width = 200;
            dataGridViewRequest.Columns[2].Name = "Processing Duration";
            dataGridViewRequest.Columns[2].Width = 200;

            dataGridViewRequest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRequest.MultiSelect = false;
        }

        private void GenerateData()
        {
            var items = from k in _items["TimeTaken"].Colls
                        orderby k.Key ascending
                        select k;

            foreach (KeyValuePair<string, WebLog> item in items)
            {
                if (item.Value != null)
                {
                    foreach (KeyValuePair<string, string> ilog in item.Value.Items)
                    {
                        List<object> list = new List<object>();

                        list.Add(item.Key);
                        string[] tmp = ilog.Key.Split(new char[] { ';' });
                        if (tmp.Length > 0)
                            list.Add(tmp[0]);
                        else
                            list.Add("");
                        list.Add(IndihiangHelper.DurationFormat(Convert.ToInt64(ilog.Value)));                        

                        dataGridViewRequest.Rows.Add(list.ToArray());
                    }

                    
                }
            }

            dataGridViewRequest.Columns[0].DisplayIndex = 0;
            dataGridViewRequest.Columns[1].DisplayIndex = 1;
            dataGridViewRequest.Columns[2].DisplayIndex = 2;
        }


    }
}
