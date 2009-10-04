using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.DomainObject
{
    public class LogItem
    {
        private int _id;
        private string _itemField;
        private string _itemValue;

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
        public string ItemField
        {
            get
            {
                return _itemField;
            }
            set
            {
                if (_itemField == value)
                    return;
                _itemField = value;
            }
        }
        public string ItemValue
        {
            get
            {
                return _itemValue;
            }
            set
            {
                if (_itemValue == value)
                    return;
                _itemValue = value;
            }
        }

        public LogItem() { }
    }
}
