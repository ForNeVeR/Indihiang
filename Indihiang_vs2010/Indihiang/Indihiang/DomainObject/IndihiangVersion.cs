using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.DomainObject
{
    [Serializable]
    public class IndihiangVersion
    {        
        public string Ver { set; get; }
        public string Url { set; get; }

        public IndihiangVersion() { }
    }
}
