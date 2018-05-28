using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.UniquePaths(3, 7);
        }
    }
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            int[,] result = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        result[i, j] = 1;
                        continue;
                    }

                    int up = (i == 0) ? 0 : result[i - 1, j];
                    int left = (j == 0) ? 0 : result[i, j - 1];
                    result[i, j] = up + left;
                }
            }
            return result[m - 1, n - 1];
        }
    }
}
