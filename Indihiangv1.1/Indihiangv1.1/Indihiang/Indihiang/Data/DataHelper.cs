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

        #region Indihiang
        public int InsertIndihiang(Indihiang.DomainObject.Indihiang obj)
        {
            SQLiteConnection con = null;
            int id = -1;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into sys_indihiang(sys_item,sys_value) values('{0}','{1}')", obj.Sys_Item, obj.Sys_Value);
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
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

                string query = "select * from sys_indihiang";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Indihiang.DomainObject.Indihiang obj = new Indihiang.DomainObject.Indihiang();
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        obj.Id = Convert.ToInt32(rd["id"].ToString());
                    else
                        obj.Id = -1;
                    if (!rd.IsDBNull(rd.GetOrdinal("sys_item")))
                        obj.Sys_Item = (string)rd["sys_item"];
                    else
                        obj.Sys_Item = "";
                    if (!rd.IsDBNull(rd.GetOrdinal("sys_value")))
                        obj.Sys_Value = (string)rd["sys_value"];
                    else
                        obj.Sys_Value = "";

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
                    builder.Append("user_agent,protocol_status,bytes_sent,bytes_received,referer,ip_country,time_taken,referer_class)");
                    builder.Append(" values(@par1,@par2,@par3,@par4,@par5,@par6,@par7,@par8,@par9,@par10,@par11,@par12,@par13,@par14,@par15,@par16,@par17)");

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
                    SQLiteParameter par15 = cmd.Parameters.Add("@par15", DbType.String);
                    SQLiteParameter par16 = cmd.Parameters.Add("@par16", DbType.String);
                    SQLiteParameter par17 = cmd.Parameters.Add("@par17", DbType.String);

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
                        par12.Value = dump[i].Bytes_Sent;
                        par13.Value = dump[i].Bytes_Received;
                        par14.Value = IndihiangHelper.GetStringLogItem(dump[i].Referer);
                        par15.Value = IndihiangHelper.GetStringLogItem(dump[i].IPClientCountry);
                        par16.Value = dump[i].TimeTaken;
                        par17.Value = IndihiangHelper.GetStringLogItem(dump[i].RefererClass);

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
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return success;
        }                

        #endregion

        #region IP Country

        public string GetCountryName(double ipDouble)
        {
            SQLiteConnection con = null;
            string country = "";
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = string.Format("SELECT country_name FROM ip_country WHERE ({0} BETWEEN ip_start AND ip_end)", ipDouble);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                object obj = cmd.ExecuteScalar();

                if (obj != null)
                    country = obj.ToString();

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

            return country;
        }

        public List<Indihiang.DomainObject.IPCountry> GetAllIpCountry()
        {
			List<Indihiang.DomainObject.IPCountry> list = new List<Indihiang.DomainObject.IPCountry>();

			if (Indihiang.Properties.Settings.Default.FindCountries == false)
				return list;

            SQLiteConnection con = null;
            SQLiteDataReader rd = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = "SELECT ip_start,ip_end,country_name FROM ip_country";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Indihiang.DomainObject.IPCountry obj = new Indihiang.DomainObject.IPCountry();
                    if (!rd.IsDBNull(rd.GetOrdinal("ip_start")))
                        obj.IpStart = Convert.ToDouble(rd["ip_start"]);
                    else
                        obj.IpStart = 0;
                    if (!rd.IsDBNull(rd.GetOrdinal("ip_end")))
                        obj.IpEnd = Convert.ToDouble(rd["ip_end"]);
                    else
                        obj.IpEnd = 0;
                    if (!rd.IsDBNull(rd.GetOrdinal("country_name")))
                        obj.CoutryName = (string)rd["country_name"];
                   

                    list.Add(obj);

                }

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.StackTrace);

				System.Windows.Forms.MessageBox.Show("There was an error reading the country IP ranges.\n\nHave you installed the \'ipcountry.db\' database into (User Profile Application Data)\\Indihiang\\Media?\n\nException: " + err.Message, "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
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
