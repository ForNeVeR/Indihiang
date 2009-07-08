using System;
using System.Collections.Generic;
using Indihiang.Cores.Features;

namespace Indihiang.Modules
{
    public interface BaseControl
    {
        Dictionary<string, LogCollection> DataSource { set; get; }
        void Populate();
    }
}
