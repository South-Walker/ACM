using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_7_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.RepeatedSubstringPattern("abacababacab");
        }
    }
    public class Solution
    {
        static List<int> zhishu = new List<int>();
        static bool iszhishu(int i)
        {
            for (int k = 2; k <= Math.Sqrt(i); k++)
            {
                if (i % k == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool RepeatedSubstringPattern(string s)
        {
            if (zhishu.Count == 0)
            {
                zhishu.Add(1);
                for (int i = 0; i < 5000; i++)
                {
                    if (iszhishu(i))
                        zhishu.Add(i);
                }
            }
            string now = "";
            int len;
            for (int i = 2; i < zhishu.Count; i++)
            {
                len = zhishu[i];
                if (len >= s.Length)
                {
                    break;
                }
                else if (s.Length % len != 0)
                {
                    continue;
                }
                int beginindex = 0;
                string thisstr = "";
                now = s.Substring(beginindex, len);
                beginindex += len;
                while (beginindex < s.Length) 
                {
                    thisstr = s.Substring(beginindex, len);
                    if (thisstr != now)
                    {
                        break;
                    }
                    beginindex += len;
                    if (beginindex == s.Length)
                        return true;
                }
            }
            return false;
        }
    }
}
