using System;


namespace Indihiang.DomainObject
{
    public class Feature
    {
        private int _id;
        private string _name;
        private string _field;

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
        public string Field
        {
            get
            {
                return _field;
            }
            set
            {
                if (_field == value)
                    return;
                _field = value;
            }
        }

        public Feature() { }
    }
}
