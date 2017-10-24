using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_24
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            fillfromtree(result, root);
            return result;
        }
        public void fillfromtree(IList<int> result, TreeNode root)
        {
            if (root == null)
                return;
            fillfromtree(result, root.left);
            result.Add(root.val);
            fillfromtree(result, root.right);
        }
    }
}
