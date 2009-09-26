using System;

namespace Indihiang.DomainObject
{
    public class Indihiang
    {
        private int _id;
        private string _version;

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
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                if (_version == value)
                    return;
                _version = value;
            }
        }

        public Indihiang() { }
    }
}
