using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class HitsFeature : BaseLogAnalyzeFeature
    {
        public HitsFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.HITS;

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
            //if (header.Exists(FindDate))
            //{
                int val = 0;
                int index = header.IndexOf("date");
                //int index = header.FindIndex(FindDate);
                string key = item[index];

                if (_logs["General"].Colls.ContainsKey(key))
                {
                    //lock (this)
                    //{
                        val = Convert.ToInt32(_logs["General"].Colls[key].Items[key]);
                        val++;
                        _logs["General"].Colls[key].Items[key] = val.ToString();
                    //}
                }
                else
                    //lock (this) { 
                        _logs["General"].Colls.Add(key, new WebLog(key, "1")); 
                    //}
            //}
        }
        private static bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
    }
}
