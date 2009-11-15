using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Indihiang.Cores;
namespace Indihiang.Data
{
    public class LogDataFacade
    {
        private string _guid;

        public LogDataFacade(string guid)
        {
            _guid = guid;
        }

        #region General
        public List<string> GetServerList()
        {
            List<string> servers = new List<string>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);
            
            for (int i = 0; i < files.Count; i++)
            {
                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select distinct server_ip,server_port from log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        string ip;
                        string port;
                        string server;
                        while (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("server_ip")))
                                ip = rd["server_ip"].ToString();
                            else
                                ip = string.Empty;
                            if (!rd.IsDBNull(rd.GetOrdinal("server_port")))
                                port = rd["server_port"].ToString();
                            else
                                port = string.Empty;
                            server = string.Format("{0}:{1}", ip, port);

                            if (!string.IsNullOrEmpty(server) && server != ":")
                            {
                                if (!servers.Contains(server.ToLower()))
                                    servers.Add(server.ToLower());
                            }
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return servers;
        }
        public List<string> GetLogFileList()
        {
            List<string> list = new List<string>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select distinct fullfilename from log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        string file;
                        while (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("fullfilename")))
                                file = rd["fullfilename"].ToString();
                            else
                                file = string.Empty;

                            if (!string.IsNullOrEmpty(file))
                            {
                                if (!list.Contains(file.ToLower()))
                                    list.Add(file.ToLower());
                            }
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public long GetTotalData()
        {
            long total = 0;
            List<string> list = new List<string>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select count(id) from log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                            total = long.Parse(obj.ToString());
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return total;
        }
        #endregion

    }
}
