using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class UserAgentFeature : BaseLogAnalyzeFeature
    {
        public UserAgentFeature(EnumLogFile logFile)
            : base(logFile)
        {
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
            //check useragent header
            if (header.Exists(FindUserAgent))
            {
                int index = header.FindIndex(FindUserAgent);
                string key = item[index];
                if (_items.Colls.ContainsKey(key))
                {
                    int val = Convert.ToInt32(_items.Colls[key]);
                    val++;
                    _items.Colls[key] = val.ToString();
                }
                else
                    _items.Colls.Add(key, "1");
            }
        }
        private bool FindUserAgent(string userAgent)
        {
            if (userAgent == "cs(User-Agent)")
                return true;

            return false;
        }
    }
}
