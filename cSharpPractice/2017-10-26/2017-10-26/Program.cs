using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_26
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(1);
            a.right = new TreeNode(2);
            a.left = new TreeNode(3);
            Solution b = new Solution();
            b.PreorderTraversal(a);
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
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            changetree(result, root);
            return result;
        }
        public void changetree(IList<int> result, TreeNode root)
        {
            TreeNode pre;
            while(root!=null)
            {
                if(root.left==null)
                {
                    result.Add(root.val);
                    root = root.right;
                }
                else
                {
                    pre = root.left;
                    while (pre.right != null && pre.right != root)
                        pre = pre.right;
                    if (pre.right == null)
                    {
                        result.Add(root.val);
                        pre.right = root;
                        root = root.left;
                    }
                    else
                    {
                        pre.right = null;
                        root = root.right;
                    }
                }
            }
        }
    }
}
