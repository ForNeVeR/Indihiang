using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public abstract class BaseLogAnalyzeFeature
    {
        protected EnumLogFile _logFile = EnumLogFile.UNKNOWN;
        protected string _featureName;
        protected LogCollection<int> _items = new LogCollection<int>();

        public string FeatureName
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
        public LogCollection<int> Items
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
