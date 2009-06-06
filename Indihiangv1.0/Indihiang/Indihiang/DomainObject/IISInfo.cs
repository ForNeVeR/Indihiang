using System;


namespace Indihiang.DomainObject
{
    public class IISInfo
    {
        private string _id;
        private string _serverComment;
        private string _logPath;
        private string _serverPort;
        private string _remoteServer;
        private string _iisUserId;
        private string _iisPassword;

        public string Id
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
        public string ServerComment
        {
            get
            {
                return _serverComment;
            }
            set
            {
                if (_serverComment == value)
                    return;
                _serverComment = value;
            }
        }
        public string LogPath
        {
            get
            {
                return _logPath;
            }
            set
            {
                if (_logPath == value)
                    return;
                _logPath = value;
            }
        }
        public string ServerPort
        {
            get
            {
                return _serverPort;
            }
            set
            {
                if (_serverPort == value)
                    return;
                _serverPort = value;
            }
        }
        public string RemoteServer
        {
            get
            {
                return _remoteServer;
            }
            set
            {
                if (_remoteServer == value)
                    return;
                _remoteServer = value;
            }
        }

        public string IISUserId
        {
            get
            {
                return _iisUserId;
            }
            set
            {
                if (_iisUserId == value)
                    return;
                _iisUserId = value;
            }
        }
        public string IISPassword
        {
            get
            {
                return _iisPassword;
            }
            set
            {
                if (_iisPassword == value)
                    return;
                _iisPassword = value;
            }
        }

        public string IISInfoDisplay
        {
            get
            {
                return string.Format("{0} (http://{1}:{2})", _serverComment, _remoteServer,_serverPort);
            }
        }
    }
}
