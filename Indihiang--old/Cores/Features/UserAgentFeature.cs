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
            _featureName = LogFeature.USERAGENT;
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

//            if(suppliers.Exist(delegate (Supplier match)
//{
//return match.Name == whateverValueYouWantToMatchOn;
//}))
//{
//do something
//}
//else
//{
//do something else
//}


            //check useragent header
            if (header.Exists(FindUserAgent))
            {
                if (header.Exists(FindDate))
                {
                    int index = header.FindIndex(FindDate);
                    string key = item[index];
                    if (_items.Exists())
                    {
                        int val = Convert.ToInt32(_items.Colls[key]);
                        val++;
                        _items.Colls[key] = val.ToString();
                    }
                    else
                        _items.Colls.Add(key, "1");
                }
            }
        }
        private bool FindUserAgent(string item)
        {
            if (item == "cs(User-Agent)")
                return true;

            return false;
        }
        private bool FindDate(string item)
        {
            if (item == "date")
                return true;

            return false;
        }
    }
}
