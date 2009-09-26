using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class WebLog
    {
        private Dictionary<string, string> _colls = new Dictionary<string, string>();
        public Dictionary<string, string> Items
        {
            set
            {
                _colls = value;
            }
            get
            {
                return _colls;
            }
        }
        public WebLog(string key,string val) 
        {
            _colls.Add(key, val);
        }
    }
}
