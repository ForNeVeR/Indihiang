using System;
using System.Collections.Generic;

namespace Indihiang.Cores
{
    public class W3cExtendedLogParser : BaseLogParser
    {

        public W3cExtendedLogParser(string logFile, EnumLogFile logFileFormat)
            : base(logFile, logFileFormat) 
        { 
        }

        protected override List<string> ParseHeader(string line)
        {
            List<string> list = null;

            if (string.IsNullOrEmpty(line))
                return list;

            if (line.StartsWith("#Fields:"))
            {
                string temp = line.Substring(9);
                temp = temp.Trim();
                string[] header = temp.Split(new char[] { ' ' });

                if (header != null)
                    if (header.Length > 0)
                    {
                        list = new List<string>();
                        list.AddRange(header);
                    }
            }

            return list;
        }


        protected override bool IsLogHeader(string line)
        {
            bool isHeader = false;

            if (string.IsNullOrEmpty(line))
                return isHeader;

            if (line.StartsWith("#"))
                isHeader = true;

            return isHeader;
        }
    }
}
