using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_25
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 0 };
            int[] b = { 2 };
            Solution s = new Solution();
            s.Merge(a, 1, b, 1);
        }
    }
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int readindex1 = m - 1;
            int readindex2 = n - 1;
            int writeindex = m + n - 1; 
            for (; writeindex >= 0; writeindex--) 
            {
                if (readindex1 < 0)
                {
                    nums1[writeindex] = nums2[readindex2];
                    readindex2--;
                }
                else if (readindex2 < 0) 
                {
                    nums1[writeindex] = nums1[readindex1];
                    readindex1--;
                }
                else if (nums1[readindex1] >= nums2[readindex2])
                {
                    nums1[writeindex] = nums1[readindex1];
                    readindex1--;
                }
                else
                {
                    nums1[writeindex] = nums2[readindex2];
                    readindex2--;
                }
            }
        }
    }
}
 