using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" };
            Solution a = new Solution();
            a.GroupAnagrams(input);
        }
    }
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<int>> dct = new Dictionary<string, List<int>>();
            for (int i = 0; i < strs.Length; i++) 
            {
                StringBuilder sort = new StringBuilder(strs[i]);
                qsortstring(strs[i], 0, strs[i].Length - 1, ref sort);
                string sortstring = sort.ToString();
                if (dct.ContainsKey(sortstring)) 
                {
                    dct[sortstring].Add(i);
                }
                else
                {
                    dct.Add(sortstring, new List<int>());
                    dct[sortstring].Add(i);
                }
            }
            List<IList<string>> result = new List<IList<string>>();
            foreach (var item in dct)
            {
                List<string> now = new List<string>();
                foreach (int i in item.Value)
                {
                    now.Add(strs[i]);
                }
                result.Add(now);
            }
            return result;
        }
        public void qsortstring(string input, int begin, int end, ref StringBuilder output)
        {
            if (end <= begin)
            {
                return;
            }
            int a = begin;
            int b = end;
            char temp;
            while (b > a) 
            {
                while (output[b] >= output[a] && b > a) 
                {
                    a++;
                }
                temp = output[b];
                output[b] = output[a];
                output[a] = temp;
                while (output[b] >= output[a] && b > a)
                {
                    b--;
                }
                temp = output[b];
                output[b] = output[a];
                output[a] = temp;
            }
            qsortstring(input, begin, a - 1, ref output);
            qsortstring(input, b + 1, end, ref output);
        }
    }
}
