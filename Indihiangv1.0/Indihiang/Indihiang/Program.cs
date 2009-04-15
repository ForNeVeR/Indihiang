﻿using System;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            

            //args = new string[] { "c:\\Data_sample_2008.log" };           
            if (args.Length >= 1)
                Application.Run(new LightIndihiangForm(args[0]));
            else
                Application.Run(new MainForm());

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
