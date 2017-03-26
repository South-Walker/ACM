using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_25
{
    class Program
    {
        static int[] inorder = { 3, 2, 1, 4, 5, 7, 6 };
        static int[] postorder = { 3, 1, 2, 5, 6, 7, 4 };
        static void Main(string[] args)
        {
            uva548();
            Console.Read();
        }
        public static void uva548()
        {
            Node root = new Node(postorder[postorder.Length - 1]);
            BuildTree(0, inorder.Length - 1, 0, postorder.Length - 2, root);
            Console.Read();
        }
        public static void BuildTree(int inorderbegin, int inorderend, int postorderbegin, int postorderend, Node root)
        {
            if (inorderbegin < inorderend) 
            {
                int inorderindex = 0;
                for (int i = inorderbegin; i <= inorderend; i++)
                {
                    if (inorder[i] == root.value)
                    {
                        inorderindex = i;//befor i,left,after i,right
                        break;
                    }
                }
                int count = inorderindex - inorderbegin;
                root.right = new Node(postorder[postorderend]);
                root.left = new Node(postorder[inorderbegin + count - 1]);
                BuildTree(inorderbegin, inorderindex - 1, postorderbegin, inorderbegin + count - 2, root.left);
                BuildTree(inorderindex + 1, inorderend, inorderbegin + count - 1, postorderend - 1, root.right);
            }
            else { }
        }   
    }
    class Node
    {
        public Node right = null;
        public Node left = null;
        public int value = 0;
        public Node(int thisvalue)
        {
            value = thisvalue;
        }
    }
}
