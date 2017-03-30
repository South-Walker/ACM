using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_29
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL a = new AVL();
            a.trueAdd(4);
            a.trueAdd(2);
            a.trueAdd(3);
            Console.Read();
        }
    }
    class Node
    {
        public int value;
        public Node right = null;
        public Node left = null;
        public Node(int thisvalue)
        {
            value = thisvalue;
        }
    }
    class AVL
    {
        public Node root = null;
        public int count = 0;
        public AVL()
        {

        }
        public static int Count(Node thisroot)
        {
            if (thisroot == null)
            {
                return 0;
            }
            int count = 1;
            count += Count(thisroot.left);
            count += Count(thisroot.right);
            return count;
        }
        public AVL(Node thisroot)
        {
            root = thisroot;
            count = Count(thisroot);
        }
        public void trueAdd(int value)
        {
            Add(value);
            if(count == 3)
            {
                if (root.left == null || root.right == null)
                {
                    if (root.left == null)
                    {
                        if (root.right.right == null)
                        {
                            root.right.left.left = root;
                            root.right.left.right = root.right;
                            root = root.right.left;
                            root.left.right = null;
                            root.right.left = null;
                        }
                        else// if(root.right.left == null)
                        {
                            root.right.left = root;
                            root = root.right;
                            root.left.right = null;
                        }
                    }
                    else// if (root.right == null) 
                    {
                        if (root.left.left == null)
                        {
                            root.left.right.right = root;
                            root.left.right.left = root.left;
                            root = root.left.right;
                            root.right.left = null;
                            root.left.right = null;
                        }
                        else// if (root.left.right == null)
                        {
                            root.left.right = root;
                            root = root.left;
                            root.right.left = null;
                        }
                    }
                }
            }
        }
        private int Add(int value)
        {
            Node now = new Node(value);
            if (root == null)
            {
                root = now;
                count++;
                return 1;
            }
            Node nowworking = root;
            while (true)
            {
                if (value > nowworking.value)
                {
                    if (nowworking.right == null)
                    {
                        nowworking.right = now;
                        break;
                    }
                    else
                        nowworking = nowworking.right;
                }
                else
                {
                    if (nowworking.left == null)
                    {
                        nowworking.left = now;
                        break;
                    }
                    else
                        nowworking = nowworking.left;
                }
            }
            count++;
            return count;
        }
    }
}
