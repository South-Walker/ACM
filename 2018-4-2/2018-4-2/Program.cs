using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
            Solution a = new Solution();
            a.LengthOfLIS(nums);
        }
    }
    public class Solution
    {
        public int slowLengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int[] m = new int[nums.Length];
            int[] d = new int[nums.Length];
            m[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                m[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        m[i] = Math.Max(m[i], m[j] + 1);
                    }
                }
            }
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, m[i]);
            }
            return max;
        }
        public int LengthOfLIS(int[] nums)
        {

            return 0;
        }
    }
}
