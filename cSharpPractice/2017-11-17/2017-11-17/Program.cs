using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_17
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(1);
       //     head.next.next = new ListNode(3);
      //    head.next.next.next = new ListNode(3);
          //  head.next.next.next.next = new ListNode(5);

            Solution a = new Solution();
            a.DeleteDuplicates(head);
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
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            //假设1,2不同
            ListNode newhead = new ListNode(head.val - 1);
            newhead.next = head;
            head = newhead;
            ListNode afternode = head.next;
            ListNode beforenode = head;
            while (afternode.next != null)
            {
                if (afternode.next.val != afternode.val)
                {
                    beforenode = afternode;
                    afternode = afternode.next;
                    continue;
                }
                while (afternode.val == beforenode.next.val && afternode.next != null)
                {
                    afternode = afternode.next;
                }
                if (afternode.next == null && beforenode.next.val == afternode.val)
                {
                    beforenode.next = null;
                    break;
                }
                beforenode.next = afternode;
            }
            
            return head.next;
        }
    }
}
