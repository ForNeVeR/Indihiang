using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class DumpLogData
    {
        private string _source;
        private List<string> _header;
        private Dictionary<string, List<string>> _rows;

        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                if (_source == value)
                    return;
                _source = value;
            }
        }
        public List<string> Header
        {
            get
            {
                return _header;
            }
            set
            {
                if (_header == value)
                    return;
                _header = value;
            }
        }
        public Dictionary<string, List<string>> Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                if (_rows == value)
                    return;
                _rows = value;
            }
        }
        public DumpLogData() { }

    }
}
