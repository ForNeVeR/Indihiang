using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class GeneralFeature : BaseLogAnalyzeFeature
    {
        public GeneralFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.GENERAL;

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
            if (header.Exists(FindDate))
            {               
                int index = header.FindIndex(FindDate);                
                string key = item[index];

                if (key != "" && key != null && key != "-")
                {
                    if (!_logs["General"].Colls.ContainsKey(key))
                        _logs["General"].Colls.Add(key, null);                  
                }
            }
        }
        
        private static bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
    }
}
