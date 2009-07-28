using System;


namespace Indihiang.DomainObject
{
    public class Shared
    {
        private int _id;
        private string _name;
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                    return;
                _name = value;
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

        public Shared() { }

    }
}
