using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class LogCollection 
    {
        private Dictionary<string, WebLog> _list = new Dictionary<string, WebLog>();
        public Dictionary<string, WebLog> Colls
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public LogCollection():base() { }
    }
}
