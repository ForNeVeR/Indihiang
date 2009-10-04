using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class GeneralFeature : BaseFeature
    {
        public GeneralFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.GENERAL;
            
            _fields.Add("s-ip");
            _fields.Add("total");
            _fields.Add("min-date");
            _fields.Add("max-date");
        }

        protected override bool RunFeature(int sharedId,List<string> header, List<string> rows)
        {
            switch (_logFile)
            {
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.W3CEXT:
                    RunW3cext(sharedId,header, rows);
                    break;
            }

            return true;
        }

        public void RunW3cext(int sharedId,List<string> header, List<string> rows)
        {            

            try
            {
                int index = header.IndexOf("s-ip");
                if (index >= 0)
                {
                    string data = rows[index];
                    //int id = _db.GetFeaturedDataId(_featureName.ToString(), sharedId, data);
                    

                }
                //_db.InsertShared("date",)
            }
            catch (Exception) { }
        }

    }
}
