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
            a.Add(25);
            a.Add(10);
            a.Add(50);
            a.Add(40);
            a.Add(70);
            a.trueAdd(43);
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
        private Node worrynode = null;
        public Node root = null;
        public int count = 0;
        public Node preNode = null;
        private bool is_left = false;
        private bool is_right = false;
        public AVL()
        {

        }
        public int count_AVL(Node now, int height)//输入root,0,0
        {
            if (worrynode == null)
            {
                int left_height = 0;
                int right_height = 0;
                if (now == null)
                {
                    return height;
                }
                if (worrynode != null)
                { }
                else
                {
                    left_height = count_AVL(now.left, height + 1);
                    if (worrynode != null && (!(is_left || is_right))) 
                    {
                        if (now.left == worrynode)
                        {
                            preNode = now;
                            is_left = true;
                        }
                        else if (now.right == worrynode)
                        {
                            preNode = now;
                            is_right = true;
                        }
                    }
                    right_height = count_AVL(now.right, height + 1);
                    if (worrynode != null && (!(is_left || is_right))) 
                    {
                        if (now.left == worrynode)
                        {
                            preNode = now;
                            is_left = true;
                        }
                        else if (now.right == worrynode)
                        {
                            preNode = now;
                            is_right = true;
                        }
                    }
                    if (Math.Abs(right_height - left_height) == 2)
                    {
                        worrynode = now;
                    }
                }
                return Math.Max(left_height, right_height);
            }
            return 10000;
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
        public void count3()
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
        public void count6()
        {
            if (root.left.left != null)
            {
                Node a = root; Node e = root.left.right;
                if (root.left.left.left != null || root.left.left.right != null)
                {
                    root = root.left;
                    root.right = a;
                    a.left = e;
                }
                else
                {
                    if (e.right != null)
                    {
                        root.left.right = e.right;
                    }
                    else
                    {
                        root.left.right = e.left;
                    }
                    e.left = root.left;
                    e.right = a;
                    e.right.left = null;
                    this.root = e;
                }
            }
            else// if (root.right.right != null) 
            {
                Node e = root.right.right;Node c = root.right;Node d = root.right.left;
                if (e.right != null || e.left != null)
                {
                    root.right = c.left;
                    c.left = root;
                    root = c;
                }
                else
                {
                    if (d.right != null)
                    {
                        root.right = d.right;
                    }
                    else
                    {
                        root.right = d.left;
                    }
                    d.left = root;
                    d.right = c;
                    root = d;
                    c.left = null;
                    root.right.left = root.left.right;
                    root.left.right = null;
                }
            }
        }
        public void trueAdd(int value)
        {
            preNode = null;
            is_left = false;
            is_right = false;
            Add(value);
            count_AVL(root, 0);
            if (worrynode != null)
            {
                AVL minproblemsubtree = new AVL(worrynode);
                if (minproblemsubtree.count == 3)
                {
                    minproblemsubtree.count3();
                }
                else
                {
                    minproblemsubtree.count6();
                }
                if (is_left)
                {
                    worrynode.left = minproblemsubtree.root;
                }
                else if (is_right)
                {
                    worrynode.right = minproblemsubtree.root;
                }
                else
                {
                    this.root = minproblemsubtree.root;
                }
            }
        }
        public int Add(int value)
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
