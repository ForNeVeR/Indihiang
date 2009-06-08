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
        protected List<BaseLogAnalyzeFeature> _features;
        protected List<string> _currentHeader;
        private SynchronizationContext _synContext;

        public event EventHandler<LogInfoEventArgs> ParseLogHandler;

        public string LogFile { get; set; }
        public string ParserID { get; set; }
        public EnumLogFile LogFileFormat { get; protected set; }
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
            LogFile = logFile;
            LogFileFormat = logFileFormat;
            _features = new List<BaseLogAnalyzeFeature>();
            _currentHeader = new List<string>();
            _synContext = AsyncOperationManager.SynchronizationContext;
        }

        protected virtual void OnParseLog(LogInfoEventArgs e)
        {
            if (this.ParseLogHandler != null)
                this.ParseLogHandler(this, e);

            Debug.WriteLine(String.Format("OnParseLog:: {0}", e.Message));
        }

        public bool Parse()
        {
            if (LogFile.StartsWith("--"))
            {
                string tmp = this.LogFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });

                try
                {
                    //Parallel.For(0, files.Length, i =>
                    //{
                    //    if (!string.IsNullOrEmpty(files[i]))
                    //        ParseLogFile(files[i]);
                    //});

                    for (int i = 0; i < files.Length; i++)
                        if (!string.IsNullOrEmpty(files[i]))
                            ParseLogFile(files[i]);

                }
                catch (Exception err)
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                           ParserID,
                           EnumLogFile.UNKNOWN,
                           LogProcessStatus.SUCCESS,
                           "ParseLogFile()",
                           String.Format("Internal Error: {0}", err.Message));
                    _synContext.Post(OnParseLog, logInfo);
                }
               
            }
            else
                ParseLogFile(LogFile);
            
            return true;
                     
        }
        protected void ParseLogFile(string logFile)
        {
            using (StreamReader sr = new StreamReader(logFile))
            {
                string line = sr.ReadLine();

                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   ParserID,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "ParseLogFile()",
                   String.Format("Read File: {0}", logFile));
                this._synContext.Post(OnParseLog, logInfo);

                Debug.WriteLine(String.Format("Read File: {0}", logFile));
                Debug.WriteLine(String.Format("Indihiang Read: {0}", line));
                while (!string.IsNullOrEmpty(line))
                {
                    Debug.WriteLine(String.Format("Read: {0}", line));
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
                      ParserID,
                      EnumLogFile.UNKNOWN,
                      LogProcessStatus.SUCCESS,
                      "ParseLogFile()",
                      String.Format("Read File: {0} is done", logFile));
                _synContext.Post(OnParseLog, logInfo);
            }
        }


        protected abstract bool ParseHeader(string line);
    }
}
