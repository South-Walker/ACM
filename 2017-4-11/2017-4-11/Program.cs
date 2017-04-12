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
            if (data > parentofnowworking.data)
            {
                parentofnowworking.right = newnode;
            }
            else
            {
                parentofnowworking.left = newnode;
            }
            newnode.parent = parentofnowworking;
            if (newnode.parent == null)
            {
                newnode.is_red = false;
            }
            else if (newnode.parent.is_red) //需要旋转
            {
                newnode = ColorRation(newnode);//这个染色要保证回复到叔节点为黑的情况，此时树仍可能违背红黑性质。
            }
        }
        private static Node ColorRation(Node z)//染色结束之后返回相当于需要旋转的树的新增节点 z必然是红节点
        {
            Node father = z.parent;
            Node grandfather = father.parent;
            Node uncle = (grandfather.left == father) ? grandfather.right : grandfather.left;
            if (father.is_red && uncle.is_red)
            {
                grandfather.is_red = true;
                father.is_red = false;
                uncle.is_red = false;
                //这里用个lambda表达式表示把uncle与father所有非空节点染黑好像挺带感的，当然要想一下到底需不需要染
            }
            return grandfather;
        }
    }
}
