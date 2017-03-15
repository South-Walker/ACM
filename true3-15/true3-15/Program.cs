using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace true3_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("[\"',.:]");
            string input = "Adventures in Disneyland Two blondes were going to Disneyland when they came to a fork in the road.The sign read: \"Disneyland Left.\"So they went home.";
            input = input.ToLower();
            input = regex.Replace(input, " ");
            string[] all_word = input.Split(' ');
            BTree tree = new BTree();
            foreach(string a in all_word)
            {
                if (a != "")
                    tree.Add(a);
            }
            tree.Print(tree.root);
            Console.Read();
        }
    }
    class Node
    {
        public Node right = null;
        public Node left = null;
        public string value;
        public Node(string thisvalue)
        {
            value = thisvalue;
        }
    }
    class BTree
    {
        public Node root = null;
        public BTree()
        {
            
        }
        static int is_left(string test, string standard)
        {
            if (test == standard)
                return 0;
            int length = test.Length;
            if (standard.Length < length)
                length = standard.Length;
            for (int i = 0; i < length; i++)
            {
                if (test.Substring(i, 1).ToCharArray()[0] > standard.Substring(i, 1).ToCharArray()[0])
                {
                    return -1;
                }
                if (test.Substring(i, 1).ToCharArray()[0] < standard.Substring(i, 1).ToCharArray()[0])
                {
                    return 1;
                }
            }
            if (test.Length <= standard.Length)
                return 1;
            else
                return -1;
        }
        public void Add(string test)
        {
            if (root == null)
            {
                root = new Node(test);
            }
            else
            {
                Node nowworking = root;Node nextworking = null;
                int left = is_left(test, nowworking.value);
                if (left == 1)
                {
                    nextworking = nowworking.left;
                }
                else if (left == -1) 
                    nextworking = nowworking.right;
                while (nextworking != null)
                {
                    left = is_left(test, nextworking.value);
                    if (left == 1)
                    {
                        nowworking = nextworking;
                        nextworking = nowworking.left;
                    }
                    else if(left == -1)
                    {
                        nowworking = nextworking;
                        nextworking = nowworking.right;
                    }
                    else { break; }
                }
                if (left == 1)
                {
                    nowworking.left = new Node(test);
                }
                else if (left == -1)
                {
                    nowworking.right = new Node(test);
                }
            }
        }
        public void Print(Node root)
        {
            if (root != null)
            {
                Print(root.left);
                Console.WriteLine(root.value);
                Print(root.right);
            }
        }
    }
}
