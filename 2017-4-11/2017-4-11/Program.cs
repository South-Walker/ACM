using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_11
{
    class Program
    {
        static void Main(string[] args)
        {
            RBT rbt = new RBT();
            rbt.Add(11);
            rbt.Add(10);
            rbt.Delect(11);
            Console.Read();
        }
    }
    class Node
    {
        public bool is_red = true;
        public Node left = null;
        public Node right = null;
        public Node parent = null;
        public int data;
        public Node(int thisdata)
        {
            data = thisdata;
        }
    }
    class RBT
    {
        public Node root = null;
        public void Delect(int data)
        {
            Node nowworking = root;
            while (nowworking == null || nowworking.data != data) 
            {
                nowworking = (nowworking.data > data) ? nowworking.left : nowworking.right;
            }
            if (nowworking != null)
                DelectNode(nowworking);
        }
        private void DelectNode(Node nowworking)
        {
            Node x;
            bool is_delectcolorred = false;
            Node parent;
            if (nowworking.left != null && nowworking.right != null)
            {
                x = nowworking.right;
                while (x.left != null)
                {
                    x = x.left;
                }
                int temp = nowworking.data;
                nowworking.data = x.data;
                x.data = temp;
                nowworking = x;
                x = x.right;
                parent = nowworking.parent;
                if (parent.left == nowworking)
                {
                    parent.left = x;
                }
                else
                {
                    parent.right = x;
                }
                if (x != null)
                    x.parent = parent;
            }
            else if (nowworking.left == null)//删除点左为空，右可能为空
            {
                x = nowworking.right;//唯一可能是null
                parent = nowworking.parent;
                if (x != null)
                {
                        x.parent = parent;
                    if (nowworking != root)
                    {
                        if (parent.left == nowworking)
                        {
                            parent.left = x;
                        }
                        else
                            parent.right = x;
                    }
                }
                else//x为空
                {
                    if (nowworking != root)
                    {
                        if (parent.left == nowworking)
                        {
                            parent.left = x;
                        }
                        else
                            parent.right = x;
                    }
                }
                if (nowworking == root)
                    root = x;
            }
            else//删除点左不为空，右为空
            {
                x = nowworking.left;
                parent = nowworking.parent;
                if (parent == null)
                {
                    root = x;
                }
                else
                {
                    if (parent.left == nowworking)
                    {
                        parent.left = x;
                    }
                    else
                        parent.right = x;
                }
                x.parent = parent;
            }
            is_delectcolorred = nowworking.is_red;
            nowworking = null;
            if (is_delectcolorred)
            {
                //不会发生什么
            }
            else if (x == null)
            {
            }//如果x是null，要修正一下
            DelectFixUp(x);
        }
        private void DelectFixUp(Node x)
        {
            while (x != root && x.is_red == false)
            {

            }
            x.is_red = false;
        }
        public void Add(int data)
        {
            Node nowworking = root;
            Node parentofnowworking = null;
            while (nowworking != null)
            {
                parentofnowworking = nowworking;
                nowworking = (data > nowworking.data) ? nowworking.right : nowworking.left;
            }
            Node newnode = new Node(data);
            if (parentofnowworking == null)
            {
                root = newnode;
                root.is_red = false;
            }
            else if (data > parentofnowworking.data)
            {
                parentofnowworking.right = newnode;
            }
            else
            {
                parentofnowworking.left = newnode;
            }
            newnode.parent = parentofnowworking;
            if (parentofnowworking != null && parentofnowworking.is_red)  //需要旋转
            {
                newnode = ColorRation(newnode);//这个染色要保证回复到叔节点为黑的情况，此时树仍可能违背红黑性质，newnode是红节点。
                root.is_red = false;//可能在上一步中把root染成红了
                if (newnode.parent != null && newnode.parent.is_red)
                {
                    Rotation(newnode);//开始干活
                }
            }
        }
        private void Rotation(Node z)
        {
            try
            {
                //调用这个方法的前提是父存在，且父为红，因为父为红，所以父非根，所以祖父存在
                Node parent = z.parent;
                Node grandparent = parent.parent;
                //把所有情况化为LL,或者RR
                if (grandparent.left == parent)
                {
                    if (parent.right == z)//lr
                        z = LR(z);
                    LL(z);//ll
                }
                else
                {
                    if (parent.left == z)//rl
                        z = RL(z);
                    RR(z);//rr
                }
            }
            catch(NullReferenceException)
            {
                //如果连grandparent都是null，那么树高最多两层，而且第一层是黑根，那不可能违反红黑性质，换句话说，这个方法根本不可能被调用，写上这个catch是为了让逻辑更清楚一点。
                return;
            }
        }
        private void RR(Node z)
        {
            Node parent = z.parent;
            Node grandparent = parent.parent;
            Node brother = parent.left;
            grandparent.is_red = true;
            parent.is_red = false;
            Node grandgrandprent;//可能不存在，此时祖父是root
            if (grandparent != root)
            {
                grandgrandprent = grandparent.parent;
                if (grandgrandprent.left == grandparent)
                {
                    grandgrandprent.left = parent;
                }
                else
                {
                    grandgrandprent.right = parent;
                }
                parent.parent = grandgrandprent;
            }
            else
            {
                parent.parent = null;
                root = parent;
            }
            parent.left = grandparent;
            grandparent.parent = parent;
            grandparent.right = brother;
            if (brother != null)
                brother.parent = grandparent;
        }
        private void LL(Node z)
        {
            Node parent = z.parent;
            Node grandparent = parent.parent;
            Node brother = parent.right;
            grandparent.is_red = true;
            parent.is_red = false;
            Node grandgrandprent;//可能不存在，此时祖父是root
            if (grandparent != root)
            {
                grandgrandprent = grandparent.parent;
                if (grandgrandprent.left == grandparent)
                {
                    grandgrandprent.left = parent;
                }
                else
                {
                    grandgrandprent.right = parent;
                }
                parent.parent = grandgrandprent;
            }
            else
            {
                parent.parent = null;
                root = parent;
            }
            parent.right = grandparent;
            grandparent.parent = parent;
            grandparent.left = brother;
            if (brother != null)
                brother.parent = grandparent;
        }
        private Node LR(Node z)
        {
            Node leftson = z.left;
            Node rightson = z.right;
            Node parent = z.parent;
            Node grandparent = parent.parent;//一定存在不赘述
            Node brother = parent.left;//这里，因为已经确定是LR型，那不需要判断z与p的相对位置了
            z.parent = grandparent;
            grandparent.left = z;//同理，确定是LR型
            parent.parent = z;
            z.left = parent;
            if (leftson != null)
                leftson.parent = parent;
            parent.right = leftson;
            return parent;//为与本来就是LL旋转的可能统一输入格式，故将z下调一层，此时本来的z是现在parent的父节点
        }
        private Node RL(Node z)
        {
            Node leftson = z.left;
            Node rightson = z.right;
            Node parent = z.parent;
            Node grandparent = parent.parent;
            Node brother = parent.right;
            z.parent = grandparent;
            grandparent.right = z;//同理，确定是RL型
            parent.parent = z;
            z.right = parent;
            if (rightson != null)
                rightson.parent = parent;
            parent.right = rightson;
            return parent;//为与本来就是LL旋转的可能统一输入格式，故将z下调一层，此时本来的z是现在parent的父节点
        }
        private static Node ColorRation(Node z)//染色结束之后返回相当于需要旋转的树的新增节点 z必然是红节点
        {
            Node worker;
            Node father;
            Node grandfather;
            try
            {
                father = z.parent;
                grandfather = father.parent;
            }
            catch (NullReferenceException)
            {
                return z;
            }
            Node uncle;
            if (grandfather == null)
                uncle = null;
            else
                uncle = (grandfather.left == father) ? grandfather.right : grandfather.left;
            if (father.is_red && uncle != null && uncle.is_red) 
            {
                grandfather.is_red = true;
                father.is_red = false;
                uncle.is_red = false;
                //需要染，因为只有第一次递归中满足不要染的条件
                //实在觉得不需要染，写完后测试一下就是，很简单的
                if ((worker = father.left) != null)
                {
                    worker.is_red = true;
                }
                if ((worker = father.right) != null)
                {
                    worker.is_red = true;
                }
                if ((worker = uncle.left) != null)
                {
                    worker.is_red = true;
                }
                if ((worker = uncle.right) != null)
                {
                    worker.is_red = true;
                }
                z = ColorRation(grandfather);
            }
            return z;
        }
    }
}
