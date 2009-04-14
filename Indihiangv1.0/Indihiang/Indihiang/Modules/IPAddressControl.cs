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

    }
}
