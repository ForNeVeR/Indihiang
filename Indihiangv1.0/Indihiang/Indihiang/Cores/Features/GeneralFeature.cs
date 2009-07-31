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

            _fields.Add("date");
            _fields.Add("s-ip");

        }

        protected override bool RunFeature(FeatureDataRow row)
        {
            switch (_logFile)
            {
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.W3CEXT:
                    RunW3cext(row);
                    break;
            }

            return true;
        }

        public void RunW3cext(FeatureDataRow row)
        {
        }

    }
}
