using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_27
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(3);
            a.right = new TreeNode(2);
            a.right.left = new TreeNode(1);
            a.right.right = new TreeNode(4);
            Solution b = new Solution();
            b.PostorderTraversal(a);

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
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode now;TreeNode pre = new TreeNode(int.MaxValue);
            while (stack.Count != 0)
            {
                now = stack.Peek();
                while (now.left != null && pre != now.left && pre != now.right)  
                {
                    now = now.left;
                    stack.Push(now);
                }
                while (now.right != null && pre != now.right && pre != now.right)
                {
                    now = now.right;
                    stack.Push(now);
                    if (now.left != null)
                    {
                        while (now.left != null && pre != now.left && pre != now.right)
                        {
                            now = now.left;
                            stack.Push(now);
                        }
                    }
                }
                now = stack.Pop();
                if (now.left == null && now.right == null)
                {
                    result.Add(now.val);
                    pre = now;
                }
                else if (pre == now.right)
                {
                    result.Add(now.val);
                    pre = now;
                }
                else if (pre == now.left)
                {
                    if (now.right == null)
                    {
                        result.Add(now.val);
                        pre = now;
                    }
                    else
                    {
                        stack.Push(now);
                        stack.Push(now.right);
                    }
                }
                else
                {
                    stack.Push(now);
                }
            }
            return result;
        }
    }
}
