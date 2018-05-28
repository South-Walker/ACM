using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            Solution a = new Solution();
            a.Permute(nums);
        }
    }
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = nums[0];
                nums[0] = nums[i];
                nums[i] = temp;
                fixn(nums, 1, result);
                nums[i] = nums[0];
                nums[0] = temp;
            }
            return result;
        }
        public void fixn(int[] nums, int n, IList<IList<int>> result)
        {
            if (n >= nums.Length) 
            {
                result.Add(list(nums));
            }
            else
            {
                for (int i = n; i < nums.Length; i++)
                {
                    int temp = nums[n];
                    nums[n] = nums[i];
                    nums[i] = temp;
                    fixn(nums, n + 1, result);
                    nums[i] = nums[n];
                    nums[n] = temp;
                }
            }
        }
        public IList<int> list(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                result.Add(nums[i]);
            }
            return result;
        }
    }
}
