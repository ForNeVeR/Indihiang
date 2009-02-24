using System;

namespace Indihiang.Cores
{
    public class LogInfoEventArgs : EventArgs
    {
        private string _fileName;
        private EnumLogFile _logFormat;
        private LogProcessStatus _logStatus;
        private string _calledMethod;
        private string _message;

        public string FileName
        {
            get
            {
                return _fileName;
            }           
        }
        public EnumLogFile LogFormat
        {
            get
            {
                return _logFormat;
            }           
        }
        public LogProcessStatus LogStatus
        {
            get
            {
                return _logStatus;
            }
            set
            {
                if (_logStatus == value)
                    return;
                _logStatus = value;
            }
        }
        public string CalledMethod
        {
            get
            {
                return _calledMethod;
            }            
        }
        public string Message
        {
            get
            {
                return _message;
            }           
        }


        public LogInfoEventArgs(string fileName, EnumLogFile logFormat, LogProcessStatus logStatus,string calledMethod, string message)
        {
            _fileName = fileName;
            _logFormat = logFormat;
            _calledMethod = calledMethod;
            _message = message;
            _logStatus = logStatus;
        }
    }
}
