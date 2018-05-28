using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.GenerateMatrix(3);
        }

    }
    public class Solution
    {
        public int[,] GenerateMatrix(int n)
        {
            int[,] result = new int[n, n];
            if (n == 0)
                return result;
            var nums = getallnums(n).GetEnumerator();
            int limit = n;
            fillcircle(result, 0, limit, nums);
            return result;
        }
        public void fillcircle(int[,] intarray, int process, int limit, IEnumerator<int> nums)
        {
            if (limit == 0)
            {
                return;
            }
            if (limit == 1) 
            {
                intarray[process, process] = getnext(nums);
                return;
            }
            int n = intarray.GetLength(0);
            for (int i = process; i < n - process - 1; i++) 
            {
                intarray[process, i] = getnext(nums);
            }
            for (int i = process; i < n - process - 1; i++) 
            {
                intarray[i, n - process - 1] = getnext(nums); 
            }
            for (int i = n - process - 1; i > process; i--)
            {
                intarray[n - process - 1, i] = getnext(nums);
            }
            for (int i = n - process - 1; i > process; i--) 
            {
                intarray[i, process] = getnext(nums);
            }
            fillcircle(intarray, process + 1, limit - 2, nums);
        }
        static T getnext<T>(IEnumerator<T> enumerator)
        {
            enumerator.MoveNext();
            T current = enumerator.Current;
            return current;
        }
        static IEnumerable<int> getallnums(int n)
        {
            int max = n * n;
            for (int i = 1; i <= max; i++)
            {
                yield return i;
            }
        }

    }
}
