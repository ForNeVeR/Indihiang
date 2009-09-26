using System;
using System.Collections.Generic;

namespace Indihiang.Cores.Features
{
    public class FeatureDataRow
    {
        private string _featureName;
        private string _dateData;
        private Dictionary<string, string> _rows;

        public string FeatureName
        {
            get
            {
                return _featureName;
            }
            set
            {
                if (_featureName == value)
                    return;
                _featureName = value;
            }
        }
        public string DateData
        {
            get
            {
                return _dateData;
            }
            set
            {
                if (_dateData == value)
                    return;
                _dateData = value;
            }
        }
        public Dictionary<string, string> Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                if (_rows == value)
                    return;
                _rows = value;
            }
        }

        public FeatureDataRow() { }
    }
}
