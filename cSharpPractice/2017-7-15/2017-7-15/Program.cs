using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_7_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.StrStr("aabaabbbbbbbaab", "bbbbbbaa");
        }
    }
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == "")
                return 0;
            if (needle.Length > haystack.Length)
                return -1;
            int[] anext = next(needle);
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                char main = haystack[i];
                int tempi = i;
                for (int k = 0; k < needle.Length; k++)
                {
                    char now = needle[k];
                    if (now == main)
                    {
                        if (k == needle.Length - 1)
                        {
                            return i;
                        }
                        tempi++;
                        main = haystack[tempi];
                    }
                    else
                    {
                        i = i + anext[k];
                        break;
                    }
                }
            }
            return -1;
        }
        public int[] next(string needle)
        {
            int[] result = new int[needle.Length];
            int times = 0;
            for (int i = 1; i < needle.Length; i++)
            {
                char now = needle[i];
                for (int k = 0; k < needle.Length; k++)
                {
                    char main = needle[k];
                    if (now == main)
                    {
                        times++;
                        result[i] = times;
                        i++; 
                    }
                    else
                    {
                        times = 0;
                        result[i] = times;
                        i++; 
                        break;
                    }
                    if (i >= needle.Length)
                        break;
                    now = needle[i];
                }
            }
            return result;
        }
    }
}
