using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.CombinationSum3(3, 9);

        }
    }
    public class Solution
    {
        private static int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            reCall(result, new List<int>(), k, n, nums.Length - 1);

            return result;
        }
        private IList<int> deepCopy(IList<int> input)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < input.Count; i++) 
            {
                result.Add(input[i]);
            }
            return result;
        }
        private void reCall(IList<IList<int>> result, List<int> now, int k, int n, int nowindex)
        {
            if (k == 0 && n == 0) 
            {
                result.Add(deepCopy(now));
                return;
            }
            if (k == 0 || n <= 0) 
            {
                return;
            }
            if (nowindex < 0)
                return;
            for (int i = nowindex; i >= 0; i--) 
            {
                now.Add(nums[i]);
                reCall(result, now, k - 1, n - nums[i], i - 1);
                now.RemoveAt(now.Count - 1);
            }
        }
    }
}
