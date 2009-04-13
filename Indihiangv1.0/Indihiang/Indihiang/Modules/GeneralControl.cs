using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public partial class GeneralControl : UserControl, BaseControl
    {
        private Dictionary<string, LogCollection> _items;

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
        }

    }
}
