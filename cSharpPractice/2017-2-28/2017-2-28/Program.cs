using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_2_28
{
    class Program
    {
        static void Main(string[] args)
        {
            BST test = new BST(23);
            test.Add(45);
            test.Add(16);
            test.Add(37);
            test.Add(3);
            test.Add(99);
            test.Add(22);
            Node testnode = test.FindNode(16);
            Console.ReadLine();
        }
    }
    class Node
    {
        public Node left;
        public Node right;
        public int value;
        public Node(int thisvalue)
        {
            value = thisvalue;
            left = null;
            right = null;
        }
    }
    class BST
    {
        public Node root;
        public BST(int value)
        {
            root = new Node(value);
        }
        public void Add(int value)
        {
            Node temp = root;
            Node newnode = new Node(value);
            while (true) 
            {
                if (value <= temp.value)
                {
                    if (temp.left == null)
                    {
                        temp.left = newnode;
                        break;
                    }
                    else
                        temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = newnode;
                        break;
                    }
                    else
                        temp = temp.right;
                }
            }

        }
        public void PrintAll(Node thisroot,int way)
        {
            if (way == 1 && thisroot != null) //中序
            {
                PrintAll(thisroot.left, way);
                Console.WriteLine(thisroot.value);
                PrintAll(thisroot.right, way);
            }
            else if (way == 2 && thisroot != null) //先序
            {
                Console.WriteLine(thisroot.value);
                PrintAll(thisroot.left, way);
                PrintAll(thisroot.right, way);
            }
            else if(thisroot != null)//后序
            {
                PrintAll(thisroot.left, way);
                PrintAll(thisroot.right, way);
                Console.WriteLine(thisroot.value);
            }
        }
        public Node FindNode(int value)
        {
            Node temp = root;
            while(temp != null)
            {
                if (temp.value > value)
                    temp = temp.left;
                else if (temp.value < value)
                    temp = temp.right;
                else if (temp.value == value)
                    return temp;
            }
            return null;
        }
         
    }
}
