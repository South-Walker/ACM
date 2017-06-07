using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, -1 };
            Console.Write(ThreeSumClosest(nums, 1));
            Console.Read();
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            Sort(nums);
            int len = nums.Length;int min = 99999999;
            for (int i = 0; i < len - 2; i++)
            {
                int b = i + 1;int e = len - 1;
                int sumnow = 0;
                while (b != e) 
                {
                    sumnow = nums[b] + nums[e] + nums[i];
                    if (sumnow > target)
                    {
                        e--;
                    }
                    else if (sumnow < target)
                    {
                        b++;
                    }
                    else
                        return target;
                    if (Math.Abs(target - min) > Math.Abs(target - sumnow)) 
                    {
                        min = sumnow;
                    }
                }
            }
            return min;
        }
        public static void Sort(int[] nums)
        {
            qSort(nums, 0, nums.Length - 1);
        }
        public static void qSort(int[] nums, int begin, int end)
        {
            if (begin >= end)
                return;
            int b = begin;int e = end;
            while (b != e)
            {
                while (b != e && nums[e] >= nums[b])
                {
                    e--;
                }
                Swap(nums, b, e);
                while (b != e && nums[e] >= nums[b])
                {
                    b++;
                }
                Swap(nums, b, e);
            }
            qSort(nums, begin, b - 1);
            qSort(nums, e + 1, end);
        }
        public static void Swap(int[] nums, int b, int e)
        {
            int temp = nums[b];
            nums[b] = nums[e];
            nums[e] = temp;
        }
    }
}
