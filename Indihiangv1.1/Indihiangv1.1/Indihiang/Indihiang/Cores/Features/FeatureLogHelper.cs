using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indihiang.Cores.Features
{
    public class FeatureLogHelper
    {
        private FeatureLogHelper() { }

        //public static void Push(string logId,string featureName,string key,bool unique,params string[] args)
        //{
        //    string path = String.Format("{0}\\Temp\\{1}\\", Environment.CurrentDirectory, logId);
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    string file = String.Format("{0}{1}.tmp", path, featureName);
        //    try
        //    {
        //        if (File.Exists(file))
        //        {

        //        }
        //        else
        //        {
        //        }
        //        //using(StreamWriter writer=new StreamWriter(File,))
        //    }
        //    catch (Exception) { }

        //}

        public static bool IsFound(string file, string item)
        {
            bool found = false;
            using (StreamReader sr = new StreamReader(file))
            {
                string line = sr.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    if (line == item.ToLower().Trim())
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }
    }
}
