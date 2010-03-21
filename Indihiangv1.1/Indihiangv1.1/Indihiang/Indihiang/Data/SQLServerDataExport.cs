using System;
using System.Text;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;

using Indihiang.Cores;
using Indihiang.Data;
namespace Indihiang.Data
{
    public class SQLServerDataExport : IndihiangDataExport
    {
        public SQLServerDataExport():base(){ }

        protected override bool CreateDatabase()
        {
            string database = string.Format("create database {0};",_db);
            string conString1 = string.Format("server={0};uid={1};pwd={2}",_svr,_uid,_pwd);
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
                SqlConnection con = new SqlConnection(conString1);
                con.Open();

                SqlCommand cmd = new SqlCommand(database, con);
                cmd.ExecuteNonQuery();

                con.Close();
                con.ConnectionString = conString2;
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = create_tb;
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
                SqlConnection con2 = null;
                SqlTransaction trans = null;

                con2 = new SqlConnection(conString);
                con2.Open();

                trans = con2.BeginTransaction();
                using (SqlCommand cmd2 = con2.CreateCommand())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("insert into [indihiang_data](fullfilename,a_day,a_month,a_year,server_ip,");
                    builder.Append("server_port,client_ip,page_access,query_page_access,access_username,");
                    builder.Append("user_agent,protocol_status,bytes_sent,bytes_received,referer,ip_country,time_taken,referer_class)");
                    builder.Append(" values(@par1,@par2,@par3,@par4,@par5,@par6,@par7,@par8,@par9,@par10,@par11,@par12,@par13,@par14,@par15,@par16,@par17,@par18)");

                    cmd2.CommandText = builder.ToString();
                    cmd2.Transaction = trans;

                    SqlParameter par1 = new SqlParameter("@par1", DbType.String);
                    cmd2.Parameters.Add(par1);
                    SqlParameter par2 = new SqlParameter("@par2", DbType.Int32);
                    cmd2.Parameters.Add(par2);
                    SqlParameter par3 = new SqlParameter("@par3", DbType.Int32);
                    cmd2.Parameters.Add(par3);
                    SqlParameter par4 = new SqlParameter("@par4", DbType.Int32);
                    cmd2.Parameters.Add(par4);
                    SqlParameter par5 = new SqlParameter("@par5", DbType.String);
                    cmd2.Parameters.Add(par5);
                    SqlParameter par6 = new SqlParameter("@par6", DbType.String);
                    cmd2.Parameters.Add(par6);
                    SqlParameter par7 = new SqlParameter("@par7", DbType.String);
                    cmd2.Parameters.Add(par7);
                    SqlParameter par8 = new SqlParameter("@par8", DbType.String);
                    cmd2.Parameters.Add(par8);
                    SqlParameter par9 = new SqlParameter("@par9", DbType.String);
                    cmd2.Parameters.Add(par9);
                    SqlParameter par10 = new SqlParameter("@par10", DbType.String);
                    cmd2.Parameters.Add(par10);
                    SqlParameter par11 = new SqlParameter("@par11", DbType.String);
                    cmd2.Parameters.Add(par11);
                    SqlParameter par12 = new SqlParameter("@par12", DbType.String);
                    cmd2.Parameters.Add(par12);
                    SqlParameter par13 = new SqlParameter("@par13", DbType.String);
                    cmd2.Parameters.Add(par13);
                    SqlParameter par14 = new SqlParameter("@par14", DbType.String);
                    cmd2.Parameters.Add(par14);
                    SqlParameter par15 = new SqlParameter("@par15", DbType.String);
                    cmd2.Parameters.Add(par15);
                    SqlParameter par16 = new SqlParameter("@par16", DbType.String);
                    cmd2.Parameters.Add(par16);
                    SqlParameter par17 = new SqlParameter("@par17", DbType.String);
                    cmd2.Parameters.Add(par17);
                    SqlParameter par18 = new SqlParameter("@par18", DbType.String);
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
