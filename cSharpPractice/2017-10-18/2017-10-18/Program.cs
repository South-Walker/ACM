using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = { { 0, 0 } };
            Solution a = new Solution();
            a.UniquePathsWithObstacles(test);
        }
    }
    public class Solution
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            if (obstacleGrid.Length == 0)
                return 0;
            if (obstacleGrid[0, 0] == 1)
                return 0;
            if (obstacleGrid[obstacleGrid.GetLength(0) - 1, obstacleGrid.GetLength(1) - 1] == 1)
                return 0;
            int[,] dp = new int[obstacleGrid.GetLength(0), obstacleGrid.GetLength(1)];
            dp[0, 0] = 1;
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int k = 0; k < dp.GetLength(1); k++) 
                {
                    if (i == 0 && k == 0)
                    {
                        continue;
                    }
                    int up = (i - 1 < 0 || obstacleGrid[i - 1, k] == 1) ? 0 : dp[i - 1, k];
                    int left = (k - 1 < 0 || obstacleGrid[i, k - 1] == 1) ? 0 : dp[i, k - 1];
                    dp[i, k] = up + left;
                }
            }
            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}
