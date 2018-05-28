using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_22
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public int Rob(int[] nums)
        {
            int length = nums.Length;
            if (length == 0)
            {
                return 0;
            }
            if (length == 1)
            {
                return nums[0];
            }
            if (length == 2) 
            {
                return Math.Max(nums[0], nums[1]);
            }
            int max = 0;
            int[] dps = new int[length];
            //连续3点必然有一点被抢
            //0点被抢
            dps[0] = nums[0];
            dps[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < length - 1; i++) 
            {
                dps[i] = Math.Max(dps[i - 2] + nums[i], dps[i - 1]);
            }
            max = Math.Max(max, dps[length - 2]);
            //0点没有被抢
            dps = new int[length];
            dps[0] = 0;
            dps[1] = nums[1];
            for (int i = 2; i < length; i++)
            {
                dps[i] = Math.Max(dps[i - 2] + nums[i], dps[i - 1]);
            }
            max = Math.Max(max, dps[length - 1]);
            return max;
        }
    }
}
