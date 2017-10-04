using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_24
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3 };
            int target = 4;
            Solution a = new Solution();
            a.CombinationSum4(nums, target);
        }
    }

    public class Solution
    {
        public int CombinationSum4(int[] nums, int target)
        {
            qSort(nums, 0, nums.Length - 1);
            int result = 0;
            reCall(ref result, nums, target, new List<int>(), nums.Length - 1);
            return result;
        }
        public void reCall(ref int result, int[] candidates, int target, IList<int> now, int indexnow)
        {
            if (target == 0)
            {
                addAll(ref result, now);
                return;
            }
            if (target < 0)
            {
                return;
            }
            for (int i = indexnow; i >= 0; i--)
            {
                now.Add(candidates[i]);
                reCall(ref result, candidates, target - candidates[i], now, i);
                now.RemoveAt(now.Count - 1);
            }
        }
        public void addAll(ref int result, IList<int> now)
        {

        }
        public List<int> deepCopy(IList<int> now)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < now.Count; i++)
            {
                result.Add(now[i]);
            }
            return result;
        }
        public void qSort(int[] nums, int begin, int end)
        {
            if (begin >= end)
                return;
            int a = begin; int b = end;
            while (b > a)
            {
                while (b > a && nums[b] >= nums[a])
                {
                    b--;
                }
                int temp = nums[b];
                nums[b] = nums[a];
                nums[a] = temp;
                while (b > a && nums[b] >= nums[a])
                {
                    a++;
                }
                temp = nums[b];
                nums[b] = nums[a];
                nums[a] = temp;
            }
            qSort(nums, begin, a - 1);
            qSort(nums, b + 1, end);
        }
    }
}
