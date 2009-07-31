using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Indihiang.Cores.Features;

namespace Indihiang.Cores
{
    public sealed class IndihiangHelper
    {

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
        public static string GetIndihiangFile(string dateData,string guid)
        {
            if (!string.IsNullOrEmpty(dateData))
                return string.Empty;

            string year = dateData.Substring(0, 4);            
            string file = String.Format("{0}\\data\\{1}\\log{3}.indihiang", Environment.CurrentDirectory, guid,year);

            return file;
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
