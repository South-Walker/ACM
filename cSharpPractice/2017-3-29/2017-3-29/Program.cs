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
             //       a.trueAdd(aaa);
               //     test[aaa] = 1;
                }
            }
            a.trueAdd(50);
            a.trueAdd(25);
            a.trueAdd(70);
            a.trueAdd(10);
            a.trueAdd(40);
            a.trueAdd(32);
            a.trueDelect(25);
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
        public void trueDelect(int value)
        {
            Delect(value);
            RefreshBF(root, 0);
            worrynode = null;
            preNode = null;
            is_right = true;
            is_left = false;
            afterDelect(root);
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
                else if (minproblemsubtree.count == 4)
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
            RefreshBF(root, 0);
        }
        private void afterDelect(Node root)
        {
            if (root != null)
            {
                afterDelect(root.left);
                afterDelect(root.right);
                if (worrynode != null && preNode == null)
                {
                    preNode = root;
                    if (worrynode.value > preNode.value)
                    {
                        is_right = true;
                        is_left = false;
                    }
                    else
                    {
                        is_left = true;
                        is_right = false;
                    }
                }
                if (worrynode == null && Math.Abs(root.minusleft_right) == 2)
                {
                    worrynode = root;
                }
            }
        }
        public int Delect(int value)
        {
            worrynode = null;
            is_left = false;
            is_right = false;
            preNode = null;
            Node now = new Node(value);
            if(root == null)
            {
                return count;
            }
            Node nowworking = root;
            SubDelect(now, root);
            return count;
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
        private bool is_delect = false;
        private void SubDelect(Node now,Node nowworking)//找出错误节点
        {
            need_changeBF = true;
            if (now.value != nowworking.value)
            {
                if (now.value > nowworking.value)
                {
                    if (nowworking.right == null)
                    {
                        return;
                    }
                    else
                    {
                        SubDelect(now, nowworking.right);
                    }
                    if (is_delect)
                    {
                        is_delect = false;
                        if (worrynode.left == null)
                        {
                            nowworking.right = worrynode.right;
                        }
                        else if (worrynode.right == null)
                        {
                            nowworking.right = worrynode.left;
                        }
                        else
                        {
                            Node MaxInLeft = FindMax(worrynode.left);
                            nowworking.right = MaxInLeft;
                            if (MaxInLeft.right != worrynode.right)
                                MaxInLeft.right = worrynode.right;
                            else
                                MaxInLeft.right = null;
                            MaxInLeft.left = worrynode.left;
                            if (MaxInLeft.left == MaxInLeft)
                                MaxInLeft.left = null;
                            if (preNode == null)
                                preNode = worrynode;
                            preNode.right = null;
                            preNode = null;
                        }
                    }
                }
                else
                {
                    count--;
                    if (nowworking.left == null)
                    {
                        return;
                    }
                    else
                    {
                        SubDelect(now, nowworking.left);
                    }
                    if (is_delect)
                    {
                        is_delect = false;
                        if (worrynode.left == null)
                        {
                            nowworking.left = worrynode.right;
                        }
                        else if (worrynode.right == null)
                        {
                            nowworking.left = worrynode.left;
                        }
                        else
                        {
                            Node MaxInLeft = FindMax(worrynode.left);
                            nowworking.left = MaxInLeft;
                            MaxInLeft.right = worrynode.right;
                            MaxInLeft.left = worrynode.left;
                            if (MaxInLeft.left == MaxInLeft)
                                MaxInLeft.left = null;
                            if (preNode == null)
                                preNode = worrynode;
                            preNode.right = null;
                            preNode = null;
                        }
                    }
                }
            }
            else
            {
                is_delect = true;
                //find
                worrynode = nowworking;
            }
        }
        private Node FindMax(Node root)
        {
            Node answer;
            if (root.right != null)
            {
                answer = FindMax(root.right);
                if(is_delect)
                {
                    preNode = root;
                    is_delect = false;
                }
                return answer;
            }
            else
            {
                is_delect = true;
                return root;
            }
        }
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
