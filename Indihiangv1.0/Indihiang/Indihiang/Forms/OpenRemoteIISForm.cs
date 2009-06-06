using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;

using Indihiang.DomainObject;
namespace Indihiang.Forms
{
    public partial class OpenRemoteIISForm : Form
    {
        private List<IISInfo> _listIISInfo = null;

        public IISInfo IISSelected { get; private set; }
        public OpenRemoteIISForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DirectoryEntry de = new DirectoryEntry(string.Format("IIS://{0}/w3svc",txtComputerName.Text), txtUserId.Text, txtPassword.Text);
            de.RefreshCache();

            _listIISInfo = new List<IISInfo>();
            foreach (DirectoryEntry child in de.Children)
            {
                if (child.Properties["KeyType"].Value.ToString() == "IIsWebServer")
                {
                    IISInfo obj = new IISInfo();
                    obj.Id = child.Name;
                    obj.ServerComment = child.Properties["ServerComment"].Value.ToString();
                    obj.LogPath = child.Properties["LogFileDirectory"].Value.ToString();

                    string ports = child.Properties["ServerBindings"].Value.ToString();
                    string[] port = ports.Split(new char[] { ':' });
                    if (port.Length>1)
                        obj.ServerPort = port[1];

                    obj.RemoteServer = txtComputerName.Text;
                    obj.IISUserId = txtUserId.Text;
                    obj.IISPassword = txtPassword.Text;
                    _listIISInfo.Add(obj);
                }
            }

            listWebsite.DataSource = _listIISInfo;

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listWebsite.SelectedItem != null)
            {
                IISSelected = (IISInfo)listWebsite.SelectedItem;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select website you want to analyze", "Information");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
