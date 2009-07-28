using System;

namespace Indihiang.DomainObject
{
    public class FeatureData
    {
        private int _id;
        private int _featureId;
        private string _val;

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
        public int FeatureId
        {
            get
            {
                return _featureId;
            }
            set
            {
                if (_featureId == value)
                    return;
                _featureId = value;
            }
        }
        public string Val
        {
            get
            {
                return _val;
            }
            set
            {
                if (_val == value)
                    return;
                _val = value;
            }
        }

        public FeatureData() { }
    }
}
