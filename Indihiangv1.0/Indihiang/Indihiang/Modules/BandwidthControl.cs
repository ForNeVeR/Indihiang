using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Indihiang.Modules
{
    public partial class BandwidthControl : UserControl, BaseControl
    {
        public BandwidthControl()
        {
            InitializeComponent();
        }

        #region BaseControl Members

        public Dictionary<string, Indihiang.Cores.Features.LogCollection> DataSource
        {
            set { throw new NotImplementedException(); }
        }

        public void Populate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
