using System;
using Indihiang.Cores.Features;

namespace Indihiang.Modules
{
    public interface BaseControl
    {        
        LogCollection<int> Items { set; }

        void Populate();
    }
}
