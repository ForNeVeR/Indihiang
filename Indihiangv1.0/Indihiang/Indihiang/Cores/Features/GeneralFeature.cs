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
            _logs.Add("TotalData", new LogCollection());
            
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
            //if (header.Exists(FindDate))
            //{
                int index = header.IndexOf("date");
                int index2 = header.IndexOf("s-ip");
                //int index = header.FindIndex(0,FindDate);
                //int index2 = header.FindIndex(0,FindIPServer);
                
                if (index == -1 || index2 == -1)
                    return;

                string key = item[index];
                string key2 = item[index2];

                try
                {
                    if (!string.IsNullOrEmpty(key) && key != "-")
                    {
                        //lock (this)
                        //{
                            if (!_logs["General"].Colls.ContainsKey(key))
                                _logs["General"].Colls.Add(key, new WebLog(key, ""));

                            if (_logs["TotalData"].Colls.ContainsKey("TotalData"))
                            {
                                int val = Convert.ToInt32(_logs["TotalData"].Colls["TotalData"].Items["TotalData"]);
                                val++;
                                _logs["TotalData"].Colls["TotalData"].Items["TotalData"] = val.ToString();
                            }
                            else
                            {
                                _logs["TotalData"].Colls.Add("TotalData", new WebLog("TotalData", "1"));
                            }
                        //}
                    }
                    if (!string.IsNullOrEmpty(key2) && key2 != "-")
                    {
                        //lock (this)
                        //{
                            if (!_logs["IPServer"].Colls.ContainsKey(key2))
                                _logs["IPServer"].Colls.Add(key2, new WebLog(key2, ""));
                        //}
                    }
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("GeneralFeature Error: {0}", err.Message));
                }
            //}
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
