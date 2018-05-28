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
        public int LargestRectangleArea(int[] heights)
        {
            int max = 0;
            myStack ms = new myStack();
            for (int i = 0; i < heights.Length; i++)
            {
                int start = heights[i];
                max = Math.Max(ms.Push(start, i), max);
            }
            max = Math.Max(ms.Push(int.MinValue, heights.Length), max);
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
