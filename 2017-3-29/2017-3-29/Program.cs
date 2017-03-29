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
        {}
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
