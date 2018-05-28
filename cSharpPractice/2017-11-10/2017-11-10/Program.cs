using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.GrayCode(10);
        }
    }
    public class Solution
    {
        public IList<int> GrayCode(int n)
        {
            List<int> result = new List<int>();
            if (n == 0)
                return result;
            result.Add(0);
            result.Add(1);
            n -= 1;
            int time = 2;
            while (n != 0)
            {
                int lenbefore = result.Count;
                for (int i = lenbefore - 1; i >= 0; i--) 
                {
                    result.Add(time + result[i]);
                }
                time *= 2;
                n -= 1;
            }
            return result;
        }
    }
}
