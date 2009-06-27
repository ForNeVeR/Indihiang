﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class RequestFeature : BaseLogAnalyzeFeature
    {
        public RequestFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.REQUEST;

            LogCollection log = new LogCollection();
            _logs.Add("TimeTaken", log);            
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
            int val = 0;
            int index = header.IndexOf("date");
            int index2 = header.IndexOf("time");
            int index3 = header.IndexOf("cs-uri-stem");
            int index4 = header.IndexOf("time-taken");

            if (index == -1 || index2==-1)
                return;

            string key1 = item[index];
            string key2 = item[index2];
            string key = string.Format("{0} {1}", key1, key2);

            string data1;
            if (index3 > 0)
                data1 = item[index3];
            else
                data1 = string.Empty;
            string data2;
            if (index4 > 0)
                data2 = item[index4];
            else
                data2 = string.Empty;

            if (!string.IsNullOrEmpty(data1) && data1 != "-" && !string.IsNullOrEmpty(data2) && data2 != "-")
            {
                _logs["TimeTaken"].Colls.Add(key, new WebLog(data1, data2));
            }

        }

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in newItem)
                {
                    if (pair.Key == "TimeTaken")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            if (!_logs[pair.Key].Colls.ContainsKey(pair2.Key))
                                _logs[pair.Key].Colls.Add(pair2.Key, pair2.Value);
                        }
                    }
                }
                success = true;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error Synch: {0}", err.Message));
            }
            return success;
        }
    }
}
