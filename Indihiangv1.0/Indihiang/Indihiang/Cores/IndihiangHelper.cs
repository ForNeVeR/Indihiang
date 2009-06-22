using System;
using System.Collections.Generic;
using System.Threading.Collections;
using Indihiang.Cores.Features;

namespace Indihiang.Cores
{
    public sealed class IndihiangHelper
    {

        public static List<string> ParseFile(string listFile)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(listFile))
            {
                string tmp = listFile;
                if (tmp.StartsWith("--") || tmp.StartsWith("$$"))
                    tmp = tmp.Substring(2);
                
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

        public static List<BaseLogAnalyzeFeature> GenerateParallelFeatures(EnumLogFile format)
        {
            List<BaseLogAnalyzeFeature> features = new List<BaseLogAnalyzeFeature>();
            features.Add(new GeneralFeature(format));
            features.Add(new HitsFeature(format));
            features.Add(new UserAgentFeature(format));
            features.Add(new AccessPageFeature(format));
            features.Add(new IPAddressFeature(format));
            features.Add(new AccessStatusFeature(format));

            return features;
        }
        public static List<BaseLogAnalyzeFeature> GenerateFeatures(EnumLogFile format)
        {
            List<BaseLogAnalyzeFeature> features = new List<BaseLogAnalyzeFeature>();
            features.Add(new GeneralFeature(format));
            features.Add(new HitsFeature(format));
            features.Add(new UserAgentFeature(format));
            features.Add(new AccessPageFeature(format));
            features.Add(new IPAddressFeature(format));
            features.Add(new AccessStatusFeature(format));

            return features;
        }
    }
}
