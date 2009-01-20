using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

using Indihiang.Cores.Features;
namespace Indihiang.Cores
{
    public class LogParser
    {
        private Guid _logParserId;
        private string _fileName;
        private BaseLogParser _parser;
        private Dictionary<string, BaseLogAnalyzeFeature> _features;
        private Thread _thread = null;

        public Guid LogParserId
        {
            get
            {
                return _logParserId;
            }            
        }        
        public LogParser() 
        {
            _logParserId = Guid.NewGuid();
            _features = new Dictionary<string, BaseLogAnalyzeFeature>();
        }

        public delegate void AnalyzeLogHandler(object sender, LogInfoEventArgs logInfo);
        public delegate void EndAnalyzeHandler(object sender, LogInfoEventArgs logInfo);

        public event AnalyzeLogHandler AnalyzeLog;
        public event EndAnalyzeHandler EndAnalyze;

        public LogCollection<int> GetValuesByFeature(string featureName)
        {
            return _features[featureName].Items;
        }
        public void Analyze()
        {
            if (!Verify())
                return;

            if (_thread == null)
                _thread = new Thread(new ThreadStart(Process));

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
        public void OnAnalyzeLog(object sender, LogInfoEventArgs logInfo)
        {            
            if (AnalyzeLog != null)
                AnalyzeLog(sender, logInfo);
        }
        public void OnEndAnalyze(object sender, LogInfoEventArgs logInfo)
        {
            if (EndAnalyze != null)
                EndAnalyze(sender, logInfo);
        }


        private void Process()
        {
            PrepareFeatures();
            _parser.Parse();
        }
        private void PrepareFeatures()
        {
            _parser.Features.Add(new UserAgentFeature(_parser.LogFileFormat));
        }
        private bool Verify()
        {
            if (!File.Exists(_fileName))
            {
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                    _fileName, 
                    EnumLogFile.UNKNOWN, 
                    LogProcessStatus.FAILED,
                    "LogParser.Verify()", 
                    _fileName + " isn't found");
                OnAnalyzeLog(this, logInfo);

                return false;
            }

            _parser = LogParserFactory.CreateParser(_fileName);
            if (_parser == null)
            {
                LogInfoEventArgs logInfo = new LogInfoEventArgs(
                     _fileName,
                     EnumLogFile.UNKNOWN,
                     LogProcessStatus.FAILED,
                     "LogParser.Verify()",
                     "Application cannot verify log file format");
                OnAnalyzeLog(this, logInfo);

                return false;
            }

            return true;
        }
    }
}
