using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {
        protected SpinLock _spinLock;
        protected List<BaseLogAnalyzeFeature> _features;
        protected List<BaseLogAnalyzeFeature> _paralleFeatures;
        private SynchronizationContext _synContext;
        private LazyInit<TaskManager> _taskManager;
        private Task _mainTask;

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
        public bool isCompleted
        {
            get
            {
                if (_mainTask == null)
                    return true;

                return _mainTask.IsCompleted;
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
            LogFile = logFile;
            LogFileFormat = logFileFormat;

            Initilaize();           
        }

        private void Initilaize()
        {
            _spinLock = new SpinLock();
            _features = new List<BaseLogAnalyzeFeature>();
            _paralleFeatures = new List<BaseLogAnalyzeFeature>();
            _synContext = AsyncOperationManager.SynchronizationContext;

            _taskManager = new LazyInit<TaskManager>(() => new TaskManager(
                              new TaskManagerPolicy(1, Environment.ProcessorCount)),
                              LazyInitMode.AllowMultipleExecution);
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
                List<string> listFiles = new List<string>();
                for (int i = 0; i < files.Length; i++)
                {
                    if (!string.IsNullOrEmpty(files[i]))
                        listFiles.Add(files[i]);
                }

                if (UseParallel)
                {
                    #region Parallel Processing

                    try
                    {
                        var resultData = new Future<List<BaseLogAnalyzeFeature>>[listFiles.Count];
                        _mainTask = Task.Create(
                                delegate
                                {
                                    Parallel.For(0, listFiles.Count, index =>
                                        {
                                            List<BaseLogAnalyzeFeature> features = IndihiangHelper.GenerateParallelFeatures(LogFileFormat);
                                            resultData[index] = Future.Create(
                                                   () => ParseLogFile(features, listFiles[index])
                                                );
                                            resultData[index].Wait(-1);
                                        });
     
                                },
                                _taskManager.Value,
                                TaskCreationOptions.None
                             );

                        _mainTask.Wait(-1);
                        for (int i = 0; i < resultData.Length; i++)
                        {
                            List<BaseLogAnalyzeFeature> items = resultData[i].Value;
                            items.ForEach(delegate(BaseLogAnalyzeFeature item)
                            {
                                for (int j = 0; j < _paralleFeatures.Count; j++)
                                    if (_paralleFeatures[j].FeatureName == item.FeatureName)
                                        _paralleFeatures[j].SynchData(item.Items);
                            });

                            items.Clear();
                            resultData[i].Dispose();
                        }
                        Thread.Sleep(100);

                    }
                    catch (AggregateException err)
                    {
                        #region Handle Exception
                        LogInfoEventArgs logInfo = new LogInfoEventArgs(
                           ParserID,
                           EnumLogFile.UNKNOWN,
                           LogProcessStatus.SUCCESS,
                           "Parse()",
                           String.Format("Internal Error: {0}", err.Message));
                        _synContext.Send(OnParseLog, logInfo);
                        logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "Parse()",
                               String.Format("Source Internal Error: {0}", err.Source));
                        _synContext.Send(OnParseLog, logInfo);
                        logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "Parse()",
                               String.Format("Detail Internal Error: {0}", err.StackTrace));
                        _synContext.Send(OnParseLog, logInfo);

                        #endregion

                    }
                    catch (Exception err)
                    {
                        #region Handle Exception
                        LogInfoEventArgs logInfo = new LogInfoEventArgs(
                           ParserID,
                           EnumLogFile.UNKNOWN,
                           LogProcessStatus.SUCCESS,
                           "Parse()",
                           String.Format("Internal Error: {0}", err.Message));
                        _synContext.Send(OnParseLog, logInfo);
                        logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "Parse()",
                               String.Format("Source Internal Error: {0}", err.Source));
                        _synContext.Send(OnParseLog, logInfo);
                        logInfo = new LogInfoEventArgs(
                               ParserID,
                               EnumLogFile.UNKNOWN,
                               LogProcessStatus.SUCCESS,
                               "Parse()",
                               String.Format("Detail Internal Error: {0}", err.StackTrace));
                        _synContext.Send(OnParseLog, logInfo);

                        #endregion

                    }

                    #endregion

                }
                else
                {
                    #region Non Parallel Processing
                    for (int i = 0; i < files.Length; i++)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(files[i]))
                                ParseLogFile(_features, files[i]);
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
                            _synContext.Send(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Source Internal Error: {0}", err.Source));
                            _synContext.Send(OnParseLog, logInfo);
                            logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "ParseLogFile()",
                                   String.Format("Detail Internal Error: {0}", err.StackTrace));
                            _synContext.Send(OnParseLog, logInfo);

                            #endregion
                        }
                    }
                    #endregion

                }


            }
            else
            {
                if (UseParallel)
                    ParseLogFile(_paralleFeatures, LogFile);
                else
                    ParseLogFile(_features, LogFile);
            }
            
            return true;
                     
        }
        protected List<BaseLogAnalyzeFeature> ParseLogFile(List<BaseLogAnalyzeFeature> features,string logFile)
        {
            if (features == null)
                return null;

            using (StreamReader sr = new StreamReader(logFile))
            {
                #region Logging
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   ParserID,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "ParseLogFile()",
                   String.Format("Read File: {0}", logFile));
                _synContext.Send(OnParseLog, logInfo);

                Debug.WriteLine(String.Format("Read File: {0}", logFile));
                
                #endregion

                try
                {
                    string line = sr.ReadLine();
                    Debug.WriteLine(String.Format("Indihiang Read: {0}", line));

                    List<string> currentHeader = new List<string>();
                    while (!string.IsNullOrEmpty(line))
                    {
                        Debug.WriteLine(String.Format("Read: {0}", line));
                        if (IsLogHeader(line))
                        {
                            List<string> list1 = ParseHeader(line);
                            if (list1 != null)
                                currentHeader = new List<string>(list1);
                        }
                        else
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
                                                feature.Parse(currentHeader, rows);
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < _features.Count; i++)
                                            {
                                                _features[i].Parse(currentHeader, rows);
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
                catch (ArgumentOutOfRangeException err)
                {
                    #region Logging
                    System.Diagnostics.Debug.WriteLine(err.Message);
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Internal Error on ParseLogFile: {0}", err.Message));
                    _synContext.Send(OnParseLog, logInfo);
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Detail: {0} ", err.StackTrace));
                    _synContext.Send(OnParseLog, logInfo);
                    #endregion
                }
                catch (Exception err)
                {
                    #region Logging
                    System.Diagnostics.Debug.WriteLine(err.Message);
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Internal Error on ParseLogFile: {0}", err.Message));
                    _synContext.Send(OnParseLog, logInfo);
                    logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.FAILED,
                          "ParseLogFile()",
                          String.Format("Detail: {0} ", err.StackTrace));
                    _synContext.Send(OnParseLog, logInfo);
                    #endregion
                }

                #region Logging
                logInfo = new LogInfoEventArgs(
                          ParserID,
                          EnumLogFile.UNKNOWN,
                          LogProcessStatus.SUCCESS,
                          "ParseLogFile()",
                          String.Format("Read File: {0} is done", logFile));
                _synContext.Send(OnParseLog, logInfo);
                #endregion
            }

            return features;

        }


        protected abstract bool IsLogHeader(string line);
        protected abstract List<string> ParseHeader(string line);
    }
}
