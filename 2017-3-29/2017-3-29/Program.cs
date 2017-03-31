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
            Random rd = new Random();
            int[] test = new int[512];
            int aaa;
            for (int i = 0; i < 1024; i++)
            {
                aaa = rd.Next(512);
                if (test[aaa] == 0)
                {
                    a.trueAdd(aaa);
                    test[aaa] = 1;
                }
            }
            Console.Read();
        }
    }
    class Node
    {
        public int minusleft_right;
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
                        int h = 9;
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
        public int RefreshBF(Node root, int du)//返回度
        {
            if (root != null)
            {
                int leftheight = RefreshBF(root.left, du + 1);
                int rightheight = RefreshBF(root.right, du + 1);
                root.minusleft_right = leftheight - rightheight;
                return Math.Max(leftheight, rightheight);
            }
            return du - 1;
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
            Add(value);
            if (worrynode != null)
            {
                AVL minproblemsubtree = new AVL(worrynode);
                if (minproblemsubtree.count == 3)
                {
                    minproblemsubtree.count3();
                }
                else if (minproblemsubtree.count == 6) 
                {
                    minproblemsubtree.count6();
                }
                if (is_left)
                {
                    preNode.left = minproblemsubtree.root;
                }
                else if (is_right)
                {
                    preNode.right = minproblemsubtree.root;
                }
                else
                {
                    this.root = minproblemsubtree.root;
                }
            }
            int du = 0;
            RefreshBF(root, 0);
        }
        public int Add(int value)
        {
            worrynode = null;
            is_left = false;
            is_right = false;
            preNode = null;
            Node now = new Node(value);
            if (root == null)
            {
                now.minusleft_right = 0;
                root = now;
                count++;
                return 1;
            }
            Node nowworking = root;
            SubAdd(now, root);
            count++;
            return count;
        }
        private bool need_changeBF = true;
        private void SubAdd(Node now, Node nowworking)
        {
            need_changeBF = true;
            if (now.value > nowworking.value)
            {
                if(nowworking.right == null)
                {
                    nowworking.right = now;
                    if (nowworking.left == null)
                    {
                        nowworking.minusleft_right = -1;
                    }
                    else
                    {
                        nowworking.minusleft_right = 0;
                    }
                    return;
                }
                else
                {
                    SubAdd(now, nowworking.right);
                }
                if (need_changeBF)
                {
                    nowworking.minusleft_right -= 1;
                    if (nowworking.minusleft_right == 0)
                        need_changeBF = false;
                }
            }
            else//left+ 
            {
                if(nowworking.left == null)
                {
                    nowworking.left = now;
                    if (nowworking.right == null)
                    {
                        nowworking.minusleft_right = 1;
                    }
                    else
                    {
                        nowworking.minusleft_right = 0;
                    }
                    return;
                }
                else
                {
                    SubAdd(now, nowworking.left);
                }
                if (need_changeBF)  
                {
                    nowworking.minusleft_right += 1;
                    if (nowworking.minusleft_right == 0)
                        need_changeBF = false;
                }
            }
            if (worrynode == null)
            {
                if (Math.Abs(nowworking.minusleft_right) == 2)
                {
                    worrynode = nowworking;
                }
            }
            if (worrynode != null)
            {
                if (nowworking.left == worrynode)
                {
                    preNode = nowworking;
                    is_left = true;
                }
                if (nowworking.right == worrynode)
                {
                    preNode = nowworking;
                    is_right = true;
                }
            }
        }
    }
}
