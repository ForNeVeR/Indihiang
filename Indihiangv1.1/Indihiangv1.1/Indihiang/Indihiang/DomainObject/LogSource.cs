using System;

namespace Indihiang.DomainObject
{
    public class LogSource
    {
        private int _id;
        private string _sourceData;

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
        public string SourceData
        {
            get
            {
                return _sourceData;
            }
            set
            {
                if (_sourceData == value)
                    return;
                _sourceData = value;
            }
        }

        public LogSource() { }


    }
}
