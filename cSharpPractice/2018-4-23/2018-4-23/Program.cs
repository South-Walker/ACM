using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_23
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class DPTreeNode
    {
        public int Without;
        public int With;
        public DPTreeNode left;
        public DPTreeNode right;
    }
    public class Solution
    {
        public int Rob(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return root.val;
            DPTreeNode dproot = new DPTreeNode();
            DFS(root, dproot);
            return Math.Max(dproot.With, dproot.Without);
        }
        public void DFS(TreeNode root, DPTreeNode dproot)
        {
            if (root.left != null) 
            {
                DPTreeNode dpleft = new DPTreeNode();
                dproot.left = dpleft;
                DFS(root.left, dpleft);
            }
            if(root.right !=null)
            {
                DPTreeNode dpright = new DPTreeNode();
                dproot.right = dpright;
                DFS(root.right, dpright);
            }
            dproot.With = ((dproot.left == null) ? 0 : dproot.left.Without) +
                ((dproot.right == null) ? 0 : dproot.right.Without) + root.val;
            dproot.Without = ((dproot.left == null) ? 0 : Math.Max(dproot.left.Without, dproot.left.With)) +
                ((dproot.right == null) ? 0 : Math.Max(dproot.right.Without, dproot.right.With));
        }
    }
}