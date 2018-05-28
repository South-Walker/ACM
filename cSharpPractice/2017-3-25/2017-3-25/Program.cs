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
        static int[] inorder = { 7, 8, 11, 3, 5, 16, 12, 18 };
        static int[] postorder = { 8, 3, 11, 7, 16, 18, 12, 5 };
        static void Main(string[] args)
        {
            DateTime t1 = DateTime.Now;
            uva548();
            DateTime t2 = DateTime.Now;
            TimeSpan ts = t2.Subtract(t1);
            Console.WriteLine(ts.Milliseconds);
            Console.Read();
        }
        public static void uva548()
        {
            Node root = new Node(postorder[postorder.Length - 1]);
            BuildTree(0, inorder.Length - 1, 0, postorder.Length - 2, root);
            int max = 999999;
            int now = 0;
            int answer = 0;
            CheckSum(ref now, root, ref max,ref answer);
            Console.WriteLine(answer);
        }
        public static void CheckSum(ref int now, Node nowworking, ref int max, ref int answer)
        {
            now += nowworking.value;
            if (now < max) 
            {
                if (nowworking.left == null && nowworking.right == null)
                {
                    max = now;
                    answer = nowworking.value;
                }
                if (nowworking.left != null)
                    CheckSum(ref now, nowworking.left, ref max, ref answer);
                if (nowworking.right != null)
                    CheckSum(ref now, nowworking.right, ref max, ref answer);
            }
            now -= nowworking.value;
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
                int leftcount = inorderindex - inorderbegin;
                int rightcount = inorderend - inorderindex;
                if (rightcount != 0)
                {
                    root.right = new Node(postorder[postorderend]);
                }
                if (leftcount != 0)
                {
                    root.left = new Node(postorder[postorderbegin + leftcount - 1]);
                }
                BuildTree(inorderbegin, inorderindex - 1, postorderbegin, inorderbegin + leftcount - 2, root.left);
                BuildTree(inorderindex+1, inorderend, inorderbegin + leftcount, postorderend - 1, root.right);
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
