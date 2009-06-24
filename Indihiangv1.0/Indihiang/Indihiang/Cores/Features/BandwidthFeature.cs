using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class BandwidthFeature : BaseLogAnalyzeFeature
    {
        public BandwidthFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.BANDWIDTH;

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
                    RunW3cext(header, item);
                    break;
            }

            return true;
        }

        private void RunW3cext(List<string> header, string[] item)
        {
            //int val = 0;
            //int index = header.IndexOf("date");
            //int index2 = header.IndexOf("cs-uri-stem");

            //if (index == -1 || index2 == -1)
            //    return;

            //string key = item[index];
            //string dataKey = item[index2];

            //if (dataKey != "" && dataKey != null && dataKey != "-")
            //{
            //    if (_logs["General"].Colls.ContainsKey(key))
            //    {
            //        if (_logs["General"].Colls[key].Items.ContainsKey(dataKey))
            //        {
            //            val = Convert.ToInt32(_logs["General"].Colls[key].Items[dataKey]);
            //            val++;
            //            _logs["General"].Colls[key].Items[dataKey] = val.ToString();
            //        }
            //        else
            //            _logs["General"].Colls[key].Items.Add(dataKey, "1");
            //    }
            //    else
            //        _logs["General"].Colls.Add(key, new WebLog(dataKey, "1"));
            //}
        }

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;

            return success;
        }
    }
}
