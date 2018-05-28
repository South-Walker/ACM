using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_30
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(2);
            root.left = new TreeNode(1);
            Solution a = new Solution();
            a.KthSmallest(root, 1);
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
        public int KthSmallest(TreeNode root, int k)
        {
            int result = 0;
            k -= 1;
            _kth(root, ref k, ref result);
            return result;
        }
        public void _kth(TreeNode root,ref int k, ref int result)
        {
            if (root == null || k < 0) 
                return;
            _kth(root.left, ref k, ref result);
            if (k == 0)
            {
                result = root.val;
                k -= 1;
                return;
            }
            k -= 1;
            _kth(root.right, ref k, ref result);
        }
    }
}
