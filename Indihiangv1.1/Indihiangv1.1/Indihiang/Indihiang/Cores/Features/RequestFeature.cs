using System;
using System.IO;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class RequestFeature : BaseLogAnalyzeFeature
    {
        private Guid _parserId = Guid.NewGuid();

        public RequestFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.REQUEST;

            LogCollection log = new LogCollection();
            _logs.Add("TimeTaken", log);            
        }

        public RequestFeature(EnumLogFile logFile,Guid parserId)
            : base(logFile)
        {
            _parserId = parserId;
            _featureName = LogFeature.REQUEST;

            LogCollection log = new LogCollection();
            _logs.Add("TimeTaken", log);
        }


        protected override bool RunFeature(List<string> header, string[] item)
        {
            switch (_logFile)
            {
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.W3CEXT:
                    RunW3cext(header, item);
                    break;
            }

            return true;
        }

        protected override bool RunFeature(string id,List<string> header, string[] item)
        {
            switch (_logFile)
            {
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.W3CEXT:
                    RunW3cext(id,header, item);
                    break;
            }

            return true;
        }


        private void RunW3cext(List<string> header, string[] item)
        {
            int index = header.IndexOf("date");
            int index2 = header.IndexOf("time");
            int index3 = header.IndexOf("cs-uri-stem");
            int index4 = header.IndexOf("time-taken");

            if (index == -1 || index2== -1|| index3== -1|| index4==-1)
                return;

            string key1 = item[index];
            string key2 = item[index2];
            string key = string.Format("{0} {1}", key1, key2);

            string data1;
            if (index3 > 0)
                data1 = item[index3];
            else
                data1 = string.Empty;
            string data2;
            if (index4 > 0)
                data2 = item[index4];
            else
                data2 = string.Empty;

            if (!string.IsNullOrEmpty(data1) && data1 != "-" && !string.IsNullOrEmpty(data2) && data2 != "-")
            {
                if (!_logs["TimeTaken"].Colls.ContainsKey(key))
                {
                    _logs["TimeTaken"].Colls.Add(key, new WebLog(String.Format("{0};{1}", data1, Guid.NewGuid().ToString()), data2));
                }
                else
                {
                    _logs["TimeTaken"].Colls[key].Items.Add(String.Format("{0};{1}", data1, Guid.NewGuid().ToString()), data2);
                }
            }

        }

        private void RunW3cext(string id,List<string> header, string[] item)
        {            
            int index1 = header.IndexOf("cs-uri-stem");
            int index2 = header.IndexOf("time-taken");

            if (index1 == -1 || index2 == -1 )
                return;            

            string data1;
            if (index1 > 0)
                data1 = item[index1];
            else
                data1 = string.Empty;
            string data2;
            if (index2 > 0)
                data2 = item[index2];
            else
                data2 = string.Empty;

            string path = String.Format("{0}\\Temp\\{1}\\", Environment.CurrentDirectory, id);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!string.IsNullOrEmpty(data1) && data1 != "-" && !string.IsNullOrEmpty(data2) && data2 != "-")
            {
                FeatureLogFile logFile = new FeatureLogFile();
                string timeTakenFile = String.Format("{0}{1}-TimeTaken.tmp", path, _featureName.ToString());
                logFile.LogFile = timeTakenFile;
                logFile.InsertData(data1, data2);                
            }

        }

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in newItem)
                {
                    if (pair.Key == "TimeTaken")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            if (!_logs[pair.Key].Colls.ContainsKey(pair2.Key))
                                _logs[pair.Key].Colls.Add(pair2.Key, pair2.Value);
                        }
                    }
                }
                //IndihiangHelper.DumpToFile(_parserId.ToString(), String.Format("{0}.txt", _featureName), _logs["TimeTaken"].Colls);
                success = true;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error Synch: {0}", err.Message));
            }
            return success;
        }

        protected override void DumpToFile(StreamWriter sw)
        {
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in _logs)
                {
                    if (pair.Key == "TimeTaken" )
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                            {
                                string data = String.Format("{0};{1};{2}", pair2.Key, pair3.Key, pair3.Value);
                                sw.WriteLine(data);
                            }
                        }
                    }

                }
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error DumpToFile: {0}", err.Message));
            }
        }
    }
}
