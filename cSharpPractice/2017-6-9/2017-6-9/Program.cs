using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Program a = new Program();
            Console.Write(a.IsValid("()[]{}"));
            Console.Read();
        }
        public bool IsValid(string s)
        {
            Stack<char> check = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char now = s[i];
                switch (now)
                {
                    case '(':
                        check.Push(now);
                        break;
                    case '{':
                        check.Push(now);
                        break;
                    case '[':
                        check.Push(now);
                        break;
                    case ')':
                        if (check.Count == 0)
                            return false;
                        if (check.Pop() != '(')
                            return false;
                        break;
                    case '}':
                        if (check.Count == 0)
                            return false;
                        if (check.Pop() != '{')
                            return false;
                        break;
                    case ']':
                        if (check.Count == 0)
                            return false;
                        if (check.Pop() != '[')
                            return false;
                        break;
                    default:
                        break;
                }
            }
            if (check.Count != 0)
                return false;
            return true;
        }
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode head = new ListNode(0);
            ListNode now = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    now.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    now.next = l2;
                    l2 = l2.next;
                }
                now = now.next;
            }
            if (l1 == null)
            {
                while (l2 != null)
                {
                    now.next = l2;
                    l2 = l2.next;
                }
            }
            else
            {
                while (l1 != null)
                {
                    now.next = l1;
                    l1 = l1.next;
                }
            }
            return head.next;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
