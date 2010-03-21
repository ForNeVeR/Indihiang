using System;

namespace Indihiang.Data
{
    public abstract class IndihiangDataExport
    {
        protected string _databaseFile;
        protected string _svr;
        protected string _db;
        protected string _uid;
        protected string _pwd;
        protected string _errMessage;

        public string ErrMessage
        {
            get
            {
                return _errMessage;
            }
            set
            {
                if (_errMessage == value)
                    return;
                _errMessage = value;
            }
        }
        protected IndihiangDataExport() { }


        public static IndihiangDataExport Create(DataExportDestination mode)
        {
            if (mode == DataExportDestination.SQLServer)
                return new SQLServerDataExport();
            //if (mode == DataExportDestination.Oracle)
            //    return new OracleDataExport();

            return null;
        }       

        public bool Export(string databaseFile,string server,string database,string uid,string pwd)
        {
            _databaseFile = databaseFile;
            _svr = server;
            _db = database;
            _uid = uid;
            _pwd = pwd;

            if (!CreateDatabase())
                return false;

            if (!ExportData())
                return false;

            return true;
        }


        protected abstract bool CreateDatabase();
        protected abstract bool ExportData();
    }
}
