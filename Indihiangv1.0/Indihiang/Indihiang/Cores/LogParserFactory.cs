using System;
using System.Text;
using System.IO;
using System.Reflection;
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

            string asm = ConfigurationManager.AppSettings[logFormat.ToString()];
            if(asm!=null && asm!="")
            {
                //params pars = new 
                object[] pars = new object[]{logFile,logFormat};
                baseParser = (BaseLogParser)Activator.CreateInstance(Type.GetType(asm, true), pars);
                
                
            }
           
            return baseParser;
        }
        
    }
}
