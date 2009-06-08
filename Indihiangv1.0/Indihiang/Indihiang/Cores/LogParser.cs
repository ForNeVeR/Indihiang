using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

using Indihiang.DomainObject;
using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public class LogParser
    {
        private SynchronizationContext _synContext;
        private string _fileName;
        private IISInfo _iisInfo = null;
        private BaseLogParser _parser;        
        private Thread _thread = null;

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
        public List<BaseLogAnalyzeFeature> Features
        {
            get
            {
                return this._parser.Features;
            }
        }
        public Guid LogParserId { get; private set; }
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
        public LogParser() 
        {
            LogParserId = Guid.NewGuid();            
            _synContext = AsyncOperationManager.SynchronizationContext;           
        }
        public LogParser(IISInfo info)
        {
            _iisInfo = info;
            LogParserId = Guid.NewGuid();
            _synContext = AsyncOperationManager.SynchronizationContext;
        } 

        public event EventHandler<LogInfoEventArgs> AnalyzeLogHandler;
        public event EventHandler<LogInfoEventArgs> EndAnalyzeHandler;

        public void Analyze()
        {
            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   "Starting..");            
            _synContext.Post(OnAnalyzeLog, logInfo);

            if (_iisInfo == null)
            {
                if (!Verify())
                    return;
            }
            else
            {
                _parser = LogParserFactory.CreateParserByType(EnumLogFile.W3CEXT);
                _parser.ParserID = _fileName;
            }

            _parser.ParseLogHandler += ParseLogHandler;

            if (_thread == null)
                _thread = new Thread(Process);

            _thread.IsBackground = true;            
            _thread.Start();
        }

        public void CancelAnalyze()
        {
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
                    catch (Exception) { }
                }
            }
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
            {
                #region
                logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "Process()",
                    "Copy remote web server log file into local...");

                _synContext.Post(OnAnalyzeLog, logInfo);
                #endregion

                RemoteFileCopyHelper.CopyRemoteFiles(_iisInfo);
                string sourceFiles = String.Format("{0}\\Temp\\{1}{2}\\", Environment.CurrentDirectory, _iisInfo.RemoteServer, _iisInfo.Id);

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


                #region logging
                logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "Process()",
                    "Copy remote web server log file into local is done");
                _synContext.Post(OnAnalyzeLog, logInfo);
                logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   string.Format("Total remote log files are {0} files", total.ToString()));
                _synContext.Post(OnAnalyzeLog, logInfo);
                #endregion

                if (total == 0)
                {
                    logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "Process()",
                    "No log file will be analyzed.");
                    _synContext.Post(OnEndAnalyze, logInfo);
                    Thread.Sleep(100);

                    return;
                }
            }

            PrepareFeatures();

            logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "Process()",
                    "Running log parser...");

            _synContext.Post(OnAnalyzeLog, logInfo);            

            _parser.Parse();
            logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   "Done");
            Thread.Sleep(100);
            _synContext.Post(OnEndAnalyze, logInfo);
        }

        private void PrepareFeatures()
        {
            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "PrepareFeatures()",
                    "Preparing log parser...");
            _synContext.Post(OnAnalyzeLog, logInfo);

            _parser.Features.Add(new GeneralFeature(_parser.LogFileFormat));
            _parser.Features.Add(new HitsFeature(_parser.LogFileFormat));
            _parser.Features.Add(new UserAgentFeature(_parser.LogFileFormat));
            _parser.Features.Add(new AccessPageFeature(_parser.LogFileFormat));
            _parser.Features.Add(new IPAddressFeature(_parser.LogFileFormat));
            _parser.Features.Add(new AccessStatusFeature(_parser.LogFileFormat));
            
            logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "PrepareFeatures()",
                   "Prepared parser features is done");
            _synContext.Post(OnAnalyzeLog, logInfo);
        }
        
        private bool CheckFile()
        {
            if (_fileName.StartsWith("--"))
            {
                List<string> files = IndihiangHelper.ParseFile(_fileName);

                for (int i = 0; i < files.Count; i++)
                    if (!string.IsNullOrEmpty(files[i]))
                        if (!File.Exists(files[i]))
                        {
                            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                                _fileName,
                                EnumLogFile.UNKNOWN,
                                LogProcessStatus.FAILED,
                                "LogParser.CheckFile()",
                                String.Format("{0} isn't found", files[i]));
                            this._synContext.Post(OnAnalyzeLog, logInfo);

                            return false;
                        }
            }
            else
                if (!File.Exists(_fileName))
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                        _fileName,
                        EnumLogFile.UNKNOWN,
                        LogProcessStatus.FAILED,
                        "LogParser.CheckFile()",
                        String.Format("{0} isn't found", _fileName));
                    this._synContext.Post(OnAnalyzeLog, logInfo);

                    return false;
                }

            return true;
        }
        private bool CheckParser()
        {
            _parser = LogParserFactory.CreateParser(_fileName);
            _parser.ParserID = _fileName;
            if (_parser == null)
            {
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                     _fileName,
                     EnumLogFile.UNKNOWN,
                     LogProcessStatus.FAILED,
                     "LogParser.Verify()",
                     "Application cannot verify log file format or there are more than log file format");
                this._synContext.Post(OnAnalyzeLog, logInfo);

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
    }
}
