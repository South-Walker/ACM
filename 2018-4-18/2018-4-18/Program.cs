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
            a.MinimumTotal(t);
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
            if (string.IsNullOrEmpty(s))
                return 0;
            int length = s.Length;
            int[] dp = new int[length];
            for (int i = 1; i < length; i++)
            {
                switch (s[i])
                {
                    case '0':
                        break;
                    case '1':
                    case '2':
                        break;
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                        break;
                    case '7':
                    case '8':
                    case '9':
                        break;
                    default:
                        break;
                }
            }
            return dp[length - 1];
        }
    }
}
