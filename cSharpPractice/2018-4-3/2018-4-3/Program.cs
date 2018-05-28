using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int myAddDigits(int num)
        {
            while (num >= 10)
            {
                num = num / 10 + num % 10;
            }
            return num;
        }
        public int AddDigits(int num)
        {
            if (num == 0)
                return num;
            int n = num % 9;
            return (n == 0) ? 9 : n;
        }
        //非二叉搜索树
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left == null)
                return right;
            else if (right == null)
                return left;
            else
                return root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
