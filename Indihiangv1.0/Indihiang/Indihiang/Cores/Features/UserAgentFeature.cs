using System;
using System.Collections.Generic;


namespace Indihiang.Cores.Features
{
    public class UserAgentFeature : BaseLogAnalyzeFeature
    {
        public UserAgentFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.USERAGENT;

            LogCollection log = new LogCollection();
            _logs.Add("General", log);
        }
        protected override bool RunFeature(List<string> header, string[] item)
        {
            switch (_logFile)
            {
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.W3CEXT:
                    RunW3cext(header,item);
                    break;
            }

            return true;
        }
       

        private void RunW3cext(List<string> header, string[] item)
        {            
            if (header.Exists(FindUserAgent))
            {
                if (header.Exists(FindDate))
                {
                    int val = 0;
                    int index = header.FindIndex(FindDate);
                    int index2 = header.FindIndex(FindUserAgent);
                    string key = item[index];
                    string data = item[index2];

                    if (!string.IsNullOrEmpty(data) && data != "-")
                    {
                        string browser = CheckBrowser(data);

                        lock (this)
                        {
                            if (_logs["General"].Colls.ContainsKey(key))
                            {
                                if (_logs["General"].Colls[key].Items.ContainsKey(browser))
                                {
                                    val = Convert.ToInt32(_logs["General"].Colls[key].Items[browser]);
                                    val++;
                                    _logs["General"].Colls[key].Items[browser] = val.ToString();
                                }
                                else
                                    _logs["General"].Colls[key].Items.Add(browser, "1");
                            }
                            else
                                _logs["General"].Colls.Add(key, new WebLog(browser, "1"));
                        }
                    }
                }
            }
        }
        private string CheckBrowser(string line)
        {
            if (line.Contains("MSIE"))            
                return "MS Internet Explorer";
            if (line.Contains("Firefox"))
                return "Firefox";
            if (line.Contains("Safari"))
                return "Safari";
            if (line.Contains("Chrome"))
                return "Google Chrome";
            if (line.Contains("Gecko"))
                return "Mozilla";
            if (line.Contains("Opera"))
                return "Opera ";
            if (line.Contains("Netscape") || line.Contains("Navigator"))
                return "Netscape ";

            System.Diagnostics.Debug.WriteLine(line);
            return "Unknown";
        }
        private static bool FindUserAgent(string item)
        {
            if (item == "cs(User-Agent)")
                return true;

            return false;
        }
        private static bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
    }
}
