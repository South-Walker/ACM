using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_11
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0; 
            int global = nums[0];
            int local = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                local = Math.Max(nums[i], local + nums[i]);
                global = Math.Max(local, global);
            }
            return global;
        }
    }
}
