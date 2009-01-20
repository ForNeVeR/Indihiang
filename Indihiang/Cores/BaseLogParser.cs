using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {
        protected string _logFile;
        protected EnumLogFile _logFileFormat;
        protected List<BaseLogAnalyzeFeature> _features;
        protected List<string> _currentHeader;

        public string LogFile
        {
            get
            {
                return _logFile;
            }
        }
        public EnumLogFile LogFileFormat
        {
            get
            {
                return _logFileFormat;
            }
        }
        public List<BaseLogAnalyzeFeature> Features
        {
            get
            {
                return _features;
            }
            set
            {
                if (_features == value)
                    return;
                _features = value;
            }
        }
        
        protected BaseLogParser(string logFile)
        {
            _logFile = logFile;
            _features = new List<BaseLogAnalyzeFeature>();
            _currentHeader = new List<string>();
        }

        public bool Parse()
        {
            using (StreamReader sr = new StreamReader(this._logFile))
            {
                string line = sr.ReadLine();
                while (line != "")
                {
                    if (!ParseHeader(line))
                    {
                        string[] rows = line.Split(new char[] { ' ' });
                        for (int i = 0; i < _features.Count; i++)
                            _features[i].Run(_currentHeader, rows);
                    }
                }
            }
            return true;
                     
        }

        protected abstract bool ParseHeader(string line);
    }
}
