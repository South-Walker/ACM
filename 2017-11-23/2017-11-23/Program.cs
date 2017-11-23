using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_23
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;
            int readindex = 0;
            int writeindex = 0;
            int dnum = 1;
            int prenum = int.MaxValue;
            for (; readindex < nums.Length; readindex++)
            {
                if (nums[readindex] == prenum)
                {
                    dnum++;
                }
                else
                {
                    dnum = 1;
                    prenum = nums[readindex];
                    nums[writeindex] = nums[readindex];
                    writeindex++;
                    continue;
                }
                if (dnum <= 2)
                {
                    nums[writeindex] = nums[readindex];
                    writeindex++;
                    continue;
                }
            }
            return writeindex++;
        }
    }
}
