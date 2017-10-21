using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = { { 0, 0, 0, 5 }, { 4, 3, 1, 4 }, { 0, 1, 1, 4 }, { 1, 2, 1, 3 }, { 0, 0, 1, 1 } };
            Solution a = new Solution();
            a.SetZeroes(test);
        }
    }
    public class Solution
    {
        public void SetZeroes(int[,] matrix)
        {
            bool isrowzero = false;
            bool iscolzero = false;
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                if (matrix[i, 0] == 0)
                {
                    isrowzero = true;
                    break;
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++) 
            {
                if (matrix[0, i] == 0)
                {
                    iscolzero = true;
                    break;
                }
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[0, j] = 0;
                        matrix[i, 0] = 0;
                    }
                }
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[0, j] == 0)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            if (isrowzero)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, 0] = 0;
                }
            }
            if (iscolzero) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[0, j] = 0;
                }
            }
        }
    }
}
