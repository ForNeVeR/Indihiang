using System;
using System.Windows.Forms;

namespace Indihiang.Forms
{
    public partial class ConsolidateForm : Form
    {
        public string ConsolidationName
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text;
            }
        }

        public ConsolidateForm()
        {
            InitializeComponent();
        }
    }
}
