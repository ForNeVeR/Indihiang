using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Reflection;

using Indihiang.DomainObject;
namespace Indihiang.Cores
{
    public sealed class RemoteFileCopyHelper
    {
        private RemoteFileCopyHelper() { }


        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);


        public static bool CopyRemoteFiles(IISInfo iisInfo)
        {
            bool success = false;
            IntPtr admin_token = default(IntPtr);
            WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            WindowsIdentity wid_admin = null;
            admin_token = wid_current.Token;
            WindowsImpersonationContext wic = null;

            try
            {
                
                string uid = "";
                string domain = "";
                string tmp = iisInfo.IISUserId;
                if (tmp.Contains("\\"))
                {                    
                    string[] temp1 = tmp.Split(new char[] { '\\' });
                    if (temp1 != null)
                    {
                        uid = temp1[0];
                        domain = temp1[1];
                    }
                }
                else
                {
                    uid = iisInfo.IISUserId;
                    domain = iisInfo.RemoteServer;
                }

                if (LogonUser(uid, domain, iisInfo.IISPassword, 9, 0, ref admin_token) != 0)
                {
                    ConfigureDestinationPath(iisInfo);

                    string pathSource = "";
                    if (!iisInfo.LocalComputer)
                        pathSource = iisInfo.LogPath.Replace(":", "$");

                    string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string pathDest = String.Format("{0}\\Temp\\{1}{2}\\", dir, iisInfo.RemoteServer, iisInfo.Id);

                    wid_admin = new WindowsIdentity(admin_token);
                    wic = wid_admin.Impersonate();

                    string[] files = null;
                    files = Directory.GetFiles(String.Format("\\\\{0}\\{1}\\W3SVC{2}\\", iisInfo.RemoteServer, pathSource, iisInfo.Id));

                    //if (iisInfo.LocalComputer)
                    //{
                    //    files = Directory.GetFiles(String.Format("{0}\\W3SVC{1}\\", iisInfo.LogPath, iisInfo.Id));
                    //}
                    //else
                    //    files = Directory.GetFiles(String.Format("\\\\{0}\\{1}\\W3SVC{2}\\", iisInfo.RemoteServer, pathSource,iisInfo.Id));

                    if (files != null)
                    {
                        Array.ForEach(files, s =>
                        {
                            string fileName = Path.GetFileName(s);
                            string destFile = Path.Combine(pathDest, fileName);
                            File.Copy(s, destFile, true);
                        });
                    }
                    success = true;                    
                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error CopyRemoteFiles: {0}", err.Message));
                System.Diagnostics.Debug.WriteLine(String.Format("Error CopyRemoteFiles: {0}", err.StackTrace)); 
            }

            return success;
        }

        private static void ConfigureDestinationPath(IISInfo iisInfo)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists(String.Format("{0}\\Temp\\", path)))
                Directory.CreateDirectory(String.Format("{0}\\Temp\\", path));

            if (!Directory.Exists(String.Format("{0}\\Temp\\{1}{2}\\", path, iisInfo.RemoteServer, iisInfo.Id)))
                Directory.CreateDirectory(String.Format("{0}\\Temp\\{1}{2}\\", path, iisInfo.RemoteServer, iisInfo.Id));
            else
            {
                string[] filePaths = Directory.GetFiles(String.Format("{0}\\Temp\\{1}{2}\\", path, iisInfo.RemoteServer, iisInfo.Id));
                Array.ForEach(filePaths, File.Delete);
            }
            
        }

    }
}
