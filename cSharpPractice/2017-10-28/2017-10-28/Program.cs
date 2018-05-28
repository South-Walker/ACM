using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_28
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(1);
            root.right = new TreeNode(4);
            BSTIterator a = new BSTIterator(root);
            while (a.HasNext()) 
            {
                Console.WriteLine(a.Next());
            }
            Console.Read();
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
 

    public class BSTIterator
    {
        TreeNode now;
        TreeNode root;
        TreeNode turnroot;
        public BSTIterator(TreeNode root)
        {
            this.root = root;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (root == null)
                return false;
            if (now == null)
                return true;
            if (now.right == null && turnroot == null) 
                return false;
            return true;
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (now == null)
            {
                now = root;
                while (now.left != null)
                {
                    turnroot = now;
                    now = now.left;
                }
                return now.val;
            }
            if (now.right == null)
            {
                now = turnroot;
                turnroot = getturnroot(turnroot.val);
            }
            else
            {
                now = now.right;
                while (now.left != null)
                {
                    turnroot = now;
                    now = now.left;
                }
            }
            return now.val;
        }
        public TreeNode getturnroot(int val)
        {
            TreeNode getnow = root;
            TreeNode lastturnroot = null;
            while (true)
            {
                if (val > getnow.val)
                {
                    getnow = getnow.right;
                }
                else if (val < getnow.val) 
                {
                    lastturnroot = getnow;
                    getnow = getnow.left;
                }
                if (lastturnroot == null)
                    root = getnow;
                if (val == getnow.val) 
                    break;
            }
            return lastturnroot;
        }
    }

    /**
     * Your BSTIterator will be called like this:
     * BSTIterator i = new BSTIterator(root);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
