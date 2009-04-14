using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class IPAddressFeature : BaseLogAnalyzeFeature
    {
        public IPAddressFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.IPADDRESS;

            _logs.Add("General", new LogCollection());
            
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
                int index2 = header.FindIndex(FindIP);
                string key2 = item[index2];
                int index3 = header.FindIndex(FindPage);
                string key3 = item[index3];

                if (key != "" && key != null && key != "-")
                {
                    if (key2 != "" && key2 != null && key2 != "-")
                    {
                        if (_logs["General"].Colls.ContainsKey(key2))
                            _logs["General"].Colls[key2].Items.Add(key, key3);
                        else
                            _logs["General"].Colls.Add(key2, new WebLog(key, key3));
                    }

                }                
            }
        }
        private static bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
        private static bool FindIP(string item)
        {
            if (item == "c-ip")
                return true;

            return false;
        }
        private static bool FindPage(string item)
        {
            if (item == "cs-uri-stem")
                return true;

            return false;
        }
    }
}
