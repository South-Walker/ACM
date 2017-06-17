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
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
       /*     head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);*/
            Solution a = new Solution();
            a.RemoveNthFromEnd(head, 1);
        }
    }
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
    public class Solution
    {
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
