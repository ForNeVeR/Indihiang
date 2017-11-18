using System;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;
using Oracle.DataAccess.Client;

using Indihiang.Cores;
using Indihiang.Data;
namespace Indihiang.Data
{
    public class OracleDataExport : IndihiangDataExport
    {
        public OracleDataExport() : base() { }

        protected override bool CreateDatabase()
        {
            //string database = string.Format("create database {0};",_db);
            //string conString1 = string.Format("server={0};uid={1};pwd={2}",_svr,_uid,_pwd);
            string conString2 = string.Format("server={0};database={1};uid={2};pwd={3}", _svr, _db, _uid, _pwd);

            string create_tb = @"                    
                    CREATE TABLE [indihiang_data](
                        [id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
                        [fullfilename] [nvarchar](512) NOT NULL,
                        [a_day] [int] NOT NULL,
                        [a_month] [int] NOT NULL,
                        [a_year] [int] NOT NULL,
                        [server_ip] [nvarchar](20) NULL,
                        [server_port] [nvarchar](10) NULL,
                        [client_ip] [nvarchar](20) NULL,
                        [page_access] [nvarchar](512) NULL,
                        [query_page_access] [nvarchar](512) NULL,
                        [access_username] [nvarchar](50) NULL,
                        [user_agent] [nvarchar](50) NULL,
                        [protocol_status] [nvarchar](10) NULL,
                        [bytes_sent] [nvarchar](512) NULL,
                        [bytes_received] [nvarchar](512) NULL,
                        [referer] [nvarchar](512) NULL,
                        [ip_country] [nvarchar](50) NULL,
                        [time_taken] [nvarchar](512) NULL,
                        [referer_class] [nvarchar](50) NULL                    
                    )
            ";


            try
            {
                OracleConnection con = new OracleConnection(conString2);
                con.Open();

                OracleCommand cmd = new OracleCommand(create_tb, con);
                cmd.ExecuteNonQuery();
                
                con.Close();

                return true;

            }
            catch (Exception err)
            {
                _errMessage = err.Message;
            }


            return false;
        }

        protected override bool ExportData()
        {
            bool success = false;
            string year = IndihiangHelper.GetYearDataIndihiangFile(_databaseFile);
            string conString = string.Format("server={0};database={1};uid={2};pwd={3}", _svr, _db, _uid, _pwd);

            if (!string.IsNullOrEmpty(year))
            {
                SQLiteConnection con = null;
                SQLiteDataReader rd = null;
                OracleConnection con2 = null;
                OracleTransaction trans = null;

                con2 = new OracleConnection(conString);
                con2.Open();

                trans = con2.BeginTransaction();
                using (OracleCommand cmd2 = con2.CreateCommand())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("insert into [indihiang_data](fullfilename,a_day,a_month,a_year,server_ip,");
                    builder.Append("server_port,client_ip,page_access,query_page_access,access_username,");
                    builder.Append("user_agent,protocol_status,bytes_sent,bytes_received,referer,ip_country,time_taken,referer_class)");
                    builder.Append(" values(@par1,@par2,@par3,@par4,@par5,@par6,@par7,@par8,@par9,@par10,@par11,@par12,@par13,@par14,@par15,@par16,@par17,@par18)");

                    cmd2.CommandText = builder.ToString();
                    cmd2.Transaction = trans;

                    OracleParameter par1 = new OracleParameter("@par1", DbType.String);
                    cmd2.Parameters.Add(par1);
                    OracleParameter par2 = new OracleParameter("@par2", DbType.Int32);
                    cmd2.Parameters.Add(par2);
                    OracleParameter par3 = new OracleParameter("@par3", DbType.Int32);
                    cmd2.Parameters.Add(par3);
                    OracleParameter par4 = new OracleParameter("@par4", DbType.Int32);
                    cmd2.Parameters.Add(par4);
                    OracleParameter par5 = new OracleParameter("@par5", DbType.String);
                    cmd2.Parameters.Add(par5);
                    OracleParameter par6 = new OracleParameter("@par6", DbType.String);
                    cmd2.Parameters.Add(par6);
                    OracleParameter par7 = new OracleParameter("@par7", DbType.String);
                    cmd2.Parameters.Add(par7);
                    OracleParameter par8 = new OracleParameter("@par8", DbType.String);
                    cmd2.Parameters.Add(par8);
                    OracleParameter par9 = new OracleParameter("@par9", DbType.String);
                    cmd2.Parameters.Add(par9);
                    OracleParameter par10 = new OracleParameter("@par10", DbType.String);
                    cmd2.Parameters.Add(par10);
                    OracleParameter par11 = new OracleParameter("@par11", DbType.String);
                    cmd2.Parameters.Add(par11);
                    OracleParameter par12 = new OracleParameter("@par12", DbType.String);
                    cmd2.Parameters.Add(par12);
                    OracleParameter par13 = new OracleParameter("@par13", DbType.String);
                    cmd2.Parameters.Add(par13);
                    OracleParameter par14 = new OracleParameter("@par14", DbType.String);
                    cmd2.Parameters.Add(par14);
                    OracleParameter par15 = new OracleParameter("@par15", DbType.String);
                    cmd2.Parameters.Add(par15);
                    OracleParameter par16 = new OracleParameter("@par16", DbType.String);
                    cmd2.Parameters.Add(par16);
                    OracleParameter par17 = new OracleParameter("@par17", DbType.String);
                    cmd2.Parameters.Add(par17);
                    OracleParameter par18 = new OracleParameter("@par18", DbType.String);
                    cmd2.Parameters.Add(par18);

                    try
                    {
                        con = new SQLiteConnection(string.Format("Data Source={0}", _databaseFile));
                        con.Open();

                        string query = "select * from log_data";
                        SQLiteCommand cmd = new SQLiteCommand(query, con);
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            par1.Value = rd["fullfilename"];
                            par2.Value = rd["a_day"];
                            par3.Value = rd["a_month"];
                            par4.Value = Convert.ToInt32(year);
                            par5.Value = rd["server_ip"];
                            par6.Value = rd["server_port"];
                            par7.Value = rd["client_ip"];
                            par8.Value = rd["page_access"];
                            par9.Value = rd["query_page_access"];
                            par10.Value = rd["access_username"];
                            par11.Value = rd["user_agent"];
                            par12.Value = rd["protocol_status"];
                            par13.Value = rd["bytes_sent"];
                            par14.Value = rd["bytes_received"];
                            par15.Value = rd["referer"];
                            par16.Value = rd["ip_country"];
                            par17.Value = rd["time_taken"];
                            par18.Value = rd["referer_class"];

                            cmd2.ExecuteNonQuery();
                        }
                        trans.Commit();
                        con2.Close();
                        success = true;

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
                }
            }

            return success;
        }
    }
}
