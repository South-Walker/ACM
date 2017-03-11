using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Link work = new Link();
            bool[] num = new bool[n + 1];
            work.Sub(num);
            Console.Read();
        }
        static public bool Is_Prime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++) 
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        class Node
        {
            public Node next = null;
            public int obj;
            public Node(int id)
            {
                obj = id;
            }
        }
        class Link
        {
            int count = 0;
            public Node NodeOne = null;
            public Node NowWorkNode = null;

            public void Sub(bool[] Is_used)
            {
                if (this.count == Is_used.Length - 1)
                {
                    if (Is_Prime(NowWorkNode.obj + 1))
                    {
                        Print();
                    }
                }
                else
                {
                    for (int i = 2; i < Is_used.Length; i++)
                    {
                        if (!Is_used[i])
                        {
                            if (Is_Prime(i + NowWorkNode.obj))
                            {
                                Is_used[i] = true;
                                Add(i);
                                Sub(Is_used);
                                Is_used[i] = false;
                                DelectNew();
                            }
                        }
                    }
                }
                if (NodeOne.next == NodeOne)
                {
                    Console.WriteLine();
                }
            }
            public void Print()
            {
                Node nowwork = NodeOne;
                for (int i = 0; i < count; i++)
                {
                    Console.Write(nowwork.obj + ",");
                    nowwork = nowwork.next;
                }
                Console.WriteLine();
            }
            public Link()
            {
                NodeOne = new Node(1);
                Node Nodenow = NodeOne;
                NowWorkNode = NodeOne;
                count = 1;
            }
            public void Add(int id)
            {
                count++;
                Node now = new Node(id);
                NowWorkNode.next = now;
                now.next = NodeOne;
                NowWorkNode = NowWorkNode.next;
            }
            public void DelectNew()
            {
                if (count != 2)
                {
                    Node nownode = NodeOne;
                    for (int i = 2; i < count; i++)
                    {
                        nownode = nownode.next;
                    }
                    nownode.next = NodeOne;
                    NowWorkNode = nownode;
                }
                else
                {
                    NodeOne.next = null;
                    NowWorkNode = NodeOne;
                }
                count--;
            }
        }
    }
}
