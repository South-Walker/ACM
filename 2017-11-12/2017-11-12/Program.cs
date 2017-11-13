using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[8, 1];
            input[0, 0] = -10;
            input[1, 0] = -9;
            input[2, 0] = -8;
            input[3, 0] = -4;
            input[4, 0] = 0;
            input[5, 0] = 3;
            input[6, 0] = 5;
            input[7, 0] = 6;
            Solution a = new Solution();
            a.SearchMatrix(input, 1);
        }
    }
    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int maxindex0 = matrix.GetLength(0) - 1;
            int maxindex1 = matrix.GetLength(1) - 1;
            if (maxindex0 == -1 || maxindex1 == -1) 
            {
                return false;
            }
            int row = (matrix[maxindex0, 0] <= target) ? maxindex0 : FindRow(matrix, target, 0, maxindex0);
            return _searchrow(matrix, target, row, 0, maxindex1);
        }
        public int FindRow(int[,] matrix, int target, int begin, int end)
        {
            if (begin >= end)
                return begin;
            //end肯定不是正确答案
            int mid = (begin + end) / 2;
            if (matrix[mid, 0] > target)
            {
                return FindRow(matrix, target, begin, mid - 1);
            }
            else if (matrix[mid, 0] == target)
            {
                return mid;
            }
            else
            {
                if (matrix[mid, matrix.GetLength(1) - 1] >= target) 
                    return mid;
                else
                    return FindRow(matrix, target, mid + 1, end);
            }
        }
        public bool _searchrow(int[,] matrix, int target, int row, int begin, int end)
        {
            if (begin >= end)
            {
                return matrix[row, begin] == target;
            }
            int mid = (begin + end) / 2;
            if (matrix[row, mid] > target)
            {
                return _searchrow(matrix, target, row, begin, mid - 1);
            }
            else if (matrix[row, mid] < target)
            {
                return _searchrow(matrix, target, row, mid + 1, end);
            }
            else
                return true;
        }
    }
}
