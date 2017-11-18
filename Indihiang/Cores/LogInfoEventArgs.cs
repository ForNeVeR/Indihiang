using System;

namespace Indihiang.Cores
{
    public class LogInfoEventArgs : EventArgs
    {        
        public string FileName { get; private set; }
        public EnumLogFile LogFormat { get; private set; }
        public string CalledMethod { get; private set; }
        public string Message { get; private set; }
        public LogProcessStatus LogStatus { get; set; }
       
        public LogInfoEventArgs(string fileName, EnumLogFile logFormat, LogProcessStatus logStatus,string calledMethod, string message)
        {
            FileName = fileName;
            LogFormat = logFormat;
            CalledMethod = calledMethod;
            Message = message;
            LogStatus = logStatus;
        }
        public LogInfoEventArgs()
        {
            
        }
         
    }
}
