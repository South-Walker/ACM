using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace _2017_9_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1,1,2 };
            Solution a = new Solution();
            a.PermuteUnique(nums);
        }
    }
    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length == 0)
                return result;
            Sort(nums, 0, nums.Length - 1);
            IList<int> nowlist = new List<int>();
            int[] nonums = new int[nums.Length];
            GetList(nums, nonums, result, nowlist);
            return result;
        }
        public static bool isequal(IList<int> a, IList<int> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        public static IList<int> DeepCopy(IList<int> now)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < now.Count; i++)
            {
                result.Add(now[i]);
            }
            return result;
        }
        public static void GetList(int[] nums, int[] nonums, IList<IList<int>> result, IList<int> nowlist)
        {
            if (nowlist.Count == nonums.Length)
            {
                result.Add(nowlist);
                return;
            }
            for (int i = 0; i < nonums.Length; i++)
            {
                if (nonums[i] == 0 && (i == 0 || nums[i] != nums[i - 1] || nonums[i - 1] == 0))  
                {

                    nonums[i] = 1;
                    IList<int> another = DeepCopy(nowlist);
                    another.Add(nums[i]);
                    GetList(nums, nonums, result, another);
                    nonums[i] = 0;
                }
            }
        }
        public static void Sort(int[] nums, int begin, int end)
        {
            if (end <= begin) return;
            int nobegin = begin;
            int noend = end;
            int temp;
            while (nobegin < noend) 
            {
                while (noend != nobegin && nums[noend] >= nums[nobegin])
                {
                    nobegin++;
                }
                temp = nums[noend];
                nums[noend] = nums[nobegin];
                nums[nobegin] = temp;
                while (noend != nobegin && nums[noend] >= nums[nobegin])
                {
                    noend--;
                }
                temp = nums[noend];
                nums[noend] = nums[nobegin];
                nums[nobegin] = temp;
            }
            Sort(nums, begin, nobegin - 1);
            Sort(nums, noend + 1, end);
        }
        
    }
}
