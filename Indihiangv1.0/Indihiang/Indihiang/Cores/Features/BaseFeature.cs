using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public abstract class BaseFeature
    {
        protected EnumLogFile _logFile = EnumLogFile.UNKNOWN;
        protected LogFeature _featureName;
        protected List<string> _fields;
                
        public LogFeature FeatureName
        {
            get
            {
                return _featureName;
            }
            set
            {
                if (_featureName == value)
                    return;
                _featureName = value;
            }
        }
        public List<string> FeatureFields
        {           
            get
            {
                return _fields;
            }
            set
            {
                if (_fields == value)
                    return;
                _fields = value;
            }
        }

        public BaseFeature(EnumLogFile logFile)
        {
            _logFile = logFile;
        }

        public void Parse(FeatureDataRow row)
        {
            RunFeature(row);
        }  

        protected abstract bool RunFeature(FeatureDataRow row);
    }
}
