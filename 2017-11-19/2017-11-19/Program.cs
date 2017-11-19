using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_19
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            Solution a = new Solution();
            a.Partition(head, 0);
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
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null || head.next == null)
                return head;
            int len = 1; ListNode tail = head;
            while (tail.next != null)
            {
                tail = tail.next;
                len++;
            }
            ListNode now = head;
            ListNode newhead = new ListNode(int.MinValue);
            ListNode prenow = newhead;
            newhead.next = head;
            head = newhead;
            while (len != 0)
            {
                if (now.val >= x)
                {
                    if (now.next == null)
                        break;
                    prenow.next = now.next;
                    tail.next = now;
                    tail = now;
                }
                if (prenow.next != now.next)
                    prenow = now;
                now = now.next;
                tail.next = null;
                len--;
            }
            return head.next;
        }
    }
}
