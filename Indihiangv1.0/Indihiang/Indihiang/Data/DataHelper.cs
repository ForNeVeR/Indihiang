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
        public void InsertFeature(string featureName)
        {
            SQLiteConnection con = null;
            SQLiteDataReader rd = null;

            try
            {
                con = new SQLiteConnection(GetConnectionStrng());
                con.Open();

                string query = "select * from feature where";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
            }
            catch (Exception)
            {

            }
        }
    }
}
