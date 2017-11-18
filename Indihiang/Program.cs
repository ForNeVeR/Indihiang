using System;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += Application_ThreadException;

            //args = new string[] { @"C:\Users\Agus Kurniawan\Documents\PECollege\indihiang\Sample Log\ex081221.log" };           
			if (args.Length >= 1)
				Application.Run(new LightIndihiangForm(args[0]));
			else
			{
				Application.Run(new MainForm());

				Indihiang.Properties.Settings.Default.Save();
			}
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
