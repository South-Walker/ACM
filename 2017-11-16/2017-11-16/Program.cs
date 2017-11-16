using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_16
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode test = new ListNode(1);
            test.next = new ListNode(1);
            test.next.next = new ListNode(2);
            Solution a = new Solution();
            a.DeleteDuplicates(test);
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
            ListNode beforenode = head;
            ListNode afternode = head;
            bool willchange = false;
            while (afternode.next != null)
            {
                afternode = afternode.next;
                if (beforenode.val == afternode.val)
                {
                    willchange = true;
                }
                else if (!willchange) 
                {
                    beforenode = afternode;
                }
                if (willchange && beforenode.val != afternode.val)   
                {
                    willchange = false;
                    beforenode.next = afternode;
                    beforenode = beforenode.next;
                }
            }
            if (beforenode.val == afternode.val)
            {
                beforenode.next = null;
            }
            return head;
        }
    }
}
