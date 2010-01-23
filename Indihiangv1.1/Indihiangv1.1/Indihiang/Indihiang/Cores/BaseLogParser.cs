using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Collections;

using Indihiang.Data;
using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {

        protected List<BaseLogAnalyzeFeature> _features;
        protected List<BaseLogAnalyzeFeature> _paralleFeatures;
        private SynchronizationContext _synContext;
        private LazyInit<TaskManager> _taskManager;
        //private Task _mainTask;
        private ConcurrentQueue<FeatureDataRow> _featureQueue;
        //private ConcurrentQueue<DumpLogData> _dumpLogQueue;
        private ConcurrentQueue<List<Indihiang.DomainObject.DumpData>> _dumpLogQueue;
        //List<Indihiang.DomainObject.DumpData>
        private Thread _dataQueue;
        private bool _finish;
        private ManualResetEventSlim _exitDump;


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
            LogFile = logFile;
            LogFileFormat = logFileFormat;

            Initilaize();           
        }

        private void Initilaize()
        {
            //_spinLock = new SpinLock();
            _features = new List<BaseLogAnalyzeFeature>();
            _paralleFeatures = new List<BaseLogAnalyzeFeature>();
            _synContext = AsyncOperationManager.SynchronizationContext;

            _taskManager = new LazyInit<TaskManager>(() => new TaskManager(
                              new TaskManagerPolicy(1, Environment.ProcessorCount)),
                              LazyInitMode.AllowMultipleExecution);

            _featureQueue = new ConcurrentQueue<FeatureDataRow>();
            //_dumpLogQueue = new ConcurrentQueue<DumpLogData>();
            _dumpLogQueue = new ConcurrentQueue<List<Indihiang.DomainObject.DumpData>>();
        }

        protected virtual void OnParseLog(LogInfoEventArgs e)
        {
            if (ParseLogHandler != null)
                ParseLogHandler(this, e);

            Debug.WriteLine(String.Format("OnParseLog:: {0}", e.Message));
        }

        public bool Parse()
        {
            bool success = false;
            if (LogFile.StartsWith("--"))
            {
                if (_dataQueue == null)
                    _dataQueue = new Thread(DumpData);
                
                _finish = false;
                _dataQueue.IsBackground = true;
                _dataQueue.Start();

                string tmp = LogFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });
                List<string> listFiles = new List<string>();
                for (int i = 0; i < files.Length; i++)
                {
                    if (!string.IsNullOrEmpty(files[i]))
                        if (!listFiles.Contains(files[i].ToLower().Trim()))
                            listFiles.Add(files[i].ToLower().Trim());
                }

                success = ParallelParse(success, listFiles);
            }
            else
            {
                ParseLogFile(_paralleFeatures, LogFile);
            }
            _finish = true;
            Thread.Sleep(100);
            ExitDumpThread();

            return success;
        }

        //private bool NonParallelParse(bool success, List<string> listFiles, Dictionary<string, List<BaseLogAnalyzeFeature>> resultData)
        //{
        //    for (int i = 0; i < listFiles.Count; i++)
        //    {
        //        try
        //        {


        //            if (!string.IsNullOrEmpty(listFiles[i]))
        //            {
        //                List<BaseLogAnalyzeFeature> features = IndihiangHelper.GenerateFeatures(LogFileFormat);
        //                resultData.Add(listFiles[i], ParseLogFile(features, listFiles[i]));
        //                //resultData.Add(listFiles[i], ParseLogFile(_features, listFiles[i]));
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            #region Handle Exception
        //            LogInfoEventArgs logInfo = new LogInfoEventArgs(
        //               ParserID,
        //               EnumLogFile.UNKNOWN,
        //               LogProcessStatus.SUCCESS,
        //               "ParseLogFile()",
        //               String.Format("Internal Error: {0}", err.Message));
        //            _synContext.Post(OnParseLog, logInfo);
        //            logInfo = new LogInfoEventArgs(
        //                   ParserID,
        //                   EnumLogFile.UNKNOWN,
        //                   LogProcessStatus.SUCCESS,
        //                   "ParseLogFile()",
        //                   String.Format("Source Internal Error: {0}", err.Source));
        //            _synContext.Post(OnParseLog, logInfo);
        //            logInfo = new LogInfoEventArgs(
        //                   ParserID,
        //                   EnumLogFile.UNKNOWN,
        //                   LogProcessStatus.SUCCESS,
        //                   "ParseLogFile()",
        //                   String.Format("Detail Internal Error: {0}", err.StackTrace));
        //            _synContext.Post(OnParseLog, logInfo);

        //            #endregion
        //        }
        //    }
        //    success = true;
        //    return success;
        //}

        private bool ParallelParse(bool success, List<string> listFiles)
        {
            try
            {
                List<ManualResetEventSlim> resets = new List<ManualResetEventSlim>();
                _exitDump = new ManualResetEventSlim(false);

                int i = 0;                
                Parallel.ForEach<string>(listFiles, file =>
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Run Parse on file {0}", file));
                    _synContext.Post(OnParseLog, logInfo);


                    ManualResetEventSlim obj = new ManualResetEventSlim(false);
                    resets.Add(obj);
                    try
                    {
                        RunParse(file);

                        logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Run Parse : {0} was done", file));
                        _synContext.Post(OnParseLog, logInfo);
                    }
                    catch (Exception err)
                    {
                        logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Error occurred on file {0}==>{1}\r\n{2}", file, err.Message, err.StackTrace));
                        _synContext.Post(OnParseLog, logInfo);
                    }
                    obj.Set();



                });


                try
                {
                    for (i = 0; i < resets.Count; i++)
                    {
                        if (!resets[i].IsSet)
                            resets[i].Wait();
                    }
                }
                catch { }                
                _finish = true;

                LogInfoEventArgs logInfo2 = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   "Consolidating log files...");
                _synContext.Post(OnParseLog, logInfo2);

                try
                {
                    if (!_exitDump.IsSet)
                        _exitDump.Wait();
                }
                catch { }

                logInfo2 = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   "Consolidated log file was done");
                _synContext.Post(OnParseLog, logInfo2);

                Thread.Sleep(100);
                success = true;

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
                _synContext.Post(OnParseLog, logInfo);
                logInfo = new LogInfoEventArgs(
                       ParserID,
                       EnumLogFile.UNKNOWN,
                       LogProcessStatus.SUCCESS,
                       "Parse()",
                       String.Format("Source Internal Error: {0}", err.Source));
                _synContext.Post(OnParseLog, logInfo);
                logInfo = new LogInfoEventArgs(
                       ParserID,
                       EnumLogFile.UNKNOWN,
                       LogProcessStatus.SUCCESS,
                       "Parse()",
                       String.Format("Detail Internal Error: {0}", err.StackTrace));
                _synContext.Post(OnParseLog, logInfo);
                logInfo = new LogInfoEventArgs(
                       ParserID,
                       EnumLogFile.UNKNOWN,
                       LogProcessStatus.SUCCESS,
                       "Parse()",
                       String.Format("Internal Exception Error: {0}", err.InnerException.Message));
                _synContext.Post(OnParseLog, logInfo);

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
                _synContext.Post(OnParseLog, logInfo);
                logInfo = new LogInfoEventArgs(
                       ParserID,
                       EnumLogFile.UNKNOWN,
                       LogProcessStatus.SUCCESS,
                       "Parse()",
                       String.Format("Source Internal Error: {0}", err.Source));
                _synContext.Post(OnParseLog, logInfo);
                logInfo = new LogInfoEventArgs(
                       ParserID,
                       EnumLogFile.UNKNOWN,
                       LogProcessStatus.SUCCESS,
                       "Parse()",
                       String.Format("Detail Internal Error: {0}", err.StackTrace));
                _synContext.Post(OnParseLog, logInfo);

                #endregion

            }
            return success;
        }

        private void ExitDumpThread()
        {
            if (_dataQueue != null)
            {
                if (_dataQueue.IsAlive)
                {
                    _dataQueue.Join(1000);
                    try
                    {
                        if (_dataQueue.IsAlive)
                            _dataQueue.Abort();
                    }
                    catch{ }
                }
            }
        }
        private void DumpData()
        {
            List<Indihiang.DomainObject.DumpData> listDump;
            while (!_finish)
            {                
                try
                {
                    if (_dumpLogQueue.TryDequeue(out listDump))
                    {
                        PerformDump(listDump);
                        listDump.Clear();
                    }
                    else
                        Thread.Sleep(10);
                }
                catch(Exception err) 
                {
                    Debug.WriteLine(err.Message);
                }
            }
            if (!_dumpLogQueue.IsEmpty)
            {
                Debug.WriteLine(string.Format("Total remain data: {0}",_dumpLogQueue.Count));
                List<Indihiang.DomainObject.DumpData>[] list = _dumpLogQueue.ToArray();
                for (int i = 0; i < list.Length; i++)
                {
                    Debug.WriteLine(string.Format("Dump data: {0}:{1}", i+1,_dumpLogQueue.Count));
                    PerformDump(list[i]);
                }
            }
            _exitDump.Set();
        }

        private void PerformDump(List<Indihiang.DomainObject.DumpData> listDump)
        {
            if (listDump.Count>0)
            {
                string file = string.Empty;
                DataHelper helper = null;

                file = IndihiangHelper.GetIndihiangFile(listDump[0].Year.ToString(), ParserID);
                if (!File.Exists(file))
                {
                    IndihiangHelper.CopyLogDB(file);
                    helper = new DataHelper(file);
                }
                else
                    helper = new DataHelper(file);

                helper.InsertBulkDumpData(listDump);
            }
        }



        protected List<BaseLogAnalyzeFeature> ParseLogFile(List<BaseLogAnalyzeFeature> features,string logFile)
        {
            if (features == null)
                return null;

            //if (UseParallel)
            //{
                #region Logging
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                   ParserID,
                   EnumLogFile.UNKNOWN,
                   LogProcessStatus.SUCCESS,
                   "ParseLogFile()",
                   String.Format("Read File: {0}", logFile));
                _synContext.Post(OnParseLog, logInfo);

                Debug.WriteLine(String.Format("Read File: {0}", logFile));
                #endregion

                foreach (var feature in features)
                {
                    using (StreamReader sr = new StreamReader(logFile))
                    {                       
                        //try
                        //{

                            string line = sr.ReadLine();
                            //Debug.WriteLine(String.Format("Indihiang Read: {0}", line));

                            List<string> currentHeader = new List<string>();
                            while (!string.IsNullOrEmpty(line))
                            {
                                //Debug.WriteLine(String.Format("Read: {0}", line));
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
                                                feature.Parse(currentHeader, rows);
                                            }
                                        }
                                    }
                                }

                                line = sr.ReadLine();
                                if (!string.IsNullOrEmpty(line))
                                    line = line.Trim();
                                //if (!string.IsNullOrEmpty(line))
                                //    line = line.TrimEnd('\0');

                            }

                        //}
                        //catch (AggregateException err)
                        //{
                        //    #region Handle Exception
                        //    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                        //       ParserID,
                        //       EnumLogFile.UNKNOWN,
                        //       LogProcessStatus.SUCCESS,
                        //       "Parse()",
                        //       String.Format("Internal Error: {0}", err.Message));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    logInfo = new LogInfoEventArgs(
                        //           ParserID,
                        //           EnumLogFile.UNKNOWN,
                        //           LogProcessStatus.SUCCESS,
                        //           "Parse()",
                        //           String.Format("Source Internal Error: {0}", err.Source));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    logInfo = new LogInfoEventArgs(
                        //           ParserID,
                        //           EnumLogFile.UNKNOWN,
                        //           LogProcessStatus.SUCCESS,
                        //           "Parse()",
                        //           String.Format("Detail Internal Error: {0}", err.StackTrace));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    logInfo = new LogInfoEventArgs(
                        //           ParserID,
                        //           EnumLogFile.UNKNOWN,
                        //           LogProcessStatus.SUCCESS,
                        //           "Parse()",
                        //           String.Format("Internal Exception Error: {0}", err.InnerException.Message));
                        //    _synContext.Post(OnParseLog, logInfo);

                        //    #endregion

                        //}
                        //catch (ArgumentOutOfRangeException err)
                        //{
                        //    #region Logging
                        //    System.Diagnostics.Debug.WriteLine(err.Message);
                        //    logInfo = new LogInfoEventArgs(
                        //          ParserID,
                        //          EnumLogFile.UNKNOWN,
                        //          LogProcessStatus.FAILED,
                        //          "ParseLogFile()",
                        //          String.Format("Internal Error on ParseLogFile: {0}", err.Message));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    logInfo = new LogInfoEventArgs(
                        //          ParserID,
                        //          EnumLogFile.UNKNOWN,
                        //          LogProcessStatus.FAILED,
                        //          "ParseLogFile()",
                        //          String.Format("Detail: {0} ", err.StackTrace));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    #endregion
                        //}
                        //catch (Exception err)
                        //{
                        //    #region Logging
                        //    System.Diagnostics.Debug.WriteLine(err.Message);
                        //    logInfo = new LogInfoEventArgs(
                        //          ParserID,
                        //          EnumLogFile.UNKNOWN,
                        //          LogProcessStatus.FAILED,
                        //          "ParseLogFile()",
                        //          String.Format("Internal Error on ParseLogFile: {0}", err.Message));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    logInfo = new LogInfoEventArgs(
                        //          ParserID,
                        //          EnumLogFile.UNKNOWN,
                        //          LogProcessStatus.FAILED,
                        //          "ParseLogFile()",
                        //          String.Format("Detail: {0} ", err.StackTrace));
                        //    _synContext.Post(OnParseLog, logInfo);
                        //    #endregion
                        //}
                       
                    }                    
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
            //}

            return features;

        }

        //protected void RunParse(BaseLogAnalyzeFeature feature, string logFile)
        //{
        //    if (feature == null)
        //        return;


        //    Dictionary<string, List<string>> dictRows = new Dictionary<string, List<string>>();
        //    using (StreamReader sr = new StreamReader(File.Open(logFile,FileMode.Open,FileAccess.Read,FileShare.Read)))
        //    {               
        //        string line = sr.ReadLine();

        //        List<string> currentHeader = new List<string>();
        //        while (!string.IsNullOrEmpty(line))
        //        {
        //            if (IsLogHeader(line))
        //            {
        //                List<string> list1 = ParseHeader(line);
        //                if (list1 != null)
        //                    currentHeader = new List<string>(list1);
        //            }
        //            else
        //            {
        //                if (!string.IsNullOrEmpty(line))
        //                {
        //                    string[] rows = line.Split(new char[] { ' ' });
        //                    if (rows != null)
        //                    {
        //                        if (rows.Length > 0)
        //                        {
        //                            dictRows.Add(Guid.NewGuid().ToString(), new List<string>(rows));                                    
        //                        }
        //                    }
        //                }
        //            }

        //            line = sr.ReadLine();
        //            if (!string.IsNullOrEmpty(line))
        //                line = line.Trim();
        //        }
        //    }
        //}

        protected void RunParse(string logFile)
        {
            List<Indihiang.DomainObject.DumpData> listDump = new List<Indihiang.DomainObject.DumpData>();
            using (StreamReader sr = new StreamReader(File.Open(logFile, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                string line = sr.ReadLine();

                List<string> currentHeader = new List<string>();
                while (!string.IsNullOrEmpty(line))
                {
                    if (IsLogHeader(line))
                    {
                        #region Parse Header
                        List<string> list1 = ParseHeader(line);
                        if (list1 != null)
                        {
                            currentHeader = new List<string>(list1);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Parse Data
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] rows = line.Split(new char[] { ' ' });
                            if (rows != null)
                            {
                                if (rows.Length > 0)
                                {
                                    string val = string.Empty;
                                    Indihiang.DomainObject.DumpData dump = new Indihiang.DomainObject.DumpData();
                                    dump.FullFileName = logFile;
                                    for (int i = 0; i < currentHeader.Count; i++)
                                    {
                                        if (currentHeader[i].Equals("date"))
                                        {
                                            val = rows[i];
                                            DateTime datetime = DateTime.Parse(val);
                                            dump.Day = datetime.Day;
                                            dump.Month = datetime.Month;
                                            dump.Year = datetime.Year;
                                        }
                                        if (currentHeader[i].Equals("s-ip"))
                                            dump.Server_IP = rows[i];
                                        if (currentHeader[i].Equals("s-port"))
                                            dump.Server_Port = rows[i];
                                        if (currentHeader[i].Equals("cs-uri-stem"))
                                            dump.Page_Access = rows[i];
                                        if (currentHeader[i].Equals("cs-uri-query"))
                                            dump.Query_Page_Access = rows[i];
                                        if (currentHeader[i].Equals("cs-username"))
                                            dump.Access_Username = rows[i];
                                        if (currentHeader[i].Equals("c-ip"))
                                        {
                                            dump.Client_IP = rows[i];
                                        }
                                        if (currentHeader[i].Equals("cs(User-Agent)"))
                                            dump.User_Agent = IndihiangHelper.CheckUserAgent(rows[i]);
                                        if (currentHeader[i].Equals("sc-status"))
                                        {
                                            if (dump.Protocol_Status.Contains("."))
                                                dump.Protocol_Status = string.Format("{0}{1}", rows[i], dump.Protocol_Status);
                                            else
                                                dump.Protocol_Status = rows[i];
                                        }
                                        if (currentHeader[i].Equals("sc-substatus"))
                                            dump.Protocol_Status = string.Format("{0}.{1}", dump.Protocol_Status, rows[i]);

                                        if (currentHeader[i].Equals("cs(Referer)"))
                                            dump.Referer = rows[i];
                                        if (currentHeader[i].Equals("sc-bytes"))
                                            dump.Bytes_Sent = rows[i];
                                        if (currentHeader[i].Equals("cs-bytes"))
                                            dump.Bytes_Received = rows[i];
                                    }

                                    listDump.Add(dump);
                                }
                            }
                        }
                        #endregion
                    }

                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                        line = line.Trim();
                }
                if (listDump.Count > 0)
                    _dumpLogQueue.Enqueue(listDump);

            }
        }

        


        protected abstract bool IsLogHeader(string line);
        protected abstract List<string> ParseHeader(string line);
    }
}
