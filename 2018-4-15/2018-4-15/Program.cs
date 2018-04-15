using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_15
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int MaximalRectangle(char[,] matrix)
        {
            int length1 = matrix.GetLength(0);
            int length2 = matrix.GetLength(1);
            if (length1 + length2 == 0 || length1 + length2 == 1) 
                return 0;
            int max = 0;
            int[,] dp = new int[length1, length2];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (matrix[i, j] == '1')
                    {
                        findmatrix(matrix, dp, i, j);
                        max = Math.Max(dp[i, j], max);
                    }
                }
            }
        }
        private void findmatrix(char[,] matrix, int[,] dpr, int[,] dpc, int i, int j)
        {

        }
    }
}
