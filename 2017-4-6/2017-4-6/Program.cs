using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_6
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Node
    {
        public Node right;
        public Node left;
        public int value;
        public bool is_red = true;//插入是首先假设是红点
        public Node(int thisvalue)
        {
            value = thisvalue;
        }
    }
    public class RBT
    {
        private Node[] path = new Node[32];
        private Node root;
        private int p;
        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                root.is_red = false;//不改在下面旋转的时候就得加判断。
                return;
            }
            p = 0;
            Node parent = null, now = root;
            while (now != null)
            {
                path[p] = now;
                p++;
                if (now.value == value)
                {
                    return;//以后测试方便
                }
                parent = now;
                now = (now.value > value) ? now.left : now.right;//这样写是真的好看
            }
            now = new Node(value);
            if (value < parent.value) //如果插入值小于双亲结点的值
            {
                parent.left = now; //成为左孩子
            }
            else //如果插入值大于双亲结点的值
            {
                parent.right = now; //成为右孩子
            }
            if (!parent.is_red)
            {
                return;//在黑点后面塞个红点不会有什么事情发生
            }
            path[p] = now;//这个时候已经确定是两个红点了
            while ((p -= 2) >= 0)
            {
                Node grandParent = path[p];
                parent = path[p + 1];
                if (!parent.is_red)
                {
                    break;
                }
                Node uncle = grandParent.left == parent ? grandParent.right : grandParent.left;
                now = path[p + 2];
                if (uncle != null && uncle.is_red)  //叔父存在并且为红色的情况
                {
                    parent.is_red = false;
                    uncle.is_red = false;
                    if (p > 0) //如果祖父不是根结点，则将其染成红色
                    {
                        grandParent.is_red = true;
                    }
                }
                else //叔父不存在或为黑的情况需要旋转
                {
                    Node newRoot;
                    if (grandParent.left == parent) //如果当前结点及父结点同为左孩子或右孩子
                    {
                        newRoot = (parent.left == now) ? LL(grandParent) : LR(grandParent);
                    }
                    else
                    {
                        newRoot = (parent.right == now) ? RR(grandParent) : RL(grandParent);
                    }
                    grandParent.is_red = true; //祖父染成红色
                    newRoot.is_red = false; //新根染成黑色
                    //将新根同曾祖父连接
                    ReplaceChildOfNodeOrRoot((p > 0) ? path[p - 1] : null, grandParent, newRoot);
                    return; //旋转后不需要继续回溯，添加成功，直接退出
                }
            }
        }
        //旋转根旋转后换新根
        private void ReplaceChildOfNodeOrRoot(Node parent, Node child, Node newChild)
        {
            if (parent != null)
            {
                if (parent.Left == child)
                {
                    parent.Left = newChild;
                }
                else
                {
                    parent.Right = newChild;
                }
            }
            else
            {
                _head = newChild;
            }
        }
        //root为旋转根，rootPrev为旋转根双亲结点
        private Node LL(Node root) //LL型旋转，返回旋转后的新子树根
        {
            Node left = root.Left;
            root.Left = left.Right;
            left.Right = root;
            return left;
        }
        private Node LR(Node root) //LR型旋转，返回旋转后的新子树根
        {
            Node left = root.Left;
            Node right = left.Right;
            root.Left = right.Right;
            right.Right = root;
            left.Right = right.Left;
            right.Left = left;
            return right;
        }
        private Node RR(Node root) //RR型旋转，返回旋转后的新子树根
        {
            Node right = root.Right;
            root.Right = right.Left;
            right.Left = root;
            return right;
        }
        private Node RL(Node root) //RL型旋转，返回旋转后的新子树根
        {
            Node right = root.Right;
            Node left = right.Left;
            root.Right = left.Left;
            left.Left = root;
            right.Left = left.Right;
            left.Right = right;
            return left;
        }
    }
}
