using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] nums = { 6, 7, 8, 9, 10, 0, 1, 2, 3, 4, 5 };
            Console.WriteLine(a.Search(nums,5));
            Console.Read();
        }
    }
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;
            return searchfirst(nums, target, 0, nums.Length - 1);
        }
        public int searchfirst(int[] nums, int target, int begin, int end)
        {
            if (begin == end)
            {
                return (nums[begin] == target) ? begin : -1;
            }
            int middle = (begin + end) / 2;
            int be = nums[begin];int en = nums[end];int mid = nums[middle];
            if (en > be)
            {
                return searchsecond(nums, target, begin, end);
            }
            if (mid == target)
                return middle;
            if (en > mid)
            {
                int answer = searchsecond(nums, target, middle + 1, end);
                if (answer != -1)
                {
                    return answer;
                }
                answer = searchfirst(nums, target, begin, middle);
                if (answer != -1)
                {
                    return answer;
                }
            }
            else
            {
                int answer = searchsecond(nums, target, begin, middle);
                if (answer != -1)
                {
                    return answer;
                }
                answer = searchfirst(nums, target, middle + 1, end);
                if (answer != -1)
                {
                    return answer;
                }
            }
            return -1;
        }
        public int searchsecond(int[] nums, int target, int begin, int end)
        {
            if (begin == end)
            {
                return (nums[begin] == target) ? begin : -1;
            }
            int middle = (begin + end) / 2;
            if (nums[middle] > target)
                return searchsecond(nums, target, begin, middle);
            else if (nums[middle] < target)
                return searchsecond(nums, target, middle + 1, end);
            else
                return middle;
        }
    }
}
