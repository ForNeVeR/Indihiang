using System;

using Indihiang.Cores.Features;
namespace Indihiang.Modules
{
    public class RenderInfoEventArgs : EventArgs
    {
        private string _id;
        private LogFeature _feature;
        private string _fileName;

        public string Id
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
        public LogFeature Feature
        {
            get
            {
                return _feature;
            }
            set
            {
                if (_feature == value)
                    return;
                _feature = value;
            }
        }
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (_fileName == value)
                    return;
                _fileName = value;
            }
        }

        public RenderInfoEventArgs(string id, LogFeature feature, string fileName)
        {
            _id = id;
            _feature = feature;
            _fileName = fileName;
        }
        public RenderInfoEventArgs()
        {
            _id = Guid.NewGuid().ToString();
            _feature = LogFeature.GENERAL;
            _fileName = string.Empty;
        }
    }
}
