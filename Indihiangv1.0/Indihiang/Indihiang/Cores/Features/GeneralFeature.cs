using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class GeneralFeature : BaseLogAnalyzeFeature
    {
        public GeneralFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.GENERAL;

            _logs.Add("General", new LogCollection());
            _logs.Add("IPServer", new LogCollection());
            
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
                    RunW3cext(header, item);
                    break;
            }

            return true;
        }
        private void RunW3cext(List<string> header, string[] item)
        {
            if (header.Exists(FindDate))
            {               
                int index = header.FindIndex(FindDate);                
                string key = item[index];
                int index2 = header.FindIndex(FindIPServer);
                string key2 = item[index2];

                try
                {
                    if (!string.IsNullOrEmpty(key) && key != "-")
                    {
                        lock (this)
                        {
                            if (!_logs["General"].Colls.ContainsKey(key))
                                _logs["General"].Colls.Add(key, new WebLog(key, ""));
                        }
                    }
                    if (!string.IsNullOrEmpty(key2) && key2 != "-")
                    {
                        lock (this)
                        {
                            if (!_logs["IPServer"].Colls.ContainsKey(key2))
                                _logs["IPServer"].Colls.Add(key2, new WebLog(key2, ""));
                        }
                    }
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Error: {0}", err.Message));
                }
            }
        }
        private static bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
        private static bool FindIPServer(string item)
        {
            if (item == "s-ip")
                return true;

            return false;
        }
    }
}
