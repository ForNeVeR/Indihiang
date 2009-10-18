﻿using System;


namespace Indihiang.DomainObject
{
    public class DumpData
    {
        private int _id;
        private string _fullFileName;
        private int _a_day;
        private int _a_month;
        private int _a_year;
        private string _server_ip;
        private string _server_port;
        private string _client_ip;
        private string _page_access;
        private string _query_page_access;
        private string _access_username;
        private string _user_agent;
        private string _protocol_status;
        private string _bytes_sent;
        private string _bytes_received;
        private string _referer;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                    return;
                _id = value;
            }
        }
        public string FullFileName
        {
            get
            {
                return _fullFileName;
            }
            set
            {
                if (_fullFileName == value)
                    return;
                _fullFileName = value;
            }
        }
        public int Day
        {
            get
            {
                return _a_day;
            }
            set
            {
                if (_a_day == value)
                    return;
                _a_day = value;
            }
        }
        public int Month
        {
            get
            {
                return _a_month;
            }
            set
            {
                if (_a_month == value)
                    return;
                _a_month = value;
            }
        }
        public int Year
        {
            get
            {
                return _a_year;
            }
            set
            {
                if (_a_year == value)
                    return;
                _a_year = value;
            }
        }
        public string Server_IP
        {
            get
            {
                return _server_ip;
            }
            set
            {
                if (_server_ip == value)
                    return;
                _server_ip = value;
            }
        }
        public string Server_Port
        {
            get
            {
                return _server_port;
            }
            set
            {
                if (_server_port == value)
                    return;
                _server_port = value;
            }
        }
        public string Client_IP
        {
            get
            {
                return _client_ip;
            }
            set
            {
                if (_client_ip == value)
                    return;
                _client_ip = value;
            }
        }
        public string Page_Access
        {
            get
            {
                return _page_access;
            }
            set
            {
                if (_page_access == value)
                    return;
                _page_access = value;
            }
        }
        public string Query_Page_Access
        {
            get
            {
                return _query_page_access;
            }
            set
            {
                if (_query_page_access == value)
                    return;
                _query_page_access = value;
            }
        }
        public string Access_Username
        {
            get
            {
                return _access_username;
            }
            set
            {
                if (_access_username == value)
                    return;
                _access_username = value;
            }
        }
        public string User_Agent
        {
            get
            {
                return _user_agent;
            }
            set
            {
                if (_user_agent == value)
                    return;
                _user_agent = value;
            }
        }
        public string Protocol_Status
        {
            get
            {
                return _protocol_status;
            }
            set
            {
                if (_protocol_status == value)
                    return;
                _protocol_status = value;
            }
        }
        public string Bytes_Sent
        {
            get
            {
                return _bytes_sent;
            }
            set
            {
                if (_bytes_sent == value)
                    return;
                _bytes_sent = value;
            }
        }
        public string Bytes_Received
        {
            get
            {
                return _bytes_received;
            }
            set
            {
                if (_bytes_received == value)
                    return;
                _bytes_received = value;
            }
        }
        public string Referer
        {
            get
            {
                return _referer;
            }
            set
            {
                if (_referer == value)
                    return;
                _referer = value;
            }
        }

        public DumpData() { }
       
    }
}
