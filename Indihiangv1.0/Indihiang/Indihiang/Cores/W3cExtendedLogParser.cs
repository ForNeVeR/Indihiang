using System;

namespace Indihiang.Cores
{
    public class W3cExtendedLogParser : BaseLogParser
    {

        public W3cExtendedLogParser(string logFile, EnumLogFile logFileFormat)
            : base(logFile, logFileFormat) 
        { 
        }

        protected override bool ParseHeader(string line)
        {
            bool isHeader = false;

            if (string.IsNullOrEmpty(line))
                return isHeader;

            if (line.StartsWith("#"))
            {
                isHeader = true;
                if (line.StartsWith("#Fields:"))
                {
                    string temp = line.Substring(9);
                    string[] header = temp.Split(new char[] { ' ' });

                    _currentHeader.Clear();
                    if (header!=null)
                        if (header.Length>0)
                            _currentHeader.AddRange(header);
                }
            }

            return isHeader;
        }

    }
}
