using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace Indihiang.Data
{
    public class DataHelper
    {
        private string _dbFile;

        public DataHelper(string file)
        {
            _dbFile = file;
        }
        private string GetConnectionStrng()
        {
            return string.Format("Data Source={0}",_dbFile);
        }
        public void InsertFeature(string name,string field)
        {
            SQLiteConnection con = null;

            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into feature(name,field) values('{0}','{1}')", name,field);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
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
        public void InsertShared(string name, string val)
        {
            SQLiteConnection con = null;

            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("insert into shared(name,val) values('{0}','{1}')", name, val);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
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
        public void InsertFeatureData(string featureName, string field,string data)
        {
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;
            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                int id = -1;
                string query = String.Format("select id from feature where name like '{0}' and field like '{1}'", featureName, field);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        id = (int)rd["id"];
                }
                rd.Close();

                if (id > 0)
                {
                    query = String.Format("insert into featuredata(featureid,val) values({0},'{1}')", id, data);
                    cmd = new SQLiteCommand(query, con);
                    cmd.ExecuteNonQuery();
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
        }
        public int GetSharedId(string name,string val)
        {
            int id = -1;
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;

            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = String.Format("select id from shared where name like '{0}' and val like '{1}'", name, val);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (!rd.IsDBNull(rd.GetOrdinal("id")))
                        id = (int)rd["id"];
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

            return id;
        }
        
    }
}
