using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.GenerateTrees(1);
            a.GenerateTrees(1);
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
        static int[] dptable = new int[30];
        public int NumTrees(int n)
        {
            if (n == 0)
                return n;
            dptable[1] = 1;
            dptable[0] = 1;
            dptable[2] = 2;
            if (dptable[n] == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (dptable[i] == 0)
                    {
                        int now = 0;
                        for (int k = 0;; k++)
                        {
                            if ((i - 1) % 2 == 0 && k == (i - 1) / 2)
                                break;
                            if ((i - 1) % 2 != 0 && k == (i + 1) / 2)
                                break;
                            now = now + dptable[k] * dptable[i - 1 - k];
                        }
                        now *= 2;
                        if ((i - 1) % 2 == 0)
                        {
                            now += dptable[(i - 1) / 2] * dptable[(i - 1) / 2];
                        }
                        dptable[i] = now;
                    } 
                }
            }
            return dptable[n];
        }
        static List<TreeNode>[] dpTableofHeadNode = new List<TreeNode>[11];
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            int magicValue = int.MinValue;
            var zero = new List<TreeNode>();
            zero.Add(null);
            dpTableofHeadNode[0] = zero;

            if (dpTableofHeadNode[1] == null) 
            {
                var first = new List<TreeNode>();
                first.Add(new TreeNode(magicValue));
                dpTableofHeadNode[1] = first;
            }
            for (int i = 2; i <= n; i++)
            {
                if (dpTableofHeadNode[i] == null)
                {
                    var nowlist = new List<TreeNode>();
                    for (int k = 0; k < i; k++)
                    {
                        TreeNode nowhead;
                        foreach (var subright in dpTableofHeadNode[k]) 
                        {
                            foreach (var subleft in dpTableofHeadNode[i - 1 - k]) 
                            {
                                nowhead = new TreeNode(magicValue);
                                nowhead.left = subleft;
                                nowhead.right = subright;
                                nowlist.Add(nowhead);
                            }
                        }
                        //endfor
                    }
                    dpTableofHeadNode[i] = nowlist;
                }
            }
            var result = new List<TreeNode>();
            foreach (var head in dpTableofHeadNode[n]) 
            {
                if (head == null)
                {
                    result.Add(null);
                }
                else
                {
                    var newhead = new TreeNode(magicValue);
                    _deepcopy(head, newhead);
                    int begin = 1;
                    _fillatree(newhead, n,ref begin);
                    result.Add(newhead);
                }
            }
            return result;
        }
        private void _fillatree(TreeNode head, int n,ref int now)
        {
            if (now > n)
                return;
            if (head == null)
                return;
            _fillatree(head.left, n,ref now);
            head.val = now;
            now += 1;
            _fillatree(head.right, n,ref now);
        }
        private void _deepcopy(TreeNode oldhead, TreeNode newhead)
        {
            newhead.val = oldhead.val;
            if (oldhead.left != null)
            {
                newhead.left = new TreeNode(int.MinValue);
                _deepcopy(oldhead.left, newhead.left);
            }
            if (oldhead.right != null)
            {
                newhead.right = new TreeNode(int.MinValue);
                _deepcopy(oldhead.right, newhead.right);
            }
        }
    }
}