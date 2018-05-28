using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_24
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] test = { -9, -8, -8, -8, -8, -7, -7, -7, -7, -7, -7, -6, -6, -6, -6, -6, -5, -5, -4, -4, -4, -4, -4, -4, -4, -3, -3, -3, -3, -3, -2, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, -10, -10, -10, -10, -10, -10, -9, -9, -9 };
            a.Search(test, 13);
        }
    }
    public class Solution
    {
        private struct array
        {
            public int beginindex;
            public int endindex;
            public int len
            {
                get
                {
                    return endindex - beginindex + 1;
                }
            }
            public array(int begin, int end)
            {
                beginindex = begin;
                endindex = end;
            }
        }
        public bool Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return false;
            return _search(new array(0, nums.Length - 1), nums, target);
        }
        private bool _search(array indexarray, int[] nums, int target)
        {
            if (indexarray.beginindex >= nums.Length || indexarray.beginindex < 0) 
                return false;
            if (indexarray.endindex < 0 || indexarray.endindex >= nums.Length) 
                return false;
            if (indexarray.len <= 2)
            {
                if (nums[indexarray.endindex] == target || nums[indexarray.beginindex] == target)
                {
                    return true;
                }
                else return false;
            }
            if (nums[indexarray.endindex] == target || nums[indexarray.beginindex] == target)
                return true;
            int middle = (indexarray.endindex - indexarray.beginindex) / 2 + indexarray.beginindex;
            int middlevalu = nums[middle];
            if (target == middlevalu)
                return true;
            if (nums[indexarray.endindex] > nums[indexarray.beginindex])
            {
                #region bigger
                if (target < middlevalu)
                {
                    return _search(new array(indexarray.beginindex + 1, middle - 1), nums, target);
                }
                else
                {
                    return _search(new array(middle + 1, indexarray.endindex - 1), nums, target);
                }
                #endregion
            }
            else
            {
                if (middlevalu == nums[indexarray.endindex])
                {
                    return _search(new array(indexarray.beginindex + 1, middlevalu - 1), nums, target) ||
                        _search(new array(middlevalu + 1, indexarray.endindex - 1), nums, target);
                }
                #region equal
                if (middlevalu < nums[indexarray.endindex])
                {
                    if (target > middlevalu)
                    {
                        if (target > nums[indexarray.endindex])
                            return _search(new array(indexarray.beginindex + 1, middle - 1), nums, target);
                        return _search(new array(middle + 1, indexarray.endindex - 1), nums, target);
                    }
                    if (target < middlevalu)
                        return _search(new array(indexarray.beginindex + 1, middle - 1), nums, target);
                }
                else
                {
                    if (target > middlevalu)
                        return _search(new array(middle + 1, indexarray.endindex - 1), nums, target);
                    if (target < middlevalu)
                    {
                        if (target < nums[indexarray.endindex])
                            return _search(new array(middle + 1, indexarray.endindex - 1), nums, target);
                        return _search(new array(indexarray.beginindex + 1, middle - 1), nums, target);
                    }
                }
                #endregion
            }
            return false;
        }
    }
}
