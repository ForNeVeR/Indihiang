using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Reflection;

namespace Indihiang.Forms
{
    public partial class CheckLatestVersionForm : Form
    {
        private string _targetDownload;
        private string _ver;
        private int _proggress;

        public CheckLatestVersionForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _proggress++;
            if (_proggress > 100)
                _proggress = 0;
            progressBar1.Value = _proggress;
        }

        private void CheckLatestVersionForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            timer1.Start();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(_targetDownload);
            System.Diagnostics.Process.Start(startInfo);
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dir = string.Format("{0}\\temp\\", path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            string file = string.Format("{0}ver.xml", dir);
            try
            {
                using (WebClient client = new WebClient())
                {                    
                    client.DownloadFile("http://www.indihiang.com/ver64.xml", file);
                }

                XmlSerializer xml = new XmlSerializer(typeof(Indihiang.DomainObject.IndihiangVersion));
                Indihiang.DomainObject.IndihiangVersion obj;
                using (TextReader r = new StreamReader(file))
                {
                    obj = (Indihiang.DomainObject.IndihiangVersion)xml.Deserialize(r);

                    Version current = Assembly.GetExecutingAssembly().GetName().Version;
                    Version latest = new Version(obj.Ver);
                    _targetDownload = "";
                    _ver = "";
                    CheckVersion(obj, current, latest);
                }
                

                e.Result = null;
            }
            catch (Exception err)
            {
                e.Result = err.Message;
            }
        }

        private void CheckVersion(Indihiang.DomainObject.IndihiangVersion obj, Version current, Version latest)
        {
            if (latest.Major > current.Major)
            {
                _targetDownload = obj.Url;
                _ver = obj.Ver;
            }
            else
            {
                if (latest.Major == current.Major)
                {
                    if (latest.Minor > current.Minor)
                    {
                        _targetDownload = obj.Url;
                        _ver = obj.Ver;
                    }
                    else
                    {
                        if (latest.Minor == current.Minor)
                        {
                            if (latest.Build > current.Build)
                            {
                                _targetDownload = obj.Url;
                                _ver = obj.Ver;
                            }
                            else
                                if (latest.Build == current.Build)
                                {
                                    if (latest.Revision > current.Revision)
                                    {
                                        _targetDownload = obj.Url;
                                        _ver = obj.Ver;
                                    }
                                }
                        }
                    }
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            progressBar1.Value = 0;

            if (e.Result != null)
            {
                MessageBox.Show(Convert.ToString(e.Result), "Error to check the latest Indihiang version");
                return;
            }

            if (!string.IsNullOrEmpty(_targetDownload))
            {
                lbStatus.Text = string.Format("The latest indihiang application is available {0}", _ver);
                btnDownload.Visible = true;
            }
            else
            {
                lbStatus.Text = "Your running appliation is the latest version";
            }
        }
    }
}
