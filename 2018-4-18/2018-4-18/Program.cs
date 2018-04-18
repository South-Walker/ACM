using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> t = new List<IList<int>>();
            t.Add(new List<int>());
            t[0].Add(2);
            t.Add(new List<int>());
            t[1].Add(3);
            t[1].Add(4);
            t.Add(new List<int>());
            t[2].Add(6);
            t[2].Add(5);
            t[2].Add(7);
            t.Add(new List<int>());
            t[3].Add(4);
            t[3].Add(1);
            t[3].Add(8);
            t[3].Add(3);

            Solution a = new Solution();
            a.NumDecodings("100");
        }
    }
    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 0)
                return 0;
            int length = triangle.Count;
            int[] dp = new int[length];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            int temp = int.MaxValue;int temp2 = int.MaxValue;
            for (int i = 0; i < triangle.Count; i++) 
            {
                temp = int.MaxValue;
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    temp2 = dp[j];
                    dp[j] = Math.Min(temp, temp2) + triangle[i][j];
                    temp = temp2;
                }
            }
            int min = int.MaxValue;
            for (int i = 0; i < length; i++)
            {
                min = Math.Min(min, dp[i]);
            }
            return min;
        }
        public int NumDecodings(string s)
        {
            int n1 = 1, n2 = 1, n3 = 0;
            if (s.Length == 0 || s[0] == '0') return 0;
            for (int i = 2; i <= s.Length; i++)
            {
                n3 = 0;
                if (s[i - 1] != '0') n3 = n2;
                int num = Convert.ToInt32(s.Substring(i - 2, 2));
                if (num >= 10 && num <= 26) n3 += n1;
                n1 = n2;
                n2 = n3;
            }
            return n2;
        }
    }
}
