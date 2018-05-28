using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            int len = s.Length;
            int counter = 0;
            if (len == 0)
                return counter;
            char pre, now;
            pre = s[0];
            if (pre != ' ')
                counter++;
            for (int i = 1; i < len; i++)
            {
                now = s[i];
                if (pre == ' ')
                {
                    if (now == ' ')
                        ;
                    else
                        counter = 1;
                }
                else
                {
                    if (now == ' ')
                        ;
                    else
                        counter++;
                }
                pre = s[i];
            }
            return counter;
        }
    }
}
