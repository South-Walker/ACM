using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] b = { 3,2,1 };
            Console.WriteLine(a.Jump(b));
            Console.Read();
        }
    }
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            bool[] boolnums = new bool[nums.Length];
            boolnums[boolnums.Length - 1] = true;
            int distant = 0;
            for (int i = nums.Length - 2; i >= 0; i--) 
            {
                distant++;
                if (nums[i] >= distant)
                {
                    boolnums[i] = true;
                    distant = 0;
                }
            }
            return boolnums[0];
        }
        public int Jump(int[] nums)
        {
            int maxnow;int nowcount;
            int[] count = new int[nums.Length];
            for (int i = 1; i < count.Length; i++)
            {
                count[i] = int.MaxValue - 1;
            }
            for (int i = 0; i < count.Length - 1; i++)
            {
                maxnow = nums[i];
                nowcount = count[i];
                if (i + maxnow < count.Length && count[i + maxnow] > nowcount + 1)
                {
                    for (int j = i + 1; j <= i + maxnow; j++)
                    {
                        count[j] = Math.Min(nowcount + 1, count[j]);
                    }
                }
                else if (i + maxnow >= count.Length)
                {
                    count[count.Length - 1] = Math.Min(count[count.Length - 1], nowcount + 1);
                }
            }
            return count[count.Length - 1];
        }
    }
}
