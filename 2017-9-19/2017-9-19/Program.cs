using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_19
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[] { 2, 3, 6, 7 };
            Solution a = new Solution();
            a.CombinationSum(test, 7);
            
        }
    }
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            retell(candidates, target, result, new List<int>(), candidates.Length - 1);
            return result;
        }
        public IList<int> deepcopy(IList<int> aim)
        {
            List<int> newlist = new List<int>();
            for (int i = 0; i < aim.Count; i++) 
            {
                newlist.Add(aim[i]);
            }
            return newlist;
        }
        public void retell(int[] candidates, int target, IList<IList<int>> result, IList<int> now, int nowindex)
        {
            if (target == 0)
            {
                result.Add(now);
                return;
            }
            if (target < 0)
            {
                return;
            }
            for (int i = nowindex; i >= 0; i--) 
            {
                now.Add(candidates[i]);
                retell(candidates, target - candidates[i], result, deepcopy(now),i);
                now.RemoveAt(now.Count - 1);
            }
        }
    }
}
