using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Indihiang.Forms;
namespace Indihiang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
