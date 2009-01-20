﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Indihiang.Cores
{
    public class W3cExtendedLogParser : BaseLogParser
    {

        public W3cExtendedLogParser(string logFile)
            :base(logFile) 
        { 
        }

        protected override bool ParseHeader(string line)
        {
            bool isHeader = false;

            if (line.StartsWith("#"))
            {
                isHeader = true;
                if (line.StartsWith("#Fields:"))
                {
                    string temp = line.Substring(9);
                    string[] header = temp.Split(new char[] { ' ' });

                    _currentHeader.Clear();
                    _currentHeader.AddRange(header);
                }
            }

            return isHeader;
        }




    }
}
