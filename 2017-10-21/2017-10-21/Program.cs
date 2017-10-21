using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] emple = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            Solution a = new Solution();
            a.SpiralOrder(emple);
        }
    }
    public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            int limit = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            List<int> result = new List<int>();
            next(result, matrix, 0, limit);
            return result;
        }
        public void next(IList<int> result, int[,] matrix, int process, int limit)
        {

            if (limit == 0)
            {
                return;
            }
            if (limit == 1)
            {
                #region case 1
                if (matrix.GetLength(0) <= matrix.GetLength(1))
                {
                    for (int i = process; i <= matrix.GetLength(1) - 1 - process; i++)
                    {
                        result.Add(matrix[process, i]);
                    }
                }
                else
                {
                    for (int i = process; i <= matrix.GetLength(0) - 1 - process; i++)
                    {
                        result.Add(matrix[i, process]);
                    }
                }
                return;
                #endregion
            }
            #region AddCircle
            for (int i = process; i < matrix.GetLength(1) - 1 - process; i++) 
            {
                result.Add(matrix[process, i]);
            }
            for (int i = process; i < matrix.GetLength(0) - 1 - process; i++) 
            {
                result.Add(matrix[i, matrix.GetLength(1) - 1 - process]);
            }
            for (int i = matrix.GetLength(1) - 1 - process; i > process; i--) 
            {
                result.Add(matrix[matrix.GetLength(0) - 1 - process, i]);
            }
            for (int i = matrix.GetLength(0) - 1 -process; i > process; i--) 
            {
                result.Add(matrix[i, process]);
            }
            #endregion
            next(result, matrix, process + 1, limit - 2);
        }
    }
}
