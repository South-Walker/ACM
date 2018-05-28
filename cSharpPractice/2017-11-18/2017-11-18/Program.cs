using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 2, 1,2 };
            Solution a = new Solution();
            a.SortColors(test);
            Console.Read();
        }
    }
    public class Solution
    {
        public void SortColors(int[] nums)
        {
            int beforeindex = 0;
            int maxindex = nums.Length - 1;
            if (maxindex < 1)
                return;
            for (int colornow = 0; colornow < 3; colornow++)
            {
                int nowindex = beforeindex;
                while (nowindex <= maxindex)
                {
                    if (nums[beforeindex] == colornow)
                    {
                        beforeindex++;
                        while (nowindex <= beforeindex)
                            nowindex++;
                        continue;
                    }
                    else
                    {
                        while (nowindex <= maxindex && nums[nowindex] != colornow)
                        {
                            nowindex++;
                        }
                        if (nowindex > maxindex)
                            break;
                        else
                        {
                            swap(nums, nowindex, beforeindex);
                            nowindex++;
                        }
                    }
                }
                if (beforeindex < maxindex && nums[beforeindex] == colornow) 
                    beforeindex++;
            }
        }
        private void swap(int[] nums, int indexa, int indexb)
        {
            int temp = nums[indexa];
            nums[indexa] = nums[indexb];
            nums[indexb] = temp;
        }
    }
}
