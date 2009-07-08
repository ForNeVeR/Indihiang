using System;
using System.IO;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class IPAddressFeature : BaseLogAnalyzeFeature
    {
        public IPAddressFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.IPADDRESS;

            _logs.Add("General", new LogCollection());
            _logs.Add("IPPage", new LogCollection());
            
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
            if (header.Count <= 0)
                return;

            int index = header.IndexOf("date");
            string key;
            if (index != -1)
                key = item[index];
            else
                key = null;
            int index2 = header.IndexOf("c-ip");
            string key2;
            if (index2 != -1)
                key2 = item[index2];
            else
                key2 = null;
            int index3 = header.IndexOf("cs-uri-stem");
            string key3;
            if (index3 != -1)
                key3 = item[index3];
            else
                key3 = null;


            if (!string.IsNullOrEmpty(key) && key != "-")
            {
                if (!string.IsNullOrEmpty(key2) && key2 != "-")
                {
                    if (_logs["General"].Colls.ContainsKey(key2))
                    {
                        int val = Convert.ToInt32(_logs["General"].Colls[key2].Items[key2]);
                        val++;
                        _logs["General"].Colls[key2].Items[key2] = val.ToString();
                    }
                    else
                        _logs["General"].Colls.Add(key2, new WebLog(key2, "1"));

                    if (!string.IsNullOrEmpty(key3))
                    {
                        if (_logs["IPPage"].Colls.ContainsKey(key2))
                        {
                            if (_logs["IPPage"].Colls[key2].Items.ContainsKey(key3))
                            {
                                int val = Convert.ToInt32(_logs["IPPage"].Colls[key2].Items[key3]);
                                val++;
                                _logs["IPPage"].Colls[key2].Items[key3] = val.ToString();
                            }
                            else
                                _logs["IPPage"].Colls[key2].Items.Add(key3, "1");
                        }
                        else
                        {
                            _logs["IPPage"].Colls.Add(key2, new WebLog(key3, "1"));
                        }
                    }                      
                }

            }                            
        }        

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;

            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in newItem)
                {
                    if (pair.Key == "General" || pair.Key == "IPPage")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            if (_logs[pair.Key].Colls.ContainsKey(pair2.Key))
                            {
                                foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                                {
                                    if (_logs[pair.Key].Colls[pair2.Key].Items.ContainsKey(pair3.Key))
                                    {
                                        int val1 = Convert.ToInt32(_logs[pair.Key].Colls[pair2.Key].Items[pair3.Key]);
                                        int val2 = Convert.ToInt32(pair3.Value);

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
            }

            return success;
        }
        protected override void DumpToFile(StreamWriter sw)
        {
            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in _logs)
                {
                    if (pair.Key == "General" || pair.Key == "IPPage")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                            {
                                string data = String.Format("#{0};{1};{2};{3}", pair.Key, pair2.Key,pair3.Key, pair3.Value);
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
