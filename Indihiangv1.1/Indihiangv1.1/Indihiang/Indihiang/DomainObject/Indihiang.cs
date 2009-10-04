using System;

namespace Indihiang.DomainObject
{
    public class Indihiang
    {
        private int _id;
        private string _asm_version;
        private string _file_version;
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
        public string Asm_Version
        {
            get
            {
                return _asm_version;
            }
            set
            {
                if (_asm_version == value)
                    return;
                _asm_version = value;
            }
        }
        public string File_Version
        {
            get
            {
                return _file_version;
            }
            set
            {
                if (_file_version == value)
                    return;
                _file_version = value;
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
