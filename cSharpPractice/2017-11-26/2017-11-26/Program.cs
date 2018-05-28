using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_26
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (var item in nums)
            {
                result = result ^ item;
            }
            return result;
        }
    }
}
