using System;
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
        }

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;

            return success;
        }
    }
}
