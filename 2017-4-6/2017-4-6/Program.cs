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
                if(now.value == value)
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

        }
    }
}
