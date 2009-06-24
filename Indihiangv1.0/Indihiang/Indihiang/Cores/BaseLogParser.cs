using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {
        protected SpinLock _spinLock;
        protected List<BaseLogAnalyzeFeature> _features;
        protected List<BaseLogAnalyzeFeature> _paralleFeatures;
        protected List<string> _currentHeader;
        private SynchronizationContext _synContext;        

        public event EventHandler<LogInfoEventArgs> ParseLogHandler;

        public string LogFile { get; set; }
        public string ParserID { get; set; }
        public EnumLogFile LogFileFormat { get; protected set; }
        public bool UseParallel { get; set; }        
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
        public List<BaseLogAnalyzeFeature> ParalleFeatures
        {
            get
            {
                return _paralleFeatures;
            }
            set
            {
                if (_paralleFeatures == value)
                    return;
                _paralleFeatures = value;
            }
        }

        protected BaseLogParser(string logFile, EnumLogFile logFileFormat)
        {
            _spinLock = new SpinLock();
            LogFile = logFile;
            LogFileFormat = logFileFormat;
            _features = new List<BaseLogAnalyzeFeature>();
            _paralleFeatures = new List<BaseLogAnalyzeFeature>();
            _currentHeader = new List<string>();
            _synContext = AsyncOperationManager.SynchronizationContext;
        }

        protected virtual void OnParseLog(LogInfoEventArgs e)
        {
            if (ParseLogHandler != null)
                ParseLogHandler(this, e);

            Debug.WriteLine(String.Format("OnParseLog:: {0}", e.Message));
        }

        public bool Parse()
        {
            if (LogFile.StartsWith("--"))
            {
                string tmp = LogFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });

                if (UseParallel)
                {
                    Parallel.For(0, files.Length, i =>
                    {
                        try
                        {
                            List<BaseLogAnalyzeFeature> features = IndihiangHelper.GenerateParallelFeatures(LogFileFormat);
                            if (!string.IsNullOrEmpty(files[i]))
                                features = ParseLogFile(features, files[i]);

                            _spinLock.Enter();
                            features.ForEach(delegate(BaseLogAnalyzeFeature feature)
                            {
                                for (int j = 0; j < _paralleFeatures.Count; j++)
                                    if (_paralleFeatures[j].FeatureName == feature.FeatureName)
                                        _paralleFeatures[j].SynchData(feature.Items);
                            });
                            _spinLock.Exit();
                        }
                        catch (Exception err)
                        {
                            #region Handle Exception
                            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "ParseLogFile()",
                               String.Format("Internal Error: {0}", err.Message));
                            _synContext.Post(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Source Internal Error: {0}", err.Source));
                            _synContext.Post(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Detail Internal Error: {0}", err.StackTrace));
                            _synContext.Post(OnParseLog, logInfo);

                            #endregion

                        }
                    });
                }
                else
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(files[i]))
                                ParseLogFile(null,files[i]);
                        }
                        catch (Exception err)
                        {
                            #region Handle Exception
                            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "ParseLogFile()",
                               String.Format("Internal Error: {0}", err.Message));
                            _synContext.Post(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Source Internal Error: {0}", err.Source));
                            _synContext.Post(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Detail Internal Error: {0}", err.StackTrace));
                            _synContext.Post(OnParseLog, logInfo);

                            #endregion
                        }
                    }
                }

               
            }
            else
                ParseLogFile(null,LogFile);
            
            return true;
                     
        }
        protected List<BaseLogAnalyzeFeature> ParseLogFile(List<BaseLogAnalyzeFeature> features,string logFile)
        {            
            using (StreamReader sr = new StreamReader(logFile))
            {
                string line = sr.ReadLine();

                #region Logging
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   ParserID,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "ParseLogFile()",
                   String.Format("Read File: {0}", logFile));
                _synContext.Post(OnParseLog, logInfo);

                Debug.WriteLine(String.Format("Read File: {0}", logFile));
                Debug.WriteLine(String.Format("Indihiang Read: {0}", line));
                #endregion

                try
                {
                    while (!string.IsNullOrEmpty(line))
                    {
                        Debug.WriteLine(String.Format("Read: {0}", line));
                        if (!ParseHeader(line))
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                string[] rows = line.Split(new char[] { ' ' });
                                if (rows != null)
                                {
                                    if (rows.Length > 0)
                                    {
                                        if (UseParallel)
                                        {
                                            foreach (var feature in features)
                                            {
                                                feature.Parse(_currentHeader, rows);
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < _features.Count; i++)
                                            {
                                                _features[i].Parse(_currentHeader, rows);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        line = sr.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            line = line.TrimEnd('\0');

                    }                    
                }
                catch (Exception err)
                {
                    #region Logging
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Internal Error on ParseLogFile: {0} is done", err.Message));
                    _synContext.Post(OnParseLog, logInfo);
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Detail: {0} is done", err.StackTrace));
                    _synContext.Post(OnParseLog, logInfo);
                    #endregion
                }

                #region Logging
                logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.SUCCESS,
                          "ParseLogFile()",
                          String.Format("Read File: {0} is done", logFile));
                _synContext.Post(OnParseLog, logInfo);
                #endregion
            }

            return features;

        }

        

        protected abstract bool ParseHeader(string line);
    }
}
