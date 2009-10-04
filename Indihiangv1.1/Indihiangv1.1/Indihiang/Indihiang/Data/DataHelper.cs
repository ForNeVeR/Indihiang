using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Indihiang.Data
{
    public class DataHelper
    {
        private string _dbFile;

        public string DBFile
        {
            get
            {
                return _dbFile;
            }
            set
            {
                if (_dbFile == value)
                    return;
                _dbFile = value;
            }
        }
        public DataHelper(string file)
        {
            _dbFile = file;
        }
        public DataHelper()
        {
            _dbFile = "";
        }
         
        private string GetConnectionStrng()
        {
            return string.Format("Data Source={0}",_dbFile);
        }

        #region Temp
        //public void InsertFeature(string name,string field)
        //{
        //    SQLiteConnection con = null;

        //    try
        //    {
        //        con = new SQLiteConnection(GetConnectionStrng());
        //        con.Open();

        //        string query = String.Format("insert into feature(name,field) values('{0}','{1}')", name,field);
        //        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Close();
        //    }
        //}
        //public void InsertShared(string name, string val)
        //{
        //    SQLiteConnection con = null;

        //    try
        //    {
        //        con = new SQLiteConnection(GetConnectionStrng());
        //        con.Open();

        //        string query = String.Format("insert into shared(name,val) values('{0}','{1}')", name, val);
        //        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Close();
        //    }
        //}
        //public void InsertFeatureData(string featureName, string field, string data1, string data2, string data3)
        //{
        //    SQLiteConnection con = null;
        //    SQLiteDataReader rd = null;
        //    try
        //    {
        //        con = new SQLiteConnection(GetConnectionStrng());
        //        con.Open();

        //        int id = -1;
        //        string query = String.Format("select id from feature where name like '{0}' and field like '{1}'", featureName, field);
        //        SQLiteCommand cmd = new SQLiteCommand(query, con);
        //        rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            if (!rd.IsDBNull(rd.GetOrdinal("id")))
        //                id = (int)rd["id"];
        //        }
        //        rd.Close();

        //        if (id > 0)
        //        {
        //            query = String.Format("insert into featuredata(featureid,val1,val2,val3) values({0},'{1}','{2}','{3}')", id, data1, data2, data3);
        //            cmd = new SQLiteCommand(query, con);
        //            cmd.ExecuteNonQuery();
        //        }
                
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        if (rd != null)
        //            rd.Close();
        //        if (con != null)
        //            con.Close();
        //    }
        //}
        //public int GetSharedId(string name,string val)
        //{
        //    int id = -1;
        //    SQLiteConnection con = null;
        //    SQLiteDataReader rd = null;

        //    try
        //    {
        //        con = new SQLiteConnection(GetConnectionStrng());
        //        con.Open();

        //        string query = String.Format("select id from shared where name like '{0}' and val like '{1}'", name, val);
        //        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        //        {
        //            rd = cmd.ExecuteReader();
        //            if (rd.Read())
        //                if (!rd.IsDBNull(rd.GetOrdinal("id")))
        //                    id = (int)rd["id"];
        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        if (rd != null)
        //            rd.Close();
        //        if (con != null)
        //            con.Close();
        //    }

        //    return id;
        //}
        //public int GetFeaturedDataId(string featureName, int shareId,string val1)
        //{
        //    int id = -1;
        //    SQLiteConnection con = null;
        //    SQLiteDataReader rd = null;

        //    try
        //    {
        //        con = new SQLiteConnection(GetConnectionStrng());
        //        con.Open();

        //        string query = String.Format("select id from featuredata where featurename like '{0}' and shareid={1} and val1 like '{2}'", featureName, shareId, val1);
        //        SQLiteCommand cmd = new SQLiteCommand(query, con);
        //        rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            if (!rd.IsDBNull(rd.GetOrdinal("id")))
        //                id = (int)rd["id"];
        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        if (rd != null)
        //            rd.Close();
        //        if (con != null)
        //            con.Close();
        //    }

        //    return id;
        //}

        #endregion


        #region Indihiang
        public void InsertIndihiang(Indihiang.DomainObject.Indihiang obj)
        {
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into indihiang(asm_version,file_version,updatedate) values('{0}','{1}','{2}')", obj.Asm_Version,obj.File_Version,obj.UpdateDate.ToString());
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {                
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        public List<Indihiang.DomainObject.Indihiang> GetAllIndihiang()
        {
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;
            List<Indihiang.DomainObject.Indihiang> list = new List<Indihiang.DomainObject.Indihiang>();
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = "select id,asm_version,file_version,updatedate from indihiang";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Indihiang.DomainObject.Indihiang obj = new Indihiang.DomainObject.Indihiang();
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        obj.Id = (int)rd["id"];
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("asm_version")))
                        obj.Asm_Version = (string)rd["asm_version"];
                    if (!rd.IsDBNull(rd.GetOrdinal("file_version")))
                        obj.File_Version = (string)rd["file_version"];
                    if (!rd.IsDBNull(rd.GetOrdinal("updatedate")))
                        obj.UpdateDate = (DateTime)rd["updatedate"];
                    else
                        obj.UpdateDate = DateTime.MinValue;

                    list.Add(obj);
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (rd != null)
                    rd.Close();
                if (con != null)
                    con.Close();
            }

            return list;
        }


        #endregion

        #region LogData
        public void InsertLogData(Indihiang.DomainObject.LogData obj)
        {
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into logdata(logdate,logtime) values('{0}','{1}')", obj.LogDate,obj.LogTime);
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        public List<Indihiang.DomainObject.LogData> GetLogDataByFilter(string filter)
        {
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;
            List<Indihiang.DomainObject.LogData> list = new List<Indihiang.DomainObject.LogData>();
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = string.Format("select id,logdate,logtime from logdata where {0}",filter);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Indihiang.DomainObject.LogData obj = new Indihiang.DomainObject.LogData();
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        obj.Id = (int)rd["id"];
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("logdate")))
                        obj.LogDate = (string)rd["logdate"];
                    if (!rd.IsDBNull(rd.GetOrdinal("logtime")))
                        obj.LogTime = (string)rd["logtime"];                   

                    list.Add(obj);

                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (rd != null)
                    rd.Close();
                if (con != null)
                    con.Close();
            }

            return list;
        }

        #endregion

        #region LogItem
        public void InsertLogItem(Indihiang.DomainObject.LogItem obj)
        {
            SQLiteConnection con = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into logitem(id,itemfield,itemvalue) values({0},'{1}','{2}')", obj.Id,obj.ItemField,obj.ItemValue);
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        public List<Indihiang.DomainObject.LogItem> GetLogItemByFilter(string filter)
        {
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;
            List<Indihiang.DomainObject.LogItem> list = new List<Indihiang.DomainObject.LogItem>();
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = string.Format("select id,itemfield,itemvalue where {0}", filter);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Indihiang.DomainObject.LogItem obj = new Indihiang.DomainObject.LogItem();
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        obj.Id = (int)rd["id"];
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("itemfield")))
                        obj.ItemField = (string)rd["itemfield"];
                    if (!rd.IsDBNull(rd.GetOrdinal("itemvalue")))
                        obj.ItemValue = (string)rd["itemvalue"];

                    list.Add(obj);

                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (rd != null)
                    rd.Close();
                if (con != null)
                    con.Close();
            }

            return list;
        }


        #endregion


    }
}
