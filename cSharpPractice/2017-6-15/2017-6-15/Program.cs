using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_15
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public int RemoveElement(int[] nums, int val)
        {
            int tail = nums.Length - 1;
            if (tail < 0)
                return 0;
            int now = 0;
            while (now != tail)
            {
                if (nums[now] == val)
                {
                    nums[now] = nums[tail];
                    tail--;
                }
                else
                {
                    now++;
                }
            }
            if (nums[now] != val)
                return now + 1;
            else
                return now;
        }
    }
}
