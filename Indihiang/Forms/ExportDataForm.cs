using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Indihiang.Data;
namespace Indihiang.Forms
{
    public partial class ExportDataForm : Form
    {
        private int _proggress = 0;
        private List<string> _logFiles;
        private DataExportDestination _target;
        private string _svr;
        private string _db;
        private string _uid;
        private string _pwd;

        public List<string> LogFiles
        {
            get
            {
                return _logFiles;
            }
            set
            {
                if (_logFiles == value)
                    return;
                _logFiles = value;
            }
        }        
        public string DatabasePassword
        {
            get
            {
                return txtPassword.Text;
            }
        }
        public ExportDataForm()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Format("server={0};uid={1};pwd={2}", 
                    txtDatabaseServer.Text,                     
                    txtUserName.Text, 
                    txtPassword.Text);
                SqlConnection con = new SqlConnection(str);
                con.Open();
                MessageBox.Show("Database can be contacted", "Database Test");
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            btnTest.Enabled = false;
            btnCancel.Enabled = false;

            _svr = txtDatabaseServer.Text;
            _db = txtDbName.Text;
            _uid = txtUserName.Text;
            _pwd = txtPassword.Text;

            if (cboDbServer.SelectedItem.ToString() == "SQL Server")
                _target = DataExportDestination.SQLServer;

            _proggress = 0;
            timer1.Start();
            backgroundWorker1.RunWorkerAsync(_logFiles);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<string> list = (List<string>)e.Argument;

                bool success = true;
                IndihiangDataExport export = IndihiangDataExport.Create(_target);
                for (int i = 0; i < list.Count; i++)
                {
                    if (!export.Export(list[i], _svr, _db, _uid, _pwd))
                    {
                        e.Result = export.ErrMessage;
                        success = false;
                        break;
                    }
                }
                if (success)
                    e.Result = "";
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                e.Result = err.Message;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            if(string.IsNullOrEmpty((string)e.Result))
                MessageBox.Show("Export data was success","Confirmation");
            else
                MessageBox.Show(e.Result.ToString(), "Error");

            btnExport.Enabled = true;
            btnTest.Enabled = true;
            btnCancel.Enabled = true;
            timer1.Stop();
            progressBar1.Value = 0;
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
