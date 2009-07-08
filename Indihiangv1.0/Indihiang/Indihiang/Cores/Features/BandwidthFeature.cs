using System;
using System.IO;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class BandwidthFeature : BaseLogAnalyzeFeature
    {
        public BandwidthFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.BANDWIDTH;
            
            _logs.Add("BytesSent", new LogCollection());
            _logs.Add("ByteReceived", new LogCollection());
            _logs.Add("ByteIPClient", new LogCollection());
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

        private void RunW3cext(List<string> header, string[] item)
        {
            if (header == null)
                return;

            long val = 0;
            int index = header.IndexOf("date");
            int index2 = header.IndexOf("cs-uri-stem");
            int index3 = header.IndexOf("sc-bytes");
            int index4 = header.IndexOf("cs-bytes");
            int index5 = header.IndexOf("c-ip");

            if (index == -1)
                return;

            string key = item[index];

            string data1;
            if (index2 > 0 && index2<=item.Length)
                data1 = item[index2];
            else
                data1 = string.Empty;
            string data2;
            if (index3 > 0 && index3<=item.Length)
                data2 = item[index3];
            else
                data2 = string.Empty;
            string data3;
            if (index4 > 0 && index4<=item.Length)
                data3 = item[index4];
            else
                data3 = string.Empty;

            string data4;
            if (index5 > 0 && index5 <= item.Length)
                data4 = item[index5];
            else
                data4 = string.Empty;



            #region BytesSent
            if (!string.IsNullOrEmpty(data1) && data1 != "-")
            {
                if (_logs["BytesSent"].Colls.ContainsKey(key))
                {
                    if (_logs["BytesSent"].Colls[key].Items.ContainsKey(data1))
                    {
                        if (!string.IsNullOrEmpty(data2))
                        {                           
                            
                            val = Convert.ToInt64(_logs["BytesSent"].Colls[key].Items[data1]);
                            val = val + Convert.ToInt64(data2);

                            _logs["BytesSent"].Colls[key].Items[data1] = val.ToString();
                        }                        
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(data2))
                            val = Convert.ToInt64(data2);
                        else
                            val = 0;

                        _logs["BytesSent"].Colls[key].Items.Add(data1, val.ToString());
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(data2))
                        val = Convert.ToInt64(data2);
                    else
                        val = 0;

                    _logs["BytesSent"].Colls.Add(key, new WebLog(data1, val.ToString()));
                }
            }
            #endregion

            #region ByteReceived
            if (!string.IsNullOrEmpty(data1) && data1 != "-")
            {
                if (_logs["ByteReceived"].Colls.ContainsKey(key))
                {
                    if (_logs["ByteReceived"].Colls[key].Items.ContainsKey(data1))
                    {
                        if (!string.IsNullOrEmpty(data3))
                        {
                            val = Convert.ToInt64(_logs["ByteReceived"].Colls[key].Items[data1]);
                            val = val + Convert.ToInt64(data3);

                            _logs["ByteReceived"].Colls[key].Items[data1] = val.ToString();
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(data3))
                            val = Convert.ToInt64(data3);
                        else
                            val = 0;

                        _logs["ByteReceived"].Colls[key].Items.Add(data1, val.ToString());
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(data3))
                        val = Convert.ToInt64(data3);
                    else
                        val = 0;

                    _logs["ByteReceived"].Colls.Add(key, new WebLog(data1, val.ToString()));
                }
            }
            #endregion

            #region ByteIPClient
            if (!string.IsNullOrEmpty(data4) && data4 != "-")
            {
                if (_logs["ByteIPClient"].Colls.ContainsKey(data4))
                {
                    if (!string.IsNullOrEmpty(data2))
                    {
                        if (_logs["ByteIPClient"].Colls[data4].Items.ContainsKey("Sent"))
                        {
                            val = Convert.ToInt64(_logs["ByteIPClient"].Colls[data4].Items["Sent"]);
                            val = val + Convert.ToInt64(data2);

                            _logs["ByteIPClient"].Colls[data4].Items["Sent"] = val.ToString();
                        }

                    }
                    if (!string.IsNullOrEmpty(data3))
                    {
                        if (_logs["ByteIPClient"].Colls[data4].Items.ContainsKey("Received"))
                        {
                            val = Convert.ToInt64(_logs["ByteIPClient"].Colls[data4].Items["Received"]);
                            val = val + Convert.ToInt64(data3);

                            _logs["ByteIPClient"].Colls[data4].Items["Received"] = val.ToString();
                        }

                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(data2))
                        val = Convert.ToInt64(data2);
                    else
                        val = 0;
                    _logs["ByteIPClient"].Colls.Add(data4, new WebLog("Sent", val.ToString()));

                    if (!string.IsNullOrEmpty(data3))
                        val = Convert.ToInt64(data3);
                    else
                        val = 0;
                    _logs["ByteIPClient"].Colls[data4].Items.Add("Received", val.ToString());

                }
            }
            #endregion

        }

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in newItem)
                {
                    if (pair.Key == "BytesSent" || pair.Key == "ByteReceived" || pair.Key == "ByteIPClient")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            if (_logs[pair.Key].Colls.ContainsKey(pair2.Key))
                            {
                                foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                                {
                                    if (_logs[pair.Key].Colls[pair2.Key].Items.ContainsKey(pair3.Key))
                                    {
                                        long val1 = Convert.ToInt64(_logs[pair.Key].Colls[pair2.Key].Items[pair3.Key]);
                                        long val2 = Convert.ToInt64(pair3.Value);

                                        _logs[pair.Key].Colls[pair2.Key].Items[pair3.Key] = Convert.ToString(val1 + val2);
                                    }
                                    else
                                        _logs[pair.Key].Colls[pair2.Key].Items.Add(pair3.Key, pair3.Value);
                                }
                            }
                            else
                            {
                                _logs[pair.Key].Colls.Add(pair2.Key, pair2.Value);
                            }
                        }
                    }
                    
                }
                success = true;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("Error Synch: {0}", err.Message));
                System.Diagnostics.Debug.WriteLine(String.Format("Error Synch: {0}", err.StackTrace));
            }
            return success;
        }

        protected override void DumpToFile(StreamWriter sw)
        {
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in _logs)
                {
                    if (pair.Key == "BytesSent" || pair.Key == "ByteReceived" || pair.Key == "ByteIPClient")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                            {
                                string data = String.Format("#{0};{1};{2};{3}", pair.Key, pair2.Key,pair3.Key,pair3.Value);
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
