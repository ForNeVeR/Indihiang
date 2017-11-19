using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

using Indihiang.Data;
namespace Indihiang.Cores
{
    public sealed class IndihiangHelper
    {
        public static string GetStringLogItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return "";
            if (item.Trim() == "-")
                return "";

            return item;
        }
        public static List<string> ParseFile(string listFile)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(listFile))
            {
                string tmp = listFile;
                if (tmp.StartsWith("--") || tmp.StartsWith("$$"))
                    tmp = tmp.Substring(2);

                string[] files = tmp.Split(new char[] { ';' });

                if (files != null)
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(files[i]))
                            list.Add(files[i]);
                    }
            }
            else
                list.Add(listFile);

            return list;
        }
        public static string GetIPCountryDb()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return String.Format("{0}\\Media\\ipcountry.db", path);
        }
        public static string GetIndihiangFile(string year,string guid)
        {
            if (string.IsNullOrEmpty(year))
                return string.Empty;

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return String.Format("{0}\\Data\\{1}\\log{2}.dat", path, guid, year);
        }
        public static List<string> GetIndihiangFileList(string guid)
        {
            List<string> list = new List<string>();

            if (guid.StartsWith("!!"))
            {
                list.Add(guid.Substring(2));
            }
            else
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string path = String.Format("{0}\\Data\\{1}\\", dir, guid);
                if(Directory.Exists(path))
                    list = new List<string>(Directory.GetFiles(path, "*.dat"));
            }

            return list;
        }
        public static void CopyLogDB(string file)
        {
            if (string.IsNullOrEmpty(file))
                return;

            if (!Directory.Exists(Path.GetDirectoryName(file)))
                Directory.CreateDirectory(Path.GetDirectoryName(file));

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string sourceFile = String.Format("{0}\\Data\\dump_indihiang.dat", dir);
            try
            {
                File.Copy(sourceFile, file);
				return;
            }
            catch (Exception/* err*/)
			{
				//
			}

			try
			{
				File.Copy("dump_indihiang.dat", file);
			}
			catch (Exception err)
			{
				System.Windows.Forms.MessageBox.Show("Failed to copy database template.\nNo data can be presented to you.\n\nException: " + err.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
        }

        public static string GetYearDataIndihiangFile(string file)
        {
            DataHelper helper = new DataHelper(file);
            List<Indihiang.DomainObject.Indihiang> list = new List<Indihiang.DomainObject.Indihiang>(helper.GetAllIndihiang());

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Sys_Item == "data_year")
                    return list[i].Sys_Value;
            }

            return null;
        }

        public static void InitialIndihiangFile(string file, string year)
        {
            try
            {
                DataHelper helper = new DataHelper(file);

                Indihiang.DomainObject.Indihiang obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "indihiang_version";
                obj.Sys_Value = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "dotnet_version";
                obj.Sys_Value = Environment.Version.ToString();
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "hostname";
                obj.Sys_Value = Environment.MachineName;
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "username";
                obj.Sys_Value = Environment.UserName;
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "os_version";
                obj.Sys_Value = Environment.OSVersion.VersionString;
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "working_directory";
                obj.Sys_Value = Environment.CurrentDirectory;
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "data_year";
                obj.Sys_Value = year;
                helper.InsertIndihiang(obj);

                obj = new Indihiang.DomainObject.Indihiang();
                obj.Sys_Item = "last_acces";
                obj.Sys_Value = DateTime.Now.ToString();
                helper.InsertIndihiang(obj);

            }
            catch (Exception) { }
        }


        public static string GetMonth(int month)
        {
            string m = string.Empty;
            switch (month)
            {
                case 1:
                    m = "January";
                    break;
                case 2:
                    m = "February";
                    break;
                case 3:
                    m = "March";
                    break;
                case 4:
                    m = "April";
                    break;
                case 5:
                    m = "May";
                    break;
                case 6:
                    m = "June";
                    break;
                case 7:
                    m = "July";
                    break;
                case 8:
                    m = "August";
                    break;
                case 9:
                    m = "September";
                    break;
                case 10:
                    m = "October";
                    break;
                case 11:
                    m = "November";
                    break;
                case 12:
                    m = "December";
                    break;
            }
            return m;
        }
        public static int GetMonth(string month)
        {
            int m = -1;
            switch (month)
            {
                case "January":
                    m = 1;
                    break;
                case "February":
                    m = 2;
                    break;
                case "March":
                    m = 3;
                    break;
                case "April":
                    m = 4;
                    break;
                case "May":
                    m = 5;
                    break;
                case "June":
                    m = 6;
                    break;
                case "July":
                    m = 7;
                    break;
                case "August":
                    m = 8;
                    break;
                case "September":
                    m = 9;
                    break;
                case "October":
                    m = 10;
                    break;
                case "November":
                    m = 11;
                    break;
                case "December":
                    m = 12;
                    break;
            }
            return m;
        }

        public static string DurationFormat(long time)
        {
            if (time == 0)
                return "-";

            double s = time;
            string[] format = new string[] { "{0} miliseconds","{0} seconds", "{0} minutes", "{0} hours"};
            int i = 0;
            if (time >= 1000 && time < 60000)
            {
                i = 1;
                s = s / 1000;
            }
            if (time >= 60000 && time < 3600000)
            {
                i = 2;
                s = s / 60000;
            }
            if (time >= 3600000)
            {
                i = 3;
                s = s / 3600000;
            }

            return string.Format(format[i], s.ToString("#.##"));
        }


        public static string CheckUserAgent(string line)
        {
            if (string.IsNullOrEmpty(line) || line == "-")
                return "";

            if (line.Contains("MIDP") || line.Contains("Blackberry") || line.Contains("Nokia") || line.Contains("SonyEricsson"))
                return "Mobile Browser";
            if (line.Contains("Chrome") && line.Contains("Safari") && line.Contains("AppleWebKit"))
            {
                if (line.Contains("Mobile"))
                    return "Mobile Browser";

                return "Google Chrome";
            }
            if (line.Contains("MSIE"))
                return "MS Internet Explorer";
            if (line.Contains("Firefox"))
                return "Firefox";
            if (line.Contains("Safari") && line.Contains("AppleWebKit"))
            {
                if (line.Contains("iPhone"))
                    return "Mobile Browser";

                return "Safari";
            }
            if (line.Contains("Opera"))
                return "Opera ";
            if (line.Contains("Netscape") || line.Contains("Navigator"))
                return "Netscape ";

            System.Diagnostics.Debug.WriteLine(line);
            return "Unknown";
        }

        public static string GetRefererClass(string line)
        {

            if (string.IsNullOrEmpty(line) || line == "-")
                return "Direct Traffic";

            //list of search engine could be found on
            //http://en.wikipedia.org/wiki/List_of_search_engines
            //you can add another search engine
            if (line.ToLower().Contains("google.") || line.ToLower().Contains("yahoo.") ||
                line.ToLower().Contains("bing.") || line.Contains("ask.") ||
                line.ToLower().Contains("cuil.") || line.Contains("duckduckgo.") ||
                line.ToLower().Contains("sogou.") || line.Contains("baidu.") || line.Contains("kosmix."))
                return "Search Engines";


            return "Referring Sites";
        }

        /// Credits to
        /// http://www.justin-cook.com/wp/2006/11/28/convert-an-ip-address-to-ip-number-with-php-asp-c-and-vbnet/
        public static double IPAddressToNumber(string IPaddress)
        {
            int i;
            string[] arrDec;
            double num = 0;
            if (IPaddress == "" || IPaddress.Contains("::"))
            {
                return 0;
            }
            else
            {
				try
				{
					MatchCollection matches = Regex.Matches(IPaddress, @"\d+\.\d+\.\d+\.\d+");
					if (matches.Count != 0)
						IPaddress = matches[matches.Count - 1].Value;

					arrDec = IPaddress.Split('.');
					for (i = arrDec.Length - 1; i >= 0; i--)
					{
						num += ((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
					}
					return num;
				}
				catch
				{
					return 0;
				}
            }
        }


        /// Credits to
        /// http://blogs.interakting.co.uk/brad/archive/2008/01/24/c-getting-a-user-friendly-file-size-as-a-string.aspx
        public static string BytesFormat(long bytes)
        {
            double s = bytes;
            string[] format = new string[] { "{0} bytes", "{0} KB", "{0} MB", "{0} GB", "{0} TB", "{0} PB", "{0} EB", "{0} ZB", "{0} YB" };
            int i = 0;
            while (i < format.Length - 1 && s >= 1024)
            {
                s = (100 * s / 1024) / 100.0;
                i++;

            }
            return string.Format(format[i], s.ToString("###,###,##0.##"));
        }

    }
}
