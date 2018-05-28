using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 1, 9, 11, 2, 4, 8, 10, 13, 3, 6, 7, 15, 14, 12, 16 };
            int[,] test = new int[4, 4];
            for (int i = 1; i < 17; i++)
            {
                int row = (i - 1) / 4;
                int col = (i - 1) % 4;
                test[row, col] = nums[i - 1];
            }
            Solution a = new Solution();
            a.Rotate(test);
            Console.Read();
        }
    }
    public class Solution
    {
        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxdistant = n / 2;
            for (int i = 0; i <= maxdistant; i++)
            {
                RotateACircle(matrix, i, n);
            }
        }
        public void RotateACircle(int[,] matrix, int distant, int n)
        {
            int maxprocess = n - 1 - distant - distant;
            for (int process = 0; process < maxprocess; process++) 
            {
                RotatePoints(matrix, distant, n, process);
            }
        }
        public void RotatePoints(int[,] matrix, int distant, int n, int process)
        {
            swap(matrix, distant, distant + process, distant + process, n - 1 - distant);
            swap(matrix, distant, distant + process, n - 1 - distant, n - 1 - distant - process);
            swap(matrix, distant, distant + process, n - 1 - distant - process, distant);
        }
        public void swap(int[,] matrix, int x1, int y1, int x2, int y2)
        {
            if (x2 >= 0 && x1 >= 0 && y2 >= 0 && y1 >= 0)
            {
                int temp = matrix[x1, y1];
                matrix[x1, y1] = matrix[x2, y2];
                matrix[x2, y2] = temp;
            }
        }
    }
}
