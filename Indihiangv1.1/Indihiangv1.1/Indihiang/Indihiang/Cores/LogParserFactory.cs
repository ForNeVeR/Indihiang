using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace Indihiang.Cores
{
    public sealed class LogParserFactory
    {
        private LogParserFactory() { }

        public static BaseLogParser CreateParser(string logFile)
        {
            BaseLogParser baseParser = null;
            EnumLogFile logFormat = EnumLogFile.UNKNOWN;

            if (logFile.StartsWith("--"))
            {
                List<EnumLogFile> listLogFormat = new List<EnumLogFile>();
                string tmp = logFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });

                for (int i = 0; i < files.Length; i++)
                {
                    if (!string.IsNullOrEmpty(files[i]))
                    {
                        EnumLogFile tmpLog = GetLogFormat(files[i]);
                        if (!listLogFormat.Contains(tmpLog))
                            listLogFormat.Add(tmpLog);
                    }
                }

                // check double log format
                if (listLogFormat.Count > 1)
                    return null;

                logFormat = listLogFormat[0];
            }
            else
                logFormat = GetLogFormat(logFile);

            string asm = ConfigurationManager.AppSettings[logFormat.ToString()];
            if(!string.IsNullOrEmpty(asm))
            {
                object[] pars = new object[]{logFile,logFormat};
                baseParser = (BaseLogParser)Activator.CreateInstance(Type.GetType(asm, true), pars);                
            }
           
            return baseParser;
        }

        public static BaseLogParser CreateParserByType(EnumLogFile logFormat)
        {
            BaseLogParser baseParser = null;
            string asm = ConfigurationManager.AppSettings[logFormat.ToString()];
            if (!string.IsNullOrEmpty(asm))
            {
                object[] pars = new object[] { "", logFormat };
                baseParser = (BaseLogParser)Activator.CreateInstance(Type.GetType(asm, true), pars);
            }

            return baseParser;
        }

        private static EnumLogFile GetLogFormat(string logFile)
        {
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

            return logFormat;
        }

        
    }
}
