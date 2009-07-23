using System;
using System.IO;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class FeatureLogFile
    {     
        private string _logFile;        
        
        public string LogFile
        {
            get
            {
                return _logFile;
            }
            set
            {
                if (_logFile == value)
                    return;
                _logFile = value;
            }
        }
        public FeatureLogFile() { }

        
        public void InsertUniqueData(string key)
        {
            try
            {                
                StringBuilder newFile = new StringBuilder();

                if (!File.Exists(_logFile))
                {
                    newFile.Append(String.Format("{0}\r\n", key.Trim().ToLower()));
                    File.WriteAllText(_logFile, newFile.ToString());

                    return;
                }

                string[] lines = File.ReadAllLines(_logFile);

                bool found = false;
                foreach (string line in lines)
                {
                    if (line.Trim()==key.ToLower().Trim())
                    {
                        found = true;
                        continue;
                    }
                    newFile.Append(String.Format("{0}\r\n", line));
                }
                if(!found)
                    newFile.Append(String.Format("{0}\r\n", key.Trim().ToLower()));

                File.WriteAllText(_logFile, newFile.ToString());
            }
            catch (Exception) { }
        }

        public void UpdateCount(string key,long count)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();
                if (!File.Exists(_logFile))
                {
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), count));
                    File.WriteAllText(_logFile, newFile.ToString());

                    return;
                }
                string[] lines = File.ReadAllLines(_logFile);

                bool found = false;
                foreach (string line in lines)
                {
                    if (line.StartsWith(key))
                    {
                        string[] strings = line.Split(new char[] {';'});
                        int oldCount = 0;
                        if (strings != null)
                        {
                            if (strings.Length > 1)
                                oldCount = Convert.ToInt32(strings[1]);
                        }
                        found = true;
                        newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), oldCount + count));
                        continue;
                    }
                    newFile.Append(String.Format("{0}\r\n", line));

                }
                if(!found)
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), count));

                File.WriteAllText(_logFile, newFile.ToString());
            }
            catch (Exception) { }
        }

        public void UpdateData(string key, string data)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();
                if (!File.Exists(_logFile))
                {
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), data));
                    File.WriteAllText(_logFile, newFile.ToString());

                    return;
                }
                string[] lines = File.ReadAllLines(_logFile);

                bool found = false;
                foreach (string line in lines)
                {
                    if (line.StartsWith(key))
                    {                        
                        found = true;
                        newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), data));
                        continue;
                    }
                    newFile.Append(String.Format("{0}\r\n", line));
                }
                if (!found)
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), data));

                File.WriteAllText(_logFile, newFile.ToString());
            }
            catch (Exception) { }
        }
        public void InsertData(string key, string data)
        {
            try
            {
                StringBuilder newFile = new StringBuilder();
                if (!File.Exists(_logFile))
                {
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), data));
                    File.WriteAllText(_logFile, newFile.ToString());

                    return;
                }
                string[] lines = File.ReadAllLines(_logFile);

                bool found = false;
                foreach (string line in lines)
                {
                    if (line.StartsWith(key))
                    {
                        found = true;
                        newFile.Append(String.Format("{0};{1}\r\n", line, data));
                        continue;
                    }
                    newFile.Append(String.Format("{0}\r\n", line));
                }
                if (!found)
                    newFile.Append(String.Format("{0};{1}\r\n", key.ToLower(), data));

                File.WriteAllText(_logFile, newFile.ToString());
            }
            catch (Exception) { }
        }


    }
}
