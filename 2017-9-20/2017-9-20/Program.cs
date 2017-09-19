using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            Solution a = new Solution();
            a.CombinationSum2(nums, 8);

        }
    }
    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            qSort(candidates, 0, candidates.Length - 1);


            return result;
        }
        public void reCall(IList<IList<int>> result, int[] candidates, int target, IList<int> now, int indexnow)
        {

        }
        public List<int> deepCopy(List<int> now)
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
            int a = begin;int b = end;
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
