using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;

using Indihiang.Cores;
using Indihiang.DomainObject;
namespace Indihiang.Data
{
    public class LogDataFacade
    {
        private string _guid;

        private LogDataFacade() { }
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
        public long GetTotalData(int year)
        {
            long total = 0;
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT COUNT(id) AS total FROM log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                total = long.Parse(rd["total"].ToString());
                        }
                        rd.Close();
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
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
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
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
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
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
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
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
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
        public List<DumpData> GetTotalPerUserAgentByParams(int year, int month)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
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
                            DumpData obj = new DumpData { Month = month };
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

        #region Hits
        public List<DumpData> GetHitsByParams(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select a_month, a_day, COUNT(id) AS total from log_data GROUP BY a_month,a_day";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("a_day")))
                                obj.Day = Convert.ToInt32(rd["a_day"].ToString());
                            else
                                obj.Day = 0;
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
        public List<DumpData> GetMonthHitsByParams(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "select a_month,COUNT(id) AS total from log_data GROUP BY a_month";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
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
        #endregion

        #region Access

        public List<DumpData> GetTop5OfAccessPageByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT page_access, a_month, COUNT(id) AS total FROM log_data GROUP BY page_access ORDER BY total DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        int total = 0;
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("page_access")))
                                obj.Page_Access = rd["page_access"].ToString();
                            else
                                obj.Page_Access = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("a_month")))
                                obj.Month = Convert.ToInt32(rd["a_month"].ToString());
                            else
                                obj.Month = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                obj.Total = long.Parse(rd["total"].ToString());
                            else
                                obj.Total = 0;


                            list.Add(obj);
                            total++;

                            if (total > 5)
                                break;
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<DumpData> GetAccessPageByYearMonth(int year, int month)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = string.Format("SELECT page_access,a_day, COUNT(id) AS total FROM log_data WHERE (a_month = {0}) GROUP BY page_access ORDER BY total DESC", month);
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("page_access")))
                                obj.Page_Access = rd["page_access"].ToString();
                            else
                                obj.Page_Access = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("a_day")))
                                obj.Day = Convert.ToInt32(rd["a_day"]);
                            else
                                obj.Day = -1;
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
        #endregion

        #region IP Address
        public List<DumpData> GetIPaddressAccessByYear(int year, long limit)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT client_ip,ip_country, COUNT(id) AS total FROM log_data GROUP BY client_ip,ip_country ORDER BY total DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        int total = 0;
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("client_ip")))
                                obj.Client_IP = rd["client_ip"].ToString();
                            else
                                obj.Client_IP = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("ip_country")))
                            {
                                obj.IPClientCountry = rd["ip_country"].ToString();
                                if (string.IsNullOrEmpty(obj.IPClientCountry))
                                    obj.IPClientCountry = "(?)";
                            }
                            else
                                obj.IPClientCountry = "(?)";
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                obj.Total = long.Parse(rd["total"].ToString());
                            else
                                obj.Total = 0;

                            list.Add(obj);
                            total++;

                            if (limit > 0)
                            {
                                if (total > (limit - 1))
                                    break;
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
        public List<string> GetListIPaddressByYear(int year)
        {
            List<string> list = new List<string>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT DISTINCT client_ip FROM log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            string ip = rd["client_ip"].ToString();

                            list.Add(ip);
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<DumpData> GetIPaddressAccessByYear(int year, string clientIp)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = string.Format("SELECT page_access,COUNT(id) AS total FROM log_data WHERE (client_ip = '{0}') GROUP BY page_access ORDER BY total DESC", clientIp);
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("page_access")))
                                obj.Page_Access = rd["page_access"].ToString();
                            else
                                obj.Page_Access = "";                            
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
        #endregion

        #region HTTP Status
        public List<DumpData> GetHttpStatusAccessByYear(int year, long limit)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT protocol_status, COUNT(id) AS total FROM log_data GROUP BY protocol_status ORDER BY total DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        int total = 0;
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("protocol_status")))
                                obj.Protocol_Status = rd["protocol_status"].ToString();
                            else
                                obj.Protocol_Status = "";
                            
                            if (!rd.IsDBNull(rd.GetOrdinal("total")))
                                obj.Total = long.Parse(rd["total"].ToString());
                            else
                                obj.Total = 0;

                            list.Add(obj);
                            total++;

                            if (limit > 0)
                            {
                                if (total > (limit - 1))
                                    break;
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

        #region Bandwidth

        public List<long> GetTotalSentReceivedBytesByYear(int year)
        {
            List<long> list = new List<long>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT SUM(bytes_sent) AS totalsent, SUM(bytes_received) AS totalreceived FROM log_data";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            if (!rd.IsDBNull(rd.GetOrdinal("totalsent")))
                                list.Add(Convert.ToInt64(rd["totalsent"]));
                            else
                                list.Add(0);

                            if (!rd.IsDBNull(rd.GetOrdinal("totalreceived")))
                                list.Add(Convert.ToInt64(rd["totalreceived"]));
                            else
                                list.Add(0);                           
                        }
                        rd.Close();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }

            return list;
        }
        public List<DumpData> GetSentReceivedBytesByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT a_month, a_day, SUM(bytes_sent) AS total_bytes_sent, SUM(bytes_received) AS total_bytes_received FROM log_data GROUP BY a_month, a_day";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("a_day")))
                                obj.Day = Convert.ToInt32(rd["a_day"].ToString());
                            else
                                obj.Day = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("a_month")))
                                obj.Month = Convert.ToInt32(rd["a_month"].ToString());
                            else
                                obj.Month = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_sent")))
                                obj.Bytes_Sent = long.Parse(rd["total_bytes_sent"].ToString());
                            else
                                obj.Bytes_Sent = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_received")))
                                obj.Bytes_Received = long.Parse(rd["total_bytes_received"].ToString());
                            else
                                obj.Bytes_Received = 0;

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
        public List<DumpData> GetPageAccessSentReceivedBytesByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT page_access, SUM(bytes_sent) AS total_bytes_sent, SUM(bytes_received) AS total_bytes_received FROM log_data GROUP BY page_access";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("page_access")))
                                obj.Page_Access = rd["page_access"].ToString();
                            else
                                obj.Page_Access = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_sent")))
                                obj.Bytes_Sent = long.Parse(rd["total_bytes_sent"].ToString());
                            else
                                obj.Bytes_Sent = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_received")))
                                obj.Bytes_Received = long.Parse(rd["total_bytes_received"].ToString());
                            else
                                obj.Bytes_Received = 0;

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
        public List<DumpData> GetClientIPSentReceivedBytesByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT client_ip, ip_country, SUM(bytes_sent) AS total_bytes_sent, SUM(bytes_received) AS total_bytes_received FROM log_data GROUP BY client_ip";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("client_ip")))
                                obj.Client_IP = rd["client_ip"].ToString();
                            else
                                obj.Client_IP = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("ip_country")))
                                obj.IPClientCountry = rd["ip_country"].ToString();
                            else
                                obj.IPClientCountry = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_sent")))
                                obj.Bytes_Sent = long.Parse(rd["total_bytes_sent"].ToString());
                            else
                                obj.Bytes_Sent = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_received")))
                                obj.Bytes_Received = long.Parse(rd["total_bytes_received"].ToString());
                            else
                                obj.Bytes_Received = 0;

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

        #region Request Processing

        public List<DumpData> GetRequestProcessingByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT page_access, query_page_access, COUNT(id) AS total_data, SUM(time_taken) AS total_time_taken, SUM(bytes_sent) AS total_bytes_sent, SUM(bytes_received) AS total_bytes_received FROM log_data GROUP BY page_access, query_page_access";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("page_access")))
                                obj.Page_Access = rd["page_access"].ToString();
                            else
                                obj.Page_Access = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("query_page_access")))
                                obj.Query_Page_Access = rd["query_page_access"].ToString();
                            else
                                obj.Query_Page_Access = "";

                            if (!rd.IsDBNull(rd.GetOrdinal("total_data")))
                                obj.Total = long.Parse(rd["total_data"].ToString());
                            else
                                obj.Total = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_sent")))
                                obj.Bytes_Sent = long.Parse(rd["total_bytes_sent"].ToString());
                            else
                                obj.Bytes_Sent = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_bytes_received")))
                                obj.Bytes_Received = long.Parse(rd["total_bytes_received"].ToString());
                            else
                                obj.Bytes_Received = 0;
                            if (!rd.IsDBNull(rd.GetOrdinal("total_time_taken")))
                                obj.TimeTaken = long.Parse(rd["total_time_taken"].ToString());
                            else
                                obj.TimeTaken = 0;

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

        #region Referer

        public List<DumpData> GetRefererByYear(int year)
        {
            List<DumpData> list = new List<DumpData>();
            List<string> files = IndihiangHelper.GetIndihiangFileList(_guid);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                int currentYear = Convert.ToInt32(fileName.Substring(3));

                if (currentYear != year)
                    continue;

                string strCon = string.Format("Data Source={0};ReadOnly=true", files[i]);
                using (SQLiteConnection conn = new SQLiteConnection(strCon))
                {
                    conn.Open();
                    string sqlQuery = "SELECT referer, referer_class, COUNT(id) AS total_data FROM log_data GROUP BY referer";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SQLiteDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            DumpData obj = new DumpData();
                            if (!rd.IsDBNull(rd.GetOrdinal("referer")))
                                obj.Referer = rd["referer"].ToString();
                            else
                                obj.Referer = "";
                            if (!rd.IsDBNull(rd.GetOrdinal("referer_class")))
                                obj.RefererClass = rd["referer_class"].ToString();
                            else
                                obj.RefererClass = "Unknown/No Data";

                            if (!rd.IsDBNull(rd.GetOrdinal("total_data")))
                                obj.Total = long.Parse(rd["total_data"].ToString());
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
