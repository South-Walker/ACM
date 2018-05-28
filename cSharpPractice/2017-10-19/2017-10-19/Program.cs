using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_19
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = { { 1, 3, 1 }, { 1, 5, 1 }, { 4, 2, 1 } };
            Solution a = new Solution();
            a.MinPathSum(grid);
        }
    }
    public class Solution
    {
        public int MinPathSum(int[,] grid)
        {
            int[,] dp = new int[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int k = 0; k < dp.GetLength(1); k++) 
                {
                    int up = (i - 1 >= 0) ? dp[i - 1, k] : int.MaxValue;
                    int left = (k - 1 >= 0) ? dp[i, k - 1] : int.MaxValue;
                    int min = Math.Min(up, left);

                    dp[i, k] = (min == int.MaxValue) ? grid[0, 0] : min + grid[i, k];
                }
            }
            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}
