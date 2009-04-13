using System;
using System.Linq;
using System.Collections.Generic;

namespace Indihiang.Modules
{
    public sealed class UserControlUtil
    {
        private UserControlUtil() { }

        public static Dictionary<string, List<double>> SortList(Dictionary<string, List<double>> data)
        {
            List<KeyValuePair<string, List<double>>> result = new List<KeyValuePair<string, List<double>>>(data);
            result.Sort(
              delegate(
                KeyValuePair<string, List<double>> first,
                KeyValuePair<string, List<double>> second)
              {
                  double totalFirst = first.Value.Sum();
                  double totalSecond = second.Value.Sum();

                  if (totalSecond == totalFirst)
                      return 0;
                  if (totalSecond > totalFirst)
                      return 1;

                  return -1;
              }
              );

            Dictionary<string, List<double>> newList = new Dictionary<string, List<double>>();
            for (int i = 0; i < result.Count; i++)
                newList.Add(result[i].Key, result[i].Value);

            return newList;

        }
        public static Dictionary<string, int> SortList(Dictionary<string, int> data)
        {
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>(data);
            result.Sort(
              delegate(
                KeyValuePair<string, int> first,
                KeyValuePair<string, int> second)
              {
                  return second.Value.CompareTo(first.Value);
              }
              );

            return data;

        }
    }
}
