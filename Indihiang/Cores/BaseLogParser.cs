using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Indihiang.Data;
namespace Indihiang.Cores
{
    public abstract class BaseLogParser
    {

        private SynchronizationContext _synContext;
        private ConcurrentQueue<List<Indihiang.DomainObject.DumpData>> _dumpLogQueue;
        private Thread _dataQueue;
        private bool _finish;
        private bool _allDone;
        private ManualResetEventSlim _exitDump;


        public event EventHandler<LogInfoEventArgs> ParseLogHandler;

        public string LogFile { get; set; }
        public string ParserID { get; set; }
        public EnumLogFile LogFileFormat { get; protected set; }
        public bool UseParallel { get; set; }

        protected BaseLogParser(string logFile, EnumLogFile logFileFormat)
        {
            LogFile = logFile;
            LogFileFormat = logFileFormat;

            Initilaize();
        }

        private void Initilaize()
        {
            _synContext = AsyncOperationManager.SynchronizationContext;
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
            //if (_dataQueue == null)
            //    _dataQueue = new Thread(DumpData);

            _allDone = false;
            _finish = false;
            //_dataQueue.IsBackground = true;
            //_dataQueue.Start();

            List<string> listFiles = new List<string>();
            if (LogFile.StartsWith("--"))
            {
                string tmp = LogFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });
                for (int i = 0; i < files.Length; i++)
                {
                    if (!string.IsNullOrEmpty(files[i]))
                        if (!listFiles.Contains(files[i].ToLower().Trim()))
                            listFiles.Add(files[i].ToLower().Trim());
                }
            }
            else
            {
                listFiles.Add(LogFile.ToLower().Trim());
            }

            success = SequentialParse(success, listFiles);//ParallelParse(success, listFiles);

            _finish = true;
            Thread.Sleep(100);
            //ExitDumpThread();

            return success;
        }

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
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

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
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

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

        private bool SequentialParse(bool success, List<string> listFiles)
        {
            try
            {
                //List<ManualResetEventSlim> resets = new List<ManualResetEventSlim>();
                //_exitDump = new ManualResetEventSlim(false);

                DataHelper helper = new DataHelper(IndihiangHelper.GetIPCountryDb());
                List<Indihiang.DomainObject.IPCountry> listIpCountry = helper.GetAllIpCountry();

                Dictionary<string, string> cacheIpCountry = new Dictionary<string, string>();
                cacheIpCountry.Add("127.0.0.1", "(Local)");

                for (int i = 0; i < listFiles.Count; i++)
                {
                    LogInfoEventArgs logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Run Parse on file {0}", listFiles[i]));
                    _synContext.Post(OnParseLog, logInfo);

                    try
                    {
                        RunParse(listFiles[i]);
                        DumpPartial(listIpCountry, cacheIpCountry);

                        logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Run Parse : {0} was done", listFiles[i]));
                        _synContext.Post(OnParseLog, logInfo);
                    }
                    catch (Exception err)
                    {
                        logInfo = new LogInfoEventArgs(
                                   ParserID,
                                   EnumLogFile.UNKNOWN,
                                   LogProcessStatus.SUCCESS,
                                   "Parse()",
                                   String.Format("Error occurred on file {0}==>{1}\r\n{2}", listFiles[i], err.Message, err.StackTrace));
                        _synContext.Post(OnParseLog, logInfo);
                    }
                }


                _finish = true;

                //LogInfoEventArgs logInfo2 = new LogInfoEventArgs(
                //                   ParserID,
                //                   EnumLogFile.UNKNOWN,
                //                   LogProcessStatus.SUCCESS,
                //                   "Parse()",
                //                   "Consolidating log files...");
                //_synContext.Post(OnParseLog, logInfo2);
                //try
                //{
                //    //DumpData();

                //    //if (!_exitDump.IsSet)
                //    //    _exitDump.Wait();
                //}
                //catch { }

                LogInfoEventArgs logInfo2 = new LogInfoEventArgs(
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
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

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
                Logger.Write(err.Message);
                Logger.Write(err.StackTrace);

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
            DataHelper helper = new DataHelper(IndihiangHelper.GetIPCountryDb());
            List<Indihiang.DomainObject.IPCountry> listIpCountry = helper.GetAllIpCountry();

            Dictionary<string, string> cacheIpCountry = new Dictionary<string, string>();
            cacheIpCountry.Add("127.0.0.1", "(Local)");

            while (!_finish)
            {
                try
                {
                    if (_dumpLogQueue.TryDequeue(out listDump))
                    {
						if (Indihiang.Properties.Settings.Default.FindCountries)
						{
                            for (int j = 0; j < listDump.Count; j++)
                            {
                                if (!string.IsNullOrEmpty(listDump[j].Client_IP))
                                {
                                    if (!cacheIpCountry.ContainsKey(listDump[j].Client_IP))
                                    {
                                        double ip = IndihiangHelper.IPAddressToNumber(listDump[j].Client_IP);
                                        for (int k = 0; k < listIpCountry.Count; k++)
                                        {
                                            if (ip >= listIpCountry[k].IpStart && ip <= listIpCountry[k].IpEnd)
                                            {
                                                Indihiang.DomainObject.DumpData obj = listDump[j];
                                                obj.IPClientCountry = listIpCountry[k].CoutryName;
                                                listDump[j] = obj;

                                                cacheIpCountry.Add(listDump[j].Client_IP, listIpCountry[k].CoutryName);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Indihiang.DomainObject.DumpData obj = listDump[j];
                                        obj.IPClientCountry = cacheIpCountry[listDump[j].Client_IP];
                                        listDump[j] = obj;
                                    }
                                }
                            }
						}

                        Debug.WriteLine("PerformDump..");
                        PerformDump(listDump);
                        listDump.Clear();
                    }
                    else
                        Thread.Sleep(10);
                }
                catch(Exception err)
                {
                    Logger.Write(err.Message);
                    Logger.Write(err.StackTrace);

                    Debug.WriteLine("DumpData()::" + err.Message);
                }
            }
            if (!_dumpLogQueue.IsEmpty)
            {
                Debug.WriteLine(string.Format("Total remain data: {0}", _dumpLogQueue.Count));
                List<Indihiang.DomainObject.DumpData>[] list = _dumpLogQueue.ToArray();
                for (int i = 0; i < list.Length; i++)
                {
                    Debug.WriteLine(string.Format("Dump data: {0}:{1}", i + 1, _dumpLogQueue.Count));

					if (Indihiang.Properties.Settings.Default.FindCountries)
					{
                        for (int j = 0; j < list[i].Count; j++)
                        {
                            if (!string.IsNullOrEmpty(list[i][j].Client_IP))
                            {
                                if (!cacheIpCountry.ContainsKey(list[i][j].Client_IP))
                                {
                                    double ip = IndihiangHelper.IPAddressToNumber(list[i][j].Client_IP);
                                    for (int k = 0; k < listIpCountry.Count; k++)
                                    {
                                        if (ip >= listIpCountry[k].IpStart && ip <= listIpCountry[k].IpEnd)
                                        {
                                            Indihiang.DomainObject.DumpData obj = list[i][j];
                                            obj.IPClientCountry = listIpCountry[k].CoutryName;
                                            list[i][j] = obj;

                                            cacheIpCountry.Add(list[i][j].Client_IP, listIpCountry[k].CoutryName);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Indihiang.DomainObject.DumpData obj = list[i][j];
                                    obj.IPClientCountry = cacheIpCountry[list[i][j].Client_IP];
                                    list[i][j] = obj;
                                }
                            }

                        }
					}
                    PerformDump(list[i]);
                    list[i].Clear();
                }
            }
            cacheIpCountry.Clear();
            listIpCountry.Clear();
            _allDone = true;
            _exitDump.Set();
        }

        private void DumpPartial(List<Indihiang.DomainObject.IPCountry> listIpCountry, Dictionary<string, string> cacheIpCountry)
        {
            if (!_dumpLogQueue.IsEmpty)
            {
                Debug.WriteLine(string.Format("Total dumo data: {0}", _dumpLogQueue.Count));
                List<Indihiang.DomainObject.DumpData>[] list = _dumpLogQueue.ToArray();
                for (int i = 0; i < list.Length; i++)
                {
                    Debug.WriteLine(string.Format("Dump data: {0}:{1}", i + 1, _dumpLogQueue.Count));

                    for (int j = 0; j < list[i].Count; j++)
                    {
                        if (!string.IsNullOrEmpty(list[i][j].Client_IP))
                        {
                            if (!cacheIpCountry.ContainsKey(list[i][j].Client_IP))
                            {
                                double ip = IndihiangHelper.IPAddressToNumber(list[i][j].Client_IP);
                                for (int k = 0; k < listIpCountry.Count; k++)
                                {
                                    if (ip >= listIpCountry[k].IpStart && ip <= listIpCountry[k].IpEnd)
                                    {
                                        Indihiang.DomainObject.DumpData obj = list[i][j];
                                        obj.IPClientCountry = listIpCountry[k].CoutryName;
                                        list[i][j] = obj;

                                        cacheIpCountry.Add(list[i][j].Client_IP, listIpCountry[k].CoutryName);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Indihiang.DomainObject.DumpData obj = list[i][j];
                                obj.IPClientCountry = cacheIpCountry[list[i][j].Client_IP];
                                list[i][j] = obj;
                            }
                        }

                    }
                    PerformDump(list[i]);
                    list[i].Clear();
                }
            }
            cacheIpCountry.Clear();
            listIpCountry.Clear();
            _allDone = true;


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
                    IndihiangHelper.InitialIndihiangFile(file, listDump[0].Year.ToString());
                    helper = new DataHelper(file);
                }
                else
                    helper = new DataHelper(file);

                helper.InsertBulkDumpData(listDump);
            }
        }

        protected void RunParse(string logFile)
        {
            List<Indihiang.DomainObject.DumpData> listDump = new List<Indihiang.DomainObject.DumpData>();
			bool bRead = false;
			DateTime dt = DateTime.Now;
			string strError = "(unknown)";
retry:
			if (((DateTime.Now - dt).TotalSeconds > 5) && (System.Windows.Forms.MessageBox.Show("Timed out trying to open log file:\n\n" + logFile + "\n\nError: " + strError + "\n\nTry again?", "Time out", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes))
				return;
			try
			{
				using (StreamReader sr = new StreamReader(File.Open(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))	// FileShare.Read
				{
					bRead = true;

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
							line = line.Replace('\0', ' ');
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
											try
											{
												if (currentHeader[i].Equals("date"))
												{
													val = rows[i];
													if (string.IsNullOrEmpty(val))
														continue;
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
													dump.Client_IP = rows[i];
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
												{
													dump.Referer = rows[i];
													dump.RefererClass = IndihiangHelper.GetRefererClass(rows[i]);
												}

												if (currentHeader[i].Equals("sc-bytes"))
												{
													if (!string.IsNullOrEmpty(rows[i]))
														dump.Bytes_Sent = Convert.ToInt64(rows[i]);
													else
														dump.Bytes_Sent = 0;
												}

												if (currentHeader[i].Equals("cs-bytes"))
												{
													if (!string.IsNullOrEmpty(rows[i]))
														dump.Bytes_Received = Convert.ToInt64(rows[i]);
													else
														dump.Bytes_Received = 0;
												}
												if (currentHeader[i].Equals("time-taken"))
												{
													if (!string.IsNullOrEmpty(rows[i]))
														dump.TimeTaken = Convert.ToInt64(rows[i]);
													else
														dump.TimeTaken = 0;
												}
											}
											catch (Exception err)
											{
												Console.WriteLine(err.Message);
											}

										}

										if (dump.Day > 0 && dump.Month > 0)
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
			/*catch (IOException)
			{
				//
			}*/
			catch (Exception ex)
			{
				strError = ex.Message;
			}

			if (bRead == false)
				goto retry;
        }

        protected abstract bool IsLogHeader(string line);
        protected abstract List<string> ParseHeader(string line);
    }
}
