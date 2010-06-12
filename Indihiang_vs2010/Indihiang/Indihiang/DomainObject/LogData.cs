using System;

namespace Indihiang.DomainObject
{
    public class LogData
    {
        private int _id;
        private string _logDate;
        private string _logTime;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                    return;
                _id = value;
            }
        }
        public string LogDate
        {
            get
            {
                return _logDate;
            }
            set
            {
                if (_logDate == value)
                    return;
                _logDate = value;
            }
        }
        public string LogTime
        {
            get
            {
                return _logTime;
            }
            set
            {
                if (_logTime == value)
                    return;
                _logTime = value;
            }
        }

        public LogData() { }

    }
}
