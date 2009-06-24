﻿using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class AccessPageFeature : BaseLogAnalyzeFeature
    {
        public AccessPageFeature(EnumLogFile logFile)
            : base(logFile)
        {
            _featureName = LogFeature.ACCESS;

            LogCollection log = new LogCollection();
            _logs.Add("General", log);
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
            int val = 0;
            int index = header.IndexOf("date");
            int index2 = header.IndexOf("cs-uri-stem");
            
            if (index == -1 || index2 == -1)
                return;

            string key = item[index];
            string dataKey = item[index2];

            if (dataKey != "" && dataKey != null && dataKey != "-")
            {
                if (_logs["General"].Colls.ContainsKey(key))
                {
                    if (_logs["General"].Colls[key].Items.ContainsKey(dataKey))
                    {                            
                        val = Convert.ToInt32(_logs["General"].Colls[key].Items[dataKey]);
                        val++;
                        _logs["General"].Colls[key].Items[dataKey] = val.ToString();                          
                    }
                    else
                        _logs["General"].Colls[key].Items.Add(dataKey, "1"); 
                }
                else
                    _logs["General"].Colls.Add(key, new WebLog(dataKey, "1")); 
            }
        }        

        protected override bool RunSynchFeatureData(Dictionary<string, LogCollection> newItem)
        {
            bool success = false;

            try
            {
                foreach (KeyValuePair<string, LogCollection> pair in newItem)
                {
                    if (pair.Key == "General")
                    {
                        foreach (KeyValuePair<string, WebLog> pair2 in pair.Value.Colls)
                        {
                            if (_logs["General"].Colls.ContainsKey(pair2.Key))
                            {
                                foreach (KeyValuePair<string, string> pair3 in pair2.Value.Items)
                                {
                                    if (_logs["General"].Colls[pair2.Key].Items.ContainsKey(pair3.Key))
                                    {
                                        int val1 = Convert.ToInt32(_logs["General"].Colls[pair2.Key].Items[pair3.Key]);
                                        int val2 = Convert.ToInt32(pair3.Value);

                                        _logs["General"].Colls[pair2.Key].Items[pair3.Key] = Convert.ToString(val1 + val2);
                                    }
                                    else
                                        _logs["General"].Colls[pair2.Key].Items.Add(pair3.Key, pair3.Value);
                                }
                            }
                            else
                            {
                                _logs["General"].Colls.Add(pair2.Key, pair2.Value);
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
    }
}
