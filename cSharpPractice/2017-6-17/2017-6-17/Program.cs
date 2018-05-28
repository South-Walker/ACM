using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int[] test = { 1,1,3,3,5,6,6 };
            a.RemoveDuplicates(test);
        }
    }
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }
            int nowindex = 1; int shouldindex = 1; int beforevalue = nums[0];
            while (shouldindex < nums.Length)
            {
                if (nums[shouldindex] == beforevalue)
                {
                    shouldindex++;
                    continue;
                }
                beforevalue = nums[shouldindex];
                nums[nowindex] = nums[shouldindex];
                nowindex++;
                shouldindex++;
            }
            return nowindex;
        }
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int nowindex = nums.Length / 2;
            int end = nums.Length - 1;
            int begin = 0;
            while (end > begin) 
            {
                if (nums[nowindex] == target)
                    return nowindex;
                if (nums[nowindex] > target)
                {
                    end = nowindex - 1;
                }
                else
                {
                    begin = nowindex + 1;
                }
                nowindex = (end - begin) / 2 + begin;
            }
            if (target > nums[end])
                return end + 1;
            else
                return end;
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n >= 1) 
            {
                return null;
            }
            ListNode tail = head;
            ListNode mid = head;
            for (int i = 0; i < n; i++)
            {
                tail = tail.next;
            }
            if (tail == null)
            {
                return head.next;
            }
            else
            {
                while (tail.next != null)
                {
                    tail = tail.next;
                    mid = mid.next;
                }
            }
            mid.next = mid.next.next;
            return head;
        }
    }
}
