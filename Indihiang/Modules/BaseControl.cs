using System;

namespace Indihiang.Modules
{
    public interface BaseControl
    {
        event EventHandler<RenderInfoEventArgs> RenderHandler;
        string FeatureGuid { set; get; }
        string FileName { set; get; }

        void Populate();
    }
}
