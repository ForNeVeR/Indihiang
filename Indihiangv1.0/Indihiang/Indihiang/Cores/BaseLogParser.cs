using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {
        protected string _logFile;
        protected EnumLogFile _logFileFormat;
        protected List<BaseLogAnalyzeFeature> _features;
        protected List<string> _currentHeader;
        private SynchronizationContext _synContext;

        public event EventHandler<LogInfoEventArgs> ParseLogHandler;

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

        protected BaseLogParser(string logFile, EnumLogFile logFileFormat)
        {
            _logFile = logFile;
            _logFileFormat = logFileFormat;
            _features = new List<BaseLogAnalyzeFeature>();
            _currentHeader = new List<string>();
            _synContext = AsyncOperationManager.SynchronizationContext;
        }

        protected virtual void OnParseLog(LogInfoEventArgs e)
        {
            if (this.ParseLogHandler != null)
                this.ParseLogHandler(this, e);

            Debug.WriteLine("OnParseLog:: " + e.Message);
        }

        public bool Parse()
        {
            if (this._logFile.StartsWith("--"))
            {
                string tmp = this._logFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });

                for (int i = 0; i < files.Length; i++)
                    if(!string.IsNullOrEmpty(files[i]))
                        ParseLogFile(files[i]);
            }
            else
                ParseLogFile(this._logFile);
            
            return true;
                     
        }
        protected void ParseLogFile(string logFile)
        {
            using (StreamReader sr = new StreamReader(logFile))
            {
                string line = sr.ReadLine();

                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   this._logFile,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "ParseLogFile()",
                   "Read File: " + logFile);
                this._synContext.Post(OnParseLog, logInfo);
                
                Debug.WriteLine("Read File: " + logFile);                
                Debug.WriteLine("Indihiang Read: " + line);
                while (!string.IsNullOrEmpty(line))
                {
                    Debug.WriteLine("Read: " + line);
                    if (!ParseHeader(line))
                    {
                        if (line != string.Empty && line != null)
                        {
                            string[] rows = line.Split(new char[] { ' ' });
                            for (int i = 0; i < _features.Count; i++)
                                _features[i].Parse(_currentHeader, rows);
                        }
                    }
                    line = sr.ReadLine();
                    if (line != null)
                        line = line.TrimEnd('\0');                  
                }

                logInfo = new LogInfoEventArgs(
                      this._logFile,
                      EnumLogFile.UNKNOWN,
                      LogProcessStatus.SUCCESS,
                      "ParseLogFile()",
                      "Read File: " + logFile + " is done");
                this._synContext.Post(OnParseLog, logInfo);
            }
        }


        protected abstract bool ParseHeader(string line);
    }
}
