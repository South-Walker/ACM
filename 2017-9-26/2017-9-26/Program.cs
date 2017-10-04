using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_26
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 4;
            int[] nums = new int[] { 1, 2, 3 };
            Solution a = new Solution();
            a.CombinationSum4(nums, target);
        }
    }
    public class Solution
    {
        public int CombinationSum4(int[] nums, int target)
        {
            int[] check = new int[target + 1];
            check[0] = 1;
            fillcheck(nums, check);
            return check[target];
        }
        public void fillcheck(int[] nums, int[] check)
        {
            for (int i = 1; i < check.Length; i++)
            {
                check[i] = gettotal(nums, check, i);
            }
        }
        public int gettotal(int[] nums, int[] check, int index)
        {
            int now = index;int left = index;int total = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                now = now - nums[i];
                if (now >= 0)
                {
                    total += check[now];
                }
                now = now + nums[i];
            }
            return total;
        }
    }
}