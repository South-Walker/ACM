using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_31
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
    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
            {
                if (p == null && q == null)
                {
                    return true;
                }
                return false;
            }
            if (q.val != p.val)
                return false;
            return IsSameTree(q.left, p.left) && IsSameTree(q.right, p.right);
        }
    }
}
