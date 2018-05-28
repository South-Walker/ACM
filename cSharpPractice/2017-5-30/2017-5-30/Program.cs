using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_30
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        
    }
    class Program
    {
        public static ListNode AddTwo(ListNode l1, ListNode l2)
        {
            bool is_full = false; ListNode temp;
            int now1 = l1.val;int now2 = l2.val;
            int add = now1 + now2;
            if (add >= 10)
            {
                add -= 10;
                is_full = true;
            }
            ListNode l3 = new ListNode(add);
            temp = l3;
            ListNode temp1 = l1.next;
            ListNode temp2 = l2.next;
            while (temp1 != null && temp2 != null)
            {
                now1 = temp1.val;
                now2 = temp2.val;
                temp1 = temp1.next;
                temp2 = temp2.next;
                if (is_full)
                {
                    now1++;
                    is_full = false;
                }
                add = now1 + now2;
                if (add >= 10)
                {
                    add -= 10;
                    is_full = true;
                }
                temp.next = new ListNode(add);
                temp = temp.next;
            }
            while (temp2 != null)
            {
                now2 = temp2.val;
                temp2 = temp2.next;
                if (is_full)
                {
                    is_full = false;
                    now2++;
                }
                if (now2 >= 10)
                {
                    is_full = true;
                    now2 -= 10;
                }
                temp.next = new ListNode(now2);
                temp = temp.next;
            }
            while (temp1 != null)
            {
                now1 = temp1.val;
                temp1 = temp1.next;
                if (is_full)
                {
                    is_full = false;
                    now1++;
                }
                if (now1 >= 10)
                {
                    is_full = true;
                    now1 -= 10;
                }
                temp.next = new ListNode(now1);
                temp = temp.next;
            }
            if (is_full)
            {
                temp.next = new ListNode(1);
            }
            return l3;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int max = 1;int len = s.Length;string temp;bool is_exist = false;
            List<string> little = new List<string>();

            for (int i = 0; i < len; i++)
            {
                temp = s.Substring(i, 1);
                foreach (string a in little)
                {
                    if (a == temp)
                    {
                        is_exist = true;
                        break;
                    }
                }
                if (!is_exist)
                    little.Add(temp);
                is_exist = false;
            }
            max = little.Count;
            if (max == 1)
                return max;

            int now_max = 0;
            little = new List<string>();
            for (int i = 0; i < len; i++)
            {
                temp = s.Substring(i, 1);
                for (int k = 0; k < little.Count; k++)
                {
                    if (little[k] == temp)
                    {
                        now_max = (now_max > little.Count) ? now_max : little.Count;
                        for (int j = 0; j <= k; j++)
                        {
                            little.RemoveAt(0);
                        }
                        little.Add(temp);
                        break;
                    }
                    if (k == little.Count - 1) 
                    {
                        little.Add(temp);
                        break;
                    }
                }
                if (little.Count == 0)
                    little.Add(temp);
                if (now_max == max)
                    break;
            }
            now_max = (now_max > little.Count) ? now_max : little.Count;
            return now_max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("dvdf"));
            Console.Read();
        }
    }
}
