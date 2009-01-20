using System;
using System.Text;
using System.IO;

namespace Indihiang.Cores
{
    public sealed class LogParserFactory
    {
        private LogParserFactory() { }

        public static BaseLogParser CreateParser(string logFile)
        {
            BaseLogParser baseParser = null;

            EnumLogFile logFormat = EnumLogFile.UNKNOWN;
            if (File.Exists(logFile))
            {
                using (StreamReader sr = new StreamReader(logFile))
                {
                    string l1 = sr.ReadLine();
                    string l2 = sr.ReadLine();
                    string l3 = sr.ReadLine();
                    if (l1.StartsWith("#") && l2.StartsWith("#") && l3.StartsWith("#"))
                        logFormat = EnumLogFile.W3CEXT;
                }
            }

            switch (logFormat)
            {
                case EnumLogFile.MSIISLOG:
                    break;
                case EnumLogFile.NCSA:
                    break;
                case EnumLogFile.W3CEXT:
                    baseParser = new W3cExtendedLogParser(logFile);
                    break;
            }
            return baseParser;
        }
        
    }
}
