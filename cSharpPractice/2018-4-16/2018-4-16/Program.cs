using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_16
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = { { '1', '0', '1', '0', '0' }, { '1', '0', '1', '1', '1' }, { '1', '1', '1', '1', '1' }, { '1', '0', '0', '1', '0' } };
            Solution a = new Solution();
            a.MaximalRectangle(matrix);
        }
    }
    public class Solution
    {
        public int MaximalRectangle(char[,] matrix)
        {
            int length0 = matrix.GetLength(0);
            int length1 = matrix.GetLength(1);
            int[,] DP = new int[length0, length1];
            #region initDP
            for (int i = 0; i < length0; i++)
            {
                for (int j = 0; j < length1; j++)
                {
                    if (DP[i, j] != 0 || matrix[i, j] == '0')
                        continue;
                    int k = i; int num = 0;
                    while (k < length0 && matrix[k, j] != '0')
                    {
                        num++;
                        k++;
                    }
                    k = i;
                    while (num > 0) 
                    {
                        DP[k, j] = num;
                        num--;
                        k++;
                    }
                }
            }
            #endregion
            int max = 0;
            for (int i = 0; i < length0; i++)
            {
                myStack ms = new myStack();
                for (int j = 0; j < length1; j++)
                {
                    int start = DP[i, j];
                    max = Math.Max(ms.Push(start, j), max);
                }
                max = Math.Max(ms.Push(int.MinValue, length1), max);
            }
            return max;
        }
        class myStack
        {
            Stack<int> s = new Stack<int>();
            Stack<int> indexs = new Stack<int>();
            public int Push(int value, int index)
            {
                if (s.Count == 0 || s.Peek() <= value)
                {
                    s.Push(value);
                    indexs.Push(index);
                    return 0;
                }
                else
                {
                    int max = 0;
                    Queue<int> temp = new Queue<int>();
                    while (s.Count != 0 && s.Peek() > value)
                    {
                        temp.Enqueue(s.Pop());
                    }
                    int last = 0;
                    while (temp.Count != 0)
                    {
                        last = indexs.Pop();
                        max = Math.Max(temp.Dequeue() * (index - last), max);
                    }
                    s.Push(value);
                    indexs.Push(last);
                    return max;
                }
            }
        }
    }
}
