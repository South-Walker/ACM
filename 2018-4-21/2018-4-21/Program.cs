using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_21
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int Rob(int[] nums)
        {
            int length = nums.Length;
            int[] dp = new int[length];
            if (length == 0)
                return 0;
            if (length == 1)
                return nums[0];
            if (length == 2)
                return Math.Max(nums[1], nums[0]);
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[1], nums[0]);
            for (int i = 2; i < length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[length - 1];
        }
    }
}
