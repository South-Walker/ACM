using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.CountAndSay(5);
        }
    }
    public class Solution
    {
        static List<string> table = new List<string>();
        public string CountAndSay(int n)
        {
            if (table.Count == 0)
            {
                table.Add("1");
            }
            while (table.Count < n)
            {
                table.Add(getnext());
            }
            return table[n - 1];
        }
        public string getnext()
        {
            string now = table[table.Count - 1];
            string next = "";char temp = now[0];int times = 1;
            for (int i = 1; i < now.Length; i++) 
            {
                if (temp == now[i])
                {
                    times++;
                }
                else
                {
                    next = next + times + temp;
                    times = 1;
                    temp = now[i];
                }
            }
            next = next + times + temp;
            return next;
        }
    } 
}
