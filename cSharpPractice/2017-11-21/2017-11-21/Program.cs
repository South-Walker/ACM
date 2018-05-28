using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] array = { 1, 2, 3 };
            a.Subsets(array);
        }
    }
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            int len = nums.Length;
            int aim = 1 << len;
            var nowlist = new List<int>();
            for (int i = 0; i < aim; i++)
            {
                int nowindex = i;
                for (int k = 0; k < nums.Length; k++)
                {
                    if ((nowindex & 1) == 1) 
                        nowlist.Add(nums[k]);
                    nowindex = nowindex >> 1;
                }
                result.Add(nowlist);
                nowlist = new List<int>();
            }
            return result;
        }
        public IList<IList<int>> oneSubsets(int[] nums)
        {
            var result = new List<IList<int>>();
            _mysubset(nums, new Stack<int>(), result, nums.Length - 1);
            return result;
        }
        public void _mysubset(int[] nums, Stack<int> task, List<IList<int>> result, int index)
        {
            if (index < 0) 
            {
                List<int> now = new List<int>();
                int len = task.Count;
                while (task.Count != 0)
                {
                    now.Add(task.Pop());
                }
                for (int i = now.Count-1; i >= 0; i--)
                {
                    task.Push(now[i]);
                }
                result.Add(now);
                return;
            }
            _mysubset(nums, task, result, index - 1);
            task.Push(nums[index]);
            _mysubset(nums, task, result, index - 1);
            task.Pop();
        }
    }
}
