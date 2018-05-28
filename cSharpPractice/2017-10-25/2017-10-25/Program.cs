using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_25
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
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;
            List<int> all = new List<int>();
            copyallto(all, root);
            int last, now;
            for (int i = 1; i < all.Count; i++)
            {
                last = all[i - 1];
                now = all[i];
                if (now <= last)
                    return false;
            }
            return true;
        }
        public void copyallto(IList<int> result, TreeNode root)
        {
            if (root == null)
                return;
            copyallto(result, root.left);
            result.Add(root.val);
            copyallto(result, root.right);
        }
    }
}
