using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;

namespace Indihiang.Cores
{
    public class RemoteFileCopyHelper
    {
        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);


        public static int CopyRemoteFiles(string pathSource, string pathDestination,string remoteServer,string uid,string pwd,string domain)
        {
            int total = 0;
            IntPtr admin_token = default(IntPtr);
            WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            WindowsIdentity wid_admin = new WindowsIdentity(admin_token);
            WindowsImpersonationContext wic = wid_admin.Impersonate();

            try
            {
                if (LogonUser(uid, domain, pwd, 9, 0, ref admin_token) != 0)
                {
                    if (!Directory.Exists(String.Format("{0}\\Temp\\", pathDestination)))
                        Directory.CreateDirectory(String.Format("{0}\\Temp\\", pathDestination));

                    pathSource = pathSource.Replace(":", "$");
                    wid_admin = new WindowsIdentity(admin_token);
                    wic = wid_admin.Impersonate();
                    File.Copy(String.Format("{0}\\{1}\\*.*", remoteServer, pathSource),
                              String.Format("{0}\\{1}\\*.*", pathDestination, pathSource), true);
                    
                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error CopyRemoteFiles: {0}", err.Message));
            }

            return total;
        }

    }
}
