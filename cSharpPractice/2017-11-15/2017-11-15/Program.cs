using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_15
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            Solution a = new Solution();
            a.RotateRight(head, 1);
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
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null) 
                return head;
            int length = 1;
            ListNode current = head;
            ListNode lastnode = null;
            while (current.next != null)
            {
                length++;
                current = current.next;
            }
            lastnode = current;
            //拿到尾节点和长度
            k = k % length;
            if (k == 0)
                return head;

            ListNode kthnode = head;
            int lastnodetoremove = length - k - 1;
            current = head;
            while (lastnodetoremove != 0)
            {
                kthnode = kthnode.next;
                lastnodetoremove--;
            }
            ListNode result = kthnode.next;
            kthnode.next = null;
            lastnode.next = head;
            return result;
        }
    }
}
