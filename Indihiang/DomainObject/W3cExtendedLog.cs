using System;

namespace Pe.Indhiang.Framework.Core.DomainObject
{
    public class W3cExtendedLog 
    {
        private string _date;
        private string _time;
        private string _c_ip;
        private string _cs_username;
        private string _s_sitename;
        private string _s_computername;
        private string _s_ip;
        private string _s_port;
        private string _cs_method;
        private string _cs_uri_stem;
        private string _cs_uri_query;
        private string _cs_status;
        private string _sc_win32_status;
        private string _sc_bytes;
        private string _time_taken;
        private string _cs_version;
        private string _cs_host;
        private string _cs_user_agent;
        private string _cs_cookie;
        private string _cs_referer;

        public string LogDate
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date == value)
                    return;
                _date = value;
            }
        }
        public string LogTime
        {
            get
            {
                return _time;
            }
            set
            {
                if (_time == value)
                    return;
                _time = value;
            }
        }
        public string ClientIP
        {
            get
            {
                return _c_ip;
            }
            set
            {
                if (_c_ip == value)
                    return;
                _c_ip = value;
            }
        }
        public string UserName
        {
            get
            {
                return _cs_username;
            }
            set
            {
                if (_cs_username == value)
                    return;
                _cs_username = value;
            }
        }
        public string SiteName
        {
            get
            {
                return _s_sitename;
            }
            set
            {
                if (_s_sitename == value)
                    return;
                _s_sitename = value;
            }
        }
        public string ComputerName
        {
            get
            {
                return _s_computername;
            }
            set
            {
                if (_s_computername == value)
                    return;
                _s_computername = value;
            }
        }
        public string ServerIP
        {
            get
            {
                return _s_ip;
            }
            set
            {
                if (_s_ip == value)
                    return;
                _s_ip = value;
            }
        }
        public string Port
        {
            get
            {
                return _s_port;
            }
            set
            {
                if (_s_port == value)
                    return;
                _s_port = value;
            }
        }
        public string Method
        {
            get
            {
                return _cs_method;
            }
            set
            {
                if (_cs_method == value)
                    return;
                _cs_method = value;
            }
        }
        public string UriStem
        {
            get
            {
                return _cs_uri_stem;
            }
            set
            {
                if (_cs_uri_stem == value)
                    return;
                _cs_uri_stem = value;
            }
        }
        public string UriQuery
        {
            get
            {
                return _cs_uri_query;
            }
            set
            {
                if (_cs_uri_query == value)
                    return;
                _cs_uri_query = value;
            }
        }
        public string Status
        {
            get
            {
                return _cs_status;
            }
            set
            {
                if (_cs_status == value)
                    return;
                _cs_status = value;
            }
        }
        public string Win32Status
        {
            get
            {
                return _sc_win32_status;
            }
            set
            {
                if (_sc_win32_status == value)
                    return;
                _sc_win32_status = value;
            }
        }
        public string Bytes
        {
            get
            {
                return _sc_bytes;
            }
            set
            {
                if (_sc_bytes == value)
                    return;
                _sc_bytes = value;
            }
        }
        public string TimeTaken
        {
            get
            {
                return _time_taken;
            }
            set
            {
                if (_time_taken == value)
                    return;
                _time_taken = value;
            }
        }
        public string Version
        {
            get
            {
                return _cs_version;
            }
            set
            {
                if (_cs_version == value)
                    return;
                _cs_version = value;
            }
        }
        public string Host
        {
            get
            {
                return _cs_host;
            }
            set
            {
                if (_cs_host == value)
                    return;
                _cs_host = value;
            }
        }
        public string UserAgent
        {
            get
            {
                return _cs_user_agent;
            }
            set
            {
                if (_cs_user_agent == value)
                    return;
                _cs_user_agent = value;
            }
        }
        public string Cookie
        {
            get
            {
                return _cs_cookie;
            }
            set
            {
                if (_cs_cookie == value)
                    return;
                _cs_cookie = value;
            }
        }
        public string Referer
        {
            get
            {
                return _cs_referer;
            }
            set
            {
                if (_cs_referer == value)
                    return;
                _cs_referer = value;
            }
        }

        public W3cExtendedLog() { }
    }
}
