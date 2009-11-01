using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;
using Indihiang.Cores;

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
        public int InsertIndihiang(Indihiang.DomainObject.Indihiang obj)
        {
            SQLiteConnection con = null;
            int id = -1;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into indihiang(asm_version,file_version,updatedate) values('{0}','{1}','{2}');select last_insert_rowid();", obj.Asm_Version, obj.File_Version, obj.UpdateDate.ToString());
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return id;
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
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
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
        public int InsertLogData(Indihiang.DomainObject.LogData obj)
        {
            SQLiteConnection con = null;
            int id = -1;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into logdata(logdate,logtime) values('{0}','{1}');select last_insert_rowid();", obj.LogDate, obj.LogTime);
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return id;
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
                        obj.Id = Convert.ToInt32(rd["id"].ToString());
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("logdate")))
                        obj.LogDate = (string)rd["logdate"];
                    if (!rd.IsDBNull(rd.GetOrdinal("logtime")))
                        obj.LogTime = (string)rd["logtime"];                   

                    list.Add(obj);

                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
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
        public void InsertLogItem(List<Indihiang.DomainObject.LogItem> list)
        {
            SQLiteConnection con = null;
            SQLiteTransaction trans = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                trans = con.BeginTransaction();
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    SQLiteParameter par1 = new SQLiteParameter();
                    SQLiteParameter par2 = new SQLiteParameter();
                    SQLiteParameter par3 = new SQLiteParameter();

                    cmd.CommandText = "insert into [logitem](id,itemfield,itemvalue) values(?,?,?)";
                    cmd.Parameters.Add(par1);
                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);

                    for (int i = 0; i < list.Count; i++)
                    {
                        //par1.Value = list[i].Id;
                        par2.Value = list[i].ItemField;
                        par3.Value = list[i].ItemValue;

                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                //string query = String.Format("insert into logitem(id,itemfield,itemvalue) values({0},'{1}','{2}')", obj.Id,obj.ItemField,obj.ItemValue);
                //using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                //{
                //    cmd.ExecuteNonQuery();
                //}

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
                if (trans != null)
                    trans.Rollback();
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
                        obj.Id = Convert.ToInt32(rd["id"].ToString());
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("itemfield")))
                        obj.ItemField = (string)rd["itemfield"];
                    if (!rd.IsDBNull(rd.GetOrdinal("itemvalue")))
                        obj.ItemValue = (string)rd["itemvalue"];

                    list.Add(obj);

                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
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


        #region DumpData
        public bool InsertBulkDumpData(List<Indihiang.DomainObject.DumpData> dump)
        {
            bool success = false;
            SQLiteConnection con = null;
            DbTransaction trans = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                trans = con.BeginTransaction();
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("insert into [log_data](fullfilename,a_day,a_month,server_ip,");
                    builder.Append("server_port,client_ip,page_access,query_page_access,access_username,");
                    builder.Append("user_agent,protocol_status,bytes_sent,bytes_received,referer)");
                    builder.Append(" values(@par1,@par2,@par3,@par4,@par5,@par6,@par7,@par8,@par9,@par10,@par11,@par12,@par13,@par14)");

                    cmd.CommandText = builder.ToString();

                    SQLiteParameter par1 = cmd.Parameters.Add("@par1", DbType.String);
                    SQLiteParameter par2 = cmd.Parameters.Add("@par2", DbType.Int32);
                    SQLiteParameter par3 = cmd.Parameters.Add("@par3", DbType.Int32);
                    SQLiteParameter par4 = cmd.Parameters.Add("@par4", DbType.String);
                    SQLiteParameter par5 = cmd.Parameters.Add("@par5", DbType.String);
                    SQLiteParameter par6 = cmd.Parameters.Add("@par6", DbType.String);
                    SQLiteParameter par7 = cmd.Parameters.Add("@par7", DbType.String);
                    SQLiteParameter par8 = cmd.Parameters.Add("@par8", DbType.String);
                    SQLiteParameter par9 = cmd.Parameters.Add("@par9", DbType.String);
                    SQLiteParameter par10 = cmd.Parameters.Add("@par10", DbType.String);
                    SQLiteParameter par11 = cmd.Parameters.Add("@par11", DbType.String);
                    SQLiteParameter par12 = cmd.Parameters.Add("@par12", DbType.String);
                    SQLiteParameter par13 = cmd.Parameters.Add("@par13", DbType.String);
                    SQLiteParameter par14 = cmd.Parameters.Add("@par14", DbType.String);

                    //SQLiteParameter par1 = cmd.Parameters.Add("@par1", DbType.String);
                    //SQLiteParameter par2 = cmd.Parameters.Add("@par2", DbType.Int32);
                    //SQLiteParameter par3 = cmd.Parameters.Add("@par3", DbType.Int32);
                    //SQLiteParameter par4 = cmd.Parameters.Add("@par4", DbType.String);
                    //SQLiteParameter par5 = cmd.Parameters.Add("@par5", DbType.String);
                    //SQLiteParameter par6 = cmd.Parameters.Add("@par6", DbType.String);
                    //SQLiteParameter par7 = cmd.Parameters.Add("@par7", DbType.String);
                    //SQLiteParameter par8 = cmd.Parameters.Add("@par8", DbType.String);
                    //SQLiteParameter par9 = cmd.Parameters.Add("@par9", DbType.String);
                    //SQLiteParameter par10 = cmd.Parameters.Add("@par10", DbType.String);
                    //SQLiteParameter par11 = cmd.Parameters.Add("@par11", DbType.String);
                    //SQLiteParameter par12 = cmd.Parameters.Add("@par12", DbType.String);
                    //SQLiteParameter par13 = cmd.Parameters.Add("@par13", DbType.String);
                    //SQLiteParameter par14 = cmd.Parameters.Add("@par14", DbType.String);

                    for (int i = 0; i < dump.Count; i++)
                    {                       
                        par1.Value = dump[i].FullFileName;                        
                        par2.Value = dump[i].Day;
                        par3.Value = dump[i].Month;
                        par4.Value = IndihiangHelper.GetStringLogItem(dump[i].Server_IP);
                        par5.Value = IndihiangHelper.GetStringLogItem(dump[i].Server_Port);
                        par6.Value = IndihiangHelper.GetStringLogItem(dump[i].Client_IP);
                        par7.Value = IndihiangHelper.GetStringLogItem(dump[i].Page_Access);
                        par8.Value = IndihiangHelper.GetStringLogItem(dump[i].Query_Page_Access);
                        par9.Value = IndihiangHelper.GetStringLogItem(dump[i].Access_Username);
                        par10.Value = IndihiangHelper.GetStringLogItem(dump[i].User_Agent);
                        par11.Value = IndihiangHelper.GetStringLogItem(dump[i].Protocol_Status);
                        par12.Value = IndihiangHelper.GetStringLogItem(dump[i].Bytes_Sent);
                        par13.Value = IndihiangHelper.GetStringLogItem(dump[i].Bytes_Received);
                        par14.Value = IndihiangHelper.GetStringLogItem(dump[i].Referer);

                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                success = true;

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return success;
        }

        

        #endregion

    }
}
