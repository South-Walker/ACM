using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_2_26
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkOfQuestion test = new LinkOfQuestion(41);
            test.Remove(test.FindLast());
            Console.Read();
        }
    }
    class Node
    {
        public Node link;
        public object obj = null;
        public Node()
        {
            link = null;
        }
        public Node(object thisobj)
        {
            obj = thisobj;
            link = null;
        }
    }
    class Linked
    {
        protected Node header;
        protected int count;
        public Linked()
        {
            header = new Node("header");
            header.link = header;
            count = 0;
        }
        public int Find(object content)
        {
            if(count == 0)
            {
                return 0;
            }
            Node temp = header;int nownum = 0;
            do
            {
                if (temp.obj == content)
                {
                    return nownum;
                }
                temp = temp.link;
                nownum++;
            } while (temp != header);
            return -1;
        }
        public int Insert(object obj,object after)
        {
            int num = Find(after);
            Node aim = new Node(obj);
            if(num < 0)
            {
                return -1;
            }
            Node temp = header;
            for (int i = 0; i < num; i++) 
            {
                temp = temp.link;
            }
            aim.link = temp.link;
            temp.link = aim;
            count++;
            return 1;
        }
    }
    class LinkOfQuestion
    {
        public Node first = new Node(1);
        protected int count = 1;
        public LinkOfQuestion(int person)
        {
            first.link = first;
            for (int i = 2; i <= person; i++)
            {
                Node last = FindLast();
                Node aim = new Node(i);
                aim.link = first;
                last.link = aim;
                count++;
            }
        }
        public Node FindLast()
        {
            Node now = first;
            for (int i = 1; i < count; i++)
            {
                now = now.link;
            }
            return now;
        }
        public void Remove(Node previous)
        {
            Node itself = previous.link;
            previous.link = itself.link;
            count--;
            Console.WriteLine(itself.obj.ToString());
            first = itself;
            while (count >= 3)
                KillSelf(first);
        }
        public void KillSelf(Node begin)
        {
            Node previous = begin.link.link.link;
            Remove(previous);
        }
    }
}
