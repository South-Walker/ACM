using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_23
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt1 = System.DateTime.Now;
            uva679(20, 524288);
            DateTime dt2 = System.DateTime.Now;
            Console.WriteLine(dt2.Subtract(dt1).TotalMilliseconds);
            Console.Read();
        }
        public static void uva679(int d, int i)
        {
            Tree test = new Tree(d);
            for (int k = 0; k < i - 1; k++)
            {
                test.Next();
            }
            Console.WriteLine(Convert.ToInt32(test.Next(), 2));
        }
    }
    class Node
    {
        public Node left = null;
        public Node right = null;
        public bool value = false;
        public Node()
        {
        }
    }
    class Tree
    {
        Queue<Node> leaves = new Queue<Node>();
        Node root = null;
        int D;
        public Tree(int thisd)
        {
            D = thisd;
            root = new Node();
            leaves.Enqueue(root);
            for (int i = 1; i < D; i++)
            {
                BulidFloor();
            }
        }
        public void BulidFloor()
        {
            Queue<Node> newleaves = new Queue<Node>();
            while (leaves.Count != 0)
            {
                Node now = leaves.Dequeue();
                now.left = new Node();
                now.right = new Node();
                newleaves.Enqueue(now.left);
                newleaves.Enqueue(now.right);
            }
            leaves = newleaves;
        }
        public string Next()
        {
            string result = "1";
            Node now = root;
            while (now != null)
            {
                if (!now.value)
                {
                    now.value = !now.value;
                    now = now.left;
                    result = result + "0";
                }
                else
                {
                    now.value = !now.value;
                    now = now.right;
                    result = result + "1";
                }
            }
            return result.Substring(0, result.Length - 1);
        }
    }
}
