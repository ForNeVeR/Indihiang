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
				bool bRead = false;
				DateTime dt = DateTime.Now;
				string strError = "(unknown)";
			retry:
				if (((DateTime.Now - dt).TotalSeconds > 5) && (System.Windows.Forms.MessageBox.Show("Timed out trying to open log file:\n\n" + logFile + "\n\nError: " + strError + "\n\nTry again?", "Time out", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button1) != System.Windows.Forms.DialogResult.Yes))
					return logFormat;
				try
				{
					//using (StreamReader sr = new StreamReader(logFile))
					using (FileStream fs = File.Open(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						bRead = true;
						using (StreamReader sr = new StreamReader(fs))
						{
							string l1 = sr.ReadLine();
							string l2 = sr.ReadLine();
							string l3 = sr.ReadLine();
							if (l1.StartsWith("#") && l2.StartsWith("#") && l3.StartsWith("#"))
								logFormat = EnumLogFile.W3CEXT;
						}
					}
				}
				/*catch (IOException)
				{
					//
				}*/
				catch (Exception ex)
				{
					strError = ex.Message;
				}

				if (bRead == false)
					goto retry;
            }

            return logFormat;
        }
    }
}
