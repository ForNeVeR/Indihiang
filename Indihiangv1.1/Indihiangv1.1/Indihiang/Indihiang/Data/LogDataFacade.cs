using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Indihiang.Cores;
using Indihiang.DomainObject;
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
                            total = total + long.Parse(obj.ToString());
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return total;
        }
        public List<DateTime> GetTimeLogFileList()
        {
            List<DateTime> list = new List<DateTime>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                int year = Convert.ToInt32(fileName.Substring(3));
                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    
                    string sqlQuery = "select distinct a_month,a_day from log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        int month, day;
                        while (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("a_month")))
                                month = Convert.ToInt32(rd["a_month"].ToString());
                            else
                                month = 1;
                            if (!rd.IsDBNull(rd.GetOrdinal("a_day")))
                                day = Convert.ToInt32(rd["a_day"].ToString());
                            else
                                day = 1;

                            DateTime dt = new DateTime(year, month, day);
                            list.Add(dt);
                         
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<string> GetListyearLogFile()
        {
            List<string> years = new List<string>();               
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                int year = Convert.ToInt32(fileName.Substring(3));

                if (!years.Contains(year.ToString()))
                    years.Add(year.ToString());
            }

            return years;
        }
        public List<string> GetMonthLogFileListByYear(string year)
        {
            List<string> list = new List<string>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                string currentYear = fileName.Substring(3);

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select distinct a_month from log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        string month;
                        while (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("a_month")))
                                month = rd["a_month"].ToString();
                            else
                                month = string.Empty;

                            if (!string.IsNullOrEmpty(month))
                            {
                                if (!list.Contains(month.ToLower()))
                                    list.Add(month.ToLower());
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
        #endregion

        #region User Agent
        public Dictionary<string, long> GetTotalPerUserAgent()
        {
            Dictionary<string, long> list = new Dictionary<string, long>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select user_agent, count(id) as total from log_data GROUP BY user_agent";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        string userAgent;
                        long total;
                        while (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("user_agent")))
                                userAgent = rd["user_agent"].ToString();
                            else
                                userAgent = string.Empty;
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                total = long.Parse(rd["total"].ToString());
                            else
                                total = 0;


                            if (!list.ContainsKey(userAgent))
                                list.Add(userAgent, total);
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<DumpData> GetTotalPerUserAgentByParams(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select user_agent, a_month, COUNT(id) AS total from log_data group by user_agent, a_month";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData(); 
                            if (!rd.IsDBNull(rd.GetOrdinal("user_agent")))
                                obj.User_Agent = rd["user_agent"].ToString();
                            else
                                obj.User_Agent = string.Empty;
                            if (!rd.IsDBNull(rd.GetOrdinal("a_month")))
                                obj.Month = Convert.ToInt32(rd["a_month"].ToString());
                            else
                                obj.Month = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                obj.Total = long.Parse(rd["total"].ToString());
                            else
                                obj.Total = 0;


                            list.Add(obj);
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<DumpData> GetTotalPerUserAgentByParams(int year,int month)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = String.Format("select user_agent, a_month, a_day, COUNT(id) AS total from log_data where (a_month = {0}) GROUP BY user_agent,a_day", month);
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            obj.Month = month;
                            if (!rd.IsDBNull(rd.GetOrdinal("user_agent")))
                                obj.User_Agent = rd["user_agent"].ToString();
                            else
                                obj.User_Agent = string.Empty;
                            if (!rd.IsDBNull(rd.GetOrdinal("a_day")))
                                obj.Day = Convert.ToInt32(rd["a_day"].ToString());
                            else
                                obj.Day = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                obj.Total = Convert.ToInt32(rd["total"].ToString());
                            else
                                obj.Total = 0;
                            

                            list.Add(obj);
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        #endregion

    }
}
