using System;
using System.IO;
using System.Reflection;
namespace Indihiang.Cores
{
    public class Logger
    {
        public static void Write(string message)
        {
            string path = string.Format("{0}\\Log\\", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (StreamWriter writer = new StreamWriter(string.Format("{0}{1}.log", path, DateTime.Now.ToString("yyyyMMdd")), true))
            {
                string msg = string.Format("{0}: {1}", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"), message);
                writer.WriteLine(msg);
            }
        }
    }
}
