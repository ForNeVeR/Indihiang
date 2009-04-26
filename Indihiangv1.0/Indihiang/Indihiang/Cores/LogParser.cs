﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public class LogParser
    {
        private SynchronizationContext _synContext;
        private Guid _logParserId;
        private string _fileName;
        private BaseLogParser _parser;        
        private Thread _thread = null;

        public List<BaseLogAnalyzeFeature> Features
        {
            get
            {
                return this._parser.Features;
            }
        }
        public Guid LogParserId
        {
            get
            {
                return _logParserId;
            }            
        }
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
            _logParserId = Guid.NewGuid();            
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
            this._synContext.Post(OnAnalyzeLog, logInfo);

            if (!Verify())
                return;

            _parser.ParseLogHandler += new EventHandler<LogInfoEventArgs>(ParseLogHandler);

            if (_thread == null)
                _thread = new Thread(new ThreadStart(Process));

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
            if (this.AnalyzeLogHandler != null)
                this.AnalyzeLogHandler(this, e);

            Debug.WriteLine("Indihiang:: " + e.Message);
        }
        protected virtual void OnEndAnalyze(LogInfoEventArgs logInfo)
        {
            Thread.Sleep(100);
            if (this.EndAnalyzeHandler != null)
                this.EndAnalyzeHandler(this, logInfo);

            Debug.WriteLine("Indihiang:: " + logInfo.Message);
        }

        private void ParseLogHandler(object sender, LogInfoEventArgs e)
        {
            this._synContext.Post(OnAnalyzeLog, e);
        }

        private void Process()
        {
            Thread.Sleep(100);
            PrepareFeatures();

            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "Process()",
                    "Running log parser...");

            this._synContext.Post(OnAnalyzeLog, logInfo);
           
            _parser.Parse();
            logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "Process()",
                   "Done");
            Thread.Sleep(100);
            this._synContext.Post(OnEndAnalyze, logInfo);
        }

        private void PrepareFeatures()
        {
            LogInfoEventArgs logInfo = new LogInfoEventArgs(
                    _fileName,
                    EnumLogFile.UNKNOWN,
                    LogProcessStatus.SUCCESS,
                    "PrepareFeatures()",
                    "Preparing log parser...");
            this._synContext.Post(OnAnalyzeLog, logInfo);

            this._parser.Features.Add(new GeneralFeature(_parser.LogFileFormat));
            this._parser.Features.Add(new HitsFeature(_parser.LogFileFormat));
            this._parser.Features.Add(new UserAgentFeature(_parser.LogFileFormat));
            this._parser.Features.Add(new AccessPageFeature(_parser.LogFileFormat));
            this._parser.Features.Add(new IPAddressFeature(_parser.LogFileFormat));
            this._parser.Features.Add(new AccessStatusFeature(_parser.LogFileFormat));
            
            logInfo = new LogInfoEventArgs(
                   _fileName,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "PrepareFeatures()",
                   "Prepared parser features is done");
            this._synContext.Post(OnAnalyzeLog, logInfo);
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
                                files[i] + " isn't found");
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
                        _fileName + " isn't found");
                    this._synContext.Post(OnAnalyzeLog, logInfo);

                    return false;
                }

            return true;
        }
        private bool CheckParser()
        {
            _parser = LogParserFactory.CreateParser(_fileName);
            if (_parser == null)
            {
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                     _fileName,
                     EnumLogFile.UNKNOWN,
                     LogProcessStatus.FAILED,
                     "LogParser.Verify()",
                     "Application cannot verify log file format");
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
