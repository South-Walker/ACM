using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] answer = a.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            Console.Read();
        }
    }
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new int[] { -1, -1 };
            if (nums[0] > target || nums[nums.Length - 1] < target)
                return new int[] { -1, -1 };
            return gethalf(nums, target, 0, nums.Length - 1);
        }
        public int[] gethalf(int[] nums, int target, int begin, int end)
        {
            int middle = (begin + end) / 2;
            if (nums[middle] == target)
            {
                int a = getbegin(nums, target, begin, middle);
                int b = getend(nums, target, middle, end);
                return new int[] { a, b };
            }
            if (begin == end)
            {
                return new int[] { -1, -1 };
            }
            if (nums[middle] < target)
                return gethalf(nums, target, middle + 1, end);
            else
                return gethalf(nums, target, begin, middle);

        }
        public int getbegin(int[] nums, int target, int begin, int end)
        {
            if (begin == end)
                return begin;
            int middle = (begin + end) / 2;
            if (nums[middle] == target)
                return getbegin(nums, target, begin, middle);
            else
                return getbegin(nums, target, middle + 1, end);
                
        }
        public int getend(int[] nums, int target, int begin, int end)
        {
            if (end - begin <= 1)
            {
                if (nums[end] == target)
                    return end;
                else
                    return begin;
            }
            int middle = (begin + end) / 2;
            if (nums[middle] == target)
                return getend(nums, target, middle, end);
            else
                return getend(nums, target, begin, middle);
        }
    }
}
