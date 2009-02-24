using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public abstract class BaseLogAnalyzeFeature
    {
        protected EnumLogFile _logFile = EnumLogFile.UNKNOWN;
        protected LogFeature _featureName;
        protected LogCollection<string> _items = new LogCollection<string>();

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
        public LogCollection<string> Items
        {
            set
            {
                _items = value;
            }
            get
            {
                return _items;
            }
        }

        public BaseLogAnalyzeFeature(EnumLogFile logFile)
        {
            _logFile = logFile;
        }

        public void Run(List<string> header,string[] item)
        {
            RunFeature(header, item);
        }

        protected abstract bool RunFeature(List<string> header, string[] item);
    }
}
