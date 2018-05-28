using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_20
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            if (k > n)
                return result;
            _combine(n, k, new Stack<int>(), result);
            return result;
        }
        public void _combine(int begin, int left, Stack<int> nowtask, List<IList<int>> result)
        {
            if (left == 0)
            {
                List<int> now = new List<int>();
                foreach (var item in nowtask)
                {
                    now.Add(item);
                }
                result.Add(now);
                return;
            }
            if (begin == 0)
            {
                return;
            }
            for (int i = begin; i > 0; i--) 
            {
                nowtask.Push(i);
                _combine(i - 1, left - 1, nowtask, result);
                nowtask.Pop();
            }
        }
    }
}
