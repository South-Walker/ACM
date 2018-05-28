using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017_3_22
{
    class Program
    {
        static Linked aim = new Linked();
        static void Main(string[] args)
        {
            MainOf11988();
        }
        public static void MainOf11988()
        {
            while(true)
            {
                string input = Console.ReadLine();
                if (input == "")
                    break;
                DealString(input, 0, 1, input.Length, false);
                aim.Print();
            }
        }
        public static void DealString(string input, int begin, int length, int left, bool is_left)
        {
            string now = input.Substring(begin, length);
            string check = now.Substring(length - 1, 1);
            if (check != "[" && check != "]")  
            {
                if (length == left)
                {
                    if (!is_left)
                    {
                        aim.Add(now);
                    }
                    else
                        aim.AddBeforeHead(now);
                }
                else
                {
                    DealString(input, begin, length + 1, left, is_left);
                }
            }
            else
            {
                if (check == "[")
                {
                    now = input.Substring(begin, length - 1);
                    if (!is_left)
                    {
                        aim.Add(now);
                    }
                    else
                        aim.AddBeforeHead(now);
                    left = left - length;
                    if (left != 0)
                    {
                        DealString(input, begin + length, 1, left, true);
                    }
                }
                else if (check == "]")
                {
                    now = input.Substring(begin, length - 1);
                    if (!is_left)
                    {
                        aim.Add(now);
                    }
                    else
                        aim.AddBeforeHead(now);
                    left = left - length;
                    if (left != 0)
                    {
                        DealString(input, begin + length, 1, left, false);
                    }
                }
            }
        }
    }
    class Node
    {
        public Node next = null;
        public string value = null;
        public Node(string thisvalue)
        {
            value = thisvalue;
        }
    }
    class Linked
    {
        Node head = null;
        Node tail = null;
        int count = 0;
        public Linked()
        {

        }
        public void Add(string value)
        {
            Node now = new Node(value);
            if (count == 0)
            {
                head = now;
                tail = head;
            }
            else
            {
                tail.next = now;
                tail = tail.next;
            }
            count++;
        }
        public void AddBeforeHead(string value)
        {
            Node now = new Node(value);
            if(count == 0)
            {
                head = now;
                tail = head;
            }
            else
            {
                now.next = head;
                head = now;
            }
            count++;
        }
        public void Print()
        {
            while (head != null)
            {
                Console.Write(head.value);
                head = head.next;
            }
            tail = null;
            count = 0;
            Console.WriteLine();
        }
    }
}
