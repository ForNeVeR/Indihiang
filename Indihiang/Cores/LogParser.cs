using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

using Indihiang.DomainObject;
namespace Indihiang.Cores
{
    public class LogParser
    {
        private bool useExistData;
        private string _logFilePath;
        private bool _useParallel;
        private SynchronizationContext _synContext;
        private string _fileName;
        private IISInfo _iisInfo;
        private BaseLogParser _parser;
        private Thread _thread;        
        private long _freq, _startTime, _endTime;
        

        public bool UseParallel
        {
            get
            {
                return _useParallel;
            }
            set
            {
                if (_useParallel == value)
                    return;
                _useParallel = value;
            }
        }
        public bool UseExistData
        {
            get
            {
                return useExistData;
            }
            set
            {
                if (useExistData == value)
                    return;
                useExistData = value;
            }
        }
        public double ProcessDuration
        {
            get
            {
                if (_freq == 0)
                    return -1;

                return (double)(_endTime - _startTime) / (double)_freq;
            }
        }
 
        public bool IsBusy
        {
            get
            {
                if (_thread != null)
                {
                    if (_thread.ThreadState == System.Threading.ThreadState.Stopped)
                        return false;
                }
                else
                    return false;

                return true;
            }
        }     
        public Guid LogParserId { get; set; }
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (_fileName == value)
                    return;
                _fileName = value;
            }
        }
        public string LogFilePath
        {
            get
            {
                return _logFilePath;
            }
            set
            {
                if (_logFilePath == value)
                    return;
                _logFilePath = value;
            }
        }
        public LogParser() 
        {
            useExistData = false;
            _startTime = 0;
            _endTime = 0;
            QueryPerformanceFrequency(ref _freq);

            //_featureQueue = new ConcurrentQueue<FeatureDataRow>();
            LogParserId = Guid.NewGuid();            
            _synContext = AsyncOperationManager.SynchronizationContext;           
        }
        public LogParser(IISInfo info)
        {
            _startTime = 0;
            _endTime = 0;
            QueryPerformanceFrequency(ref _freq);

            //_featureQueue = new ConcurrentQueue<FeatureDataRow>();
            _iisInfo = info;
            LogParserId = Guid.NewGuid();
            _synContext = AsyncOperationManager.SynchronizationContext;
        } 

        public event EventHandler<LogInfoEventArgs> AnalyzeLogHandler;
        public event EventHandler<LogInfoEventArgs> EndAnalyzeHandler;

        public void Analyze()
        {
            QueryPerformanceCounter(ref _startTime);

            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   LogParserId.ToString(),
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   "Starting..");
            _synContext.Post(OnAnalyzeLog, logInfo);

            if (_iisInfo == null)
            {
                if (!useExistData)
                {
                    if (!Verify())
                        return;
                }
                else
                    _parser = LogParserFactory.CreateParserByType(EnumLogFile.W3CEXT);

            }
            else
            {
                _parser = LogParserFactory.CreateParserByType(EnumLogFile.W3CEXT);
            }
            _parser.ParserID = LogParserId.ToString();
            _parser.ParseLogHandler += ParseLogHandler;
            _parser.UseParallel = _useParallel;

            if (useExistData)
                _logFilePath = Path.GetDirectoryName(_fileName);
            else
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                _logFilePath = String.Format("{0}\\Data\\{1}\\", path, LogParserId.ToString());
                if (!Directory.Exists(Path.GetDirectoryName(_logFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
            }

            //_finish = false;
            //if (_dataQueue == null)
            //    _dataQueue = new Thread(DumpData);
            if (_thread == null)
                _thread = new Thread(Process); // original
                //_thread = new Thread(ParseLog);

            _thread.IsBackground = true;
            _thread.Start();
        }

        public void CancelAnalyze()
        {
            //_finish = true;
            QueryPerformanceCounter(ref _endTime);
            if (_thread != null)
            {
                if (_thread.IsAlive)
                {
                    _thread.Join(1000);
                    try
                    {                        
                        if (_thread.IsAlive)
                            _thread.Abort();
                    }
                    catch { }
                }
            }
            
                        
        }
        public void StopTickCounter()
        {
            QueryPerformanceCounter(ref _endTime);
        }
        protected virtual void OnAnalyzeLog(LogInfoEventArgs e)
        {
            if (AnalyzeLogHandler != null)
                AnalyzeLogHandler(this, e);

            Debug.WriteLine(String.Format("Indihiang:: {0}", e.Message));
        }
        protected virtual void OnEndAnalyze(LogInfoEventArgs logInfo)
        {            
            Thread.Sleep(100);
            if (EndAnalyzeHandler != null)
                EndAnalyzeHandler(this, logInfo);

            Debug.WriteLine(String.Format("Indihiang:: {0}", logInfo.Message));
        }

        private void ParseLogHandler(object sender, LogInfoEventArgs e)
        {            
            _synContext.Post(OnAnalyzeLog, e);
        }
      
        private void Process()
        {
            Thread.Sleep(100);
            LogInfoEventArgs logInfo = null;

            if (_iisInfo != null)
                LogFileProcessing();

            logInfo = new LogInfoEventArgs(
                        LogParserId.ToString(),
                        EnumLogFile.UNKNOWN,
                        LogProcessStatus.SUCCESS,
                        "Process()",
                        "Running log parser...");

            _synContext.Post(OnAnalyzeLog, logInfo);

            if (!useExistData)
            {
                if (_fileName.StartsWith("--"))
                    _parser.LogFile = _fileName;
                _parser.Parse();
            }
                       
            logInfo = new LogInfoEventArgs(
                   LogParserId.ToString(),
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   "Done");            
            Thread.Sleep(100);
            _synContext.Post(OnEndAnalyze, logInfo);
        }

        private void LogFileProcessing()
        {
            LogInfoEventArgs logInfo;
            string message = string.Empty;

            if (_iisInfo.LocalComputer)
                message = "Checking log files...";
            else
                message = "Copy remote web server log file into local...";

            #region Logging
            logInfo = new LogInfoEventArgs(
                LogParserId.ToString(),
                EnumLogFile.UNKNOWN,
                LogProcessStatus.SUCCESS,
                "Process()",
                message);

            _synContext.Post(OnAnalyzeLog, logInfo);
            #endregion

            string sourceFiles = string.Empty;

            if (!_iisInfo.LocalComputer)
            {
                RemoteFileCopyHelper.CopyRemoteFiles(_iisInfo);
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                sourceFiles = String.Format("{0}\\Temp\\{1}{2}\\", path, _iisInfo.RemoteServer, _iisInfo.Id);
            }
            else
                sourceFiles = String.Format("{0}\\W3SVC{1}\\", _iisInfo.LogPath, _iisInfo.Id);

            int total = 0;
            string[] files = Directory.GetFiles(sourceFiles);

            if (files != null)
            {
                total = files.Length;
                string file = "--";
                for (int i = 0; i < files.Length; i++)
                {
                    file = String.Format("{0}{1};", file, files[i]);
                }

                _parser.LogFile = file;
            }


            if (_iisInfo.LocalComputer)
                message = "Check log files was done";
            else
                message = "Copy remote web server log files into local was done";

            #region logging
            logInfo = new LogInfoEventArgs(
                LogParserId.ToString(),
                EnumLogFile.UNKNOWN,
                LogProcessStatus.SUCCESS,
                "Process()",
                message);
            _synContext.Post(OnAnalyzeLog, logInfo);
            logInfo = new LogInfoEventArgs(
               LogParserId.ToString(),
               EnumLogFile.UNKNOWN,
               LogProcessStatus.SUCCESS,
               "Process()",
               string.Format("Total remote log files are {0} files", total.ToString()));
            _synContext.Post(OnAnalyzeLog, logInfo);
            #endregion


            if (total == 0)
            {
                logInfo = new LogInfoEventArgs(
                LogParserId.ToString(),
                EnumLogFile.UNKNOWN,
                LogProcessStatus.SUCCESS,
                "Process()",
                "No log file will be analyzed.");
                _synContext.Post(OnEndAnalyze, logInfo);
                Thread.Sleep(100);

                return;
            }

        }

        private bool CheckFile()
        {
            if (_fileName.StartsWith("--"))
            {
                List<string> files = IndihiangHelper.ParseFile(_fileName);

                LogInfoEventArgs logInfo = null;
                for (int i = 0; i < files.Count; i++)
                    if (!string.IsNullOrEmpty(files[i]))
                        if (!File.Exists(files[i]))
                        {
                            logInfo = new LogInfoEventArgs(
                                LogParserId.ToString(),
                                EnumLogFile.UNKNOWN,
                                LogProcessStatus.FAILED,
                                "LogParser.CheckFile()",
                                String.Format("{0} isn't found", files[i]));
                            _synContext.Post(OnAnalyzeLog, logInfo);

                            return false;
                        }

                logInfo = new LogInfoEventArgs(
                   LogParserId.ToString(),
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   string.Format("Total log files are {0} files", files.Count.ToString()));
                _synContext.Post(OnAnalyzeLog, logInfo);


            }
            else
                if (!File.Exists(_fileName))
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                        LogParserId.ToString(),
                        EnumLogFile.UNKNOWN,
                        LogProcessStatus.FAILED,
                        "LogParser.CheckFile()",
                        String.Format("{0} isn't found", _fileName));
                    _synContext.Post(OnAnalyzeLog, logInfo);

                    return false;
                }

            return true;
        }
        private bool CheckParser()
        {
            _parser = LogParserFactory.CreateParser(_fileName);
            _parser.LogFile = _fileName;
            _parser.ParserID = LogParserId.ToString();
            if (_parser == null)
            {
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                     LogParserId.ToString(),
                     EnumLogFile.UNKNOWN,
                     LogProcessStatus.FAILED,
                     "LogParser.Verify()",
                     "Application cannot verify log file format or there are more than log file format");
                _synContext.Post(OnAnalyzeLog, logInfo);

                return false;
            }

            return true;
        }
        private bool Verify()
        {
            if (!CheckFile())
                return false;
            if (!CheckParser())
                return false;            

            return true;
        }


        /// <summary>
        /// Take from http://support.microsoft.com/kb/306979/EN-US/
        /// </summary>
        /// <param name="counter"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long counter);
        [DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long freq);


    }
}
