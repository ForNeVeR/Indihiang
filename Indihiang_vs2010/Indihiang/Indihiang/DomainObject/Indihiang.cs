using System;

namespace Indihiang.DomainObject
{
    public class Indihiang
    {
        private int _id;
        private string _sys_item;
        private string _sys_value;
        private DateTime _updateDate;

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
        public string Sys_Item
        {
            get
            {
                return _sys_item;
            }
            set
            {
                if (_sys_item == value)
                    return;
                _sys_item = value;
            }
        }
        public string Sys_Value
        {
            get
            {
                return _sys_value;
            }
            set
            {
                if (_sys_value == value)
                    return;
                _sys_value = value;
            }
        }
        public DateTime UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                if (_updateDate == value)
                    return;
                _updateDate = value;
            }
        }


        public Indihiang() { }
    }
}
