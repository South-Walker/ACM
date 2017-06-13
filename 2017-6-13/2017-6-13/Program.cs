using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_13
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            Solution a = new Solution();
            a.SwapPairs(head);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) 
            {
                return head;
            }
            ListNode afterhead = head.next;
            ListNode a1;
            ListNode a2;
            while (true)
            {
                a1 = head;
                a2 = head.next;
                if (a2.next == null || a2.next.next == null) 
                {
                    a1.next = a2.next;
                    a2.next = a1;
                    break;
                }
                else
                {
                    head = a2.next;
                    a1.next = a2.next.next;
                    a2.next = a1;
                }
            }
            return afterhead;
        }
    }
}
