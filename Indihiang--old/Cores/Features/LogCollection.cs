using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class LogCollection<T> : List<T>
    {
        private Dictionary<string, string> _colls = new Dictionary<string, string>();
        public Dictionary<string, string> Colls
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

        public LogCollection() { }
    
    }
}
