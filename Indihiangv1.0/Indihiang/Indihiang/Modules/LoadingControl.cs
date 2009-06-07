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
    public partial class LoadingControl : UserControl
    {
        private int _proggress = 0;
        public LoadingControl()
        {
            InitializeComponent();
        }

        public void Start()
        {
            _proggress = 0;
            timer1.Start();
        }
        public void Stop()
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _proggress++;
            if (_proggress > 100)
                _proggress = 0;
            progressBar1.Value = _proggress;
        }
    }
}
