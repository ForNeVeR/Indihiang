using System;
using System.Collections.Generic;

namespace Indihiang.Cores
{
    public sealed class IndihiangHelper
    {

        public static List<string> ParseFile(string listFile)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(listFile))
            {
                string tmp = listFile.Substring(2);
                string[] files = tmp.Split(new char[] { ';' });

                if (files != null)
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(files[i]))
                            list.Add(files[i]);
                    }
            }
            else
                list.Add(listFile);

            return list;
        }
    }
}
