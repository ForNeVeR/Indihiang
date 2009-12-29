using System;
using System.IO;
using System.Collections.Generic;
using Indihiang.Cores.Features;

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
        public static string GetIndihiangFile(string year,string guid)
        {
            if (string.IsNullOrEmpty(year))
                return string.Empty;

            return String.Format("{0}\\data\\{1}\\log{2}.dat", Environment.CurrentDirectory, guid, year);
        }
        public static List<string> GetIndihiangFileList(string guid)
        {
            string path = String.Format("{0}\\data\\{1}\\", Environment.CurrentDirectory, guid);
            List<string> list = new List<string>(Directory.GetFiles(path,"*.dat"));

            return list;
        }
        public static void CopyLogDB(string file)
        {
            if (string.IsNullOrEmpty(file))
                return;

            if (!Directory.Exists(Path.GetDirectoryName(file)))
                Directory.CreateDirectory(Path.GetDirectoryName(file));

            string sourceFile = String.Format("{0}\\media\\dump_indihiang.dat", Environment.CurrentDirectory);
            try
            {
                File.Copy(sourceFile, file);
            }
            catch (Exception) { }

        }
        public static List<string> MergeFields(List<BaseFeature> features)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < features.Count; i++)
            {
                for (int j = 0; j < features[i].FeatureFields.Count; i++)
                {
                    if (!list.Contains(features[i].FeatureFields[j]))
                        list.Add(features[i].FeatureFields[j]);
                }
            }

            return list;
        }
        public static List<BaseFeature> GenerateIndihiangFeatures(Guid parserId, EnumLogFile format)
        {
            List<BaseFeature> features = new List<BaseFeature>();
            features.Add(new GeneralFeature(format));
            //features.Add(new HitsFeature(format));
            //features.Add(new UserAgentFeature(format));
            //features.Add(new AccessPageFeature(format));
            //features.Add(new IPAddressFeature(format));
            //features.Add(new AccessStatusFeature(format));
            //features.Add(new BandwidthFeature(format));
            //features.Add(new RequestFeature(format));

            return features;
        }
        public static List<BaseLogAnalyzeFeature> GenerateParallelFeatures(Guid parserId,EnumLogFile format)
        {
            List<BaseLogAnalyzeFeature> features = new List<BaseLogAnalyzeFeature>();
            //features.Add(new GeneralFeature(format));
            features.Add(new HitsFeature(format));
            features.Add(new UserAgentFeature(format));
            features.Add(new AccessPageFeature(format));
            features.Add(new IPAddressFeature(format));
            features.Add(new AccessStatusFeature(format));
            features.Add(new BandwidthFeature(format));
            features.Add(new RequestFeature(format)); 

            return features;
        }
        public static List<BaseLogAnalyzeFeature> GenerateFeatures(EnumLogFile format)
        {
            List<BaseLogAnalyzeFeature> features = new List<BaseLogAnalyzeFeature>();
            //features.Add(new GeneralFeature(format));
            features.Add(new HitsFeature(format));
            features.Add(new UserAgentFeature(format));
            features.Add(new AccessPageFeature(format));
            features.Add(new IPAddressFeature(format));
            features.Add(new AccessStatusFeature(format));
            features.Add(new BandwidthFeature(format));
            features.Add(new RequestFeature(format));  

            return features;
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

        public static void DumpToFile(string guid, string file, Dictionary<string, WebLog> logs)
        {
            string path = Environment.CurrentDirectory;
            if(!Directory.Exists(String.Format("{0}\\{1}\\", path, guid)))
                Directory.CreateDirectory(String.Format("{0}\\{1}\\", path, guid));

            using(StreamWriter sw = new StreamWriter(String.Format("{0}\\{1}\\", path, guid),false))
            {
                foreach (KeyValuePair<string, WebLog> pair1 in logs)
                {
                    foreach (KeyValuePair<string, string> pair2 in pair1.Value.Items)
                    {
                        string data = String.Format("{0};{1};{2}", pair1.Key, pair2.Key, pair2.Value);
                        sw.WriteLine(data);
                    }
                }
            }

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
