using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            var q = a.MinDistance("0", "000000");
            Console.WriteLine();
        }
    }
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            int start = -1;
            int max = 0;
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    st.Push(i);
                }
                else if (st.Count > 1)
                {
                    st.Pop();
                    max = Math.Max(max, i - st.Peek());
                }
                else if (st.Count == 1)
                {
                    st.Pop();
                    max = Math.Max(max, i - start);
                }
                else
                {
                    start = i;
                }
            }
            return max;
        }
        public int MinDistance(string word1, string word2)
        {
            int l1 = word1.Length;int l2 = word2.Length;
            if (string.IsNullOrEmpty(word1))
                return l2;
            if (string.IsNullOrEmpty(word2))
                return l1;
            int[,] D = new int[l1 + 1, l2 + 1];
            int update; int delect; int insert;
            for (int i = 0; i < l1 + 1; i++) 
            {
                for (int j = 0; j < l2 + 1; j++) 
                {
                    update = int.MaxValue;
                    delect = int.MaxValue;
                    insert = int.MaxValue;
                    if (i >= 1 && j >= 1)
                    {
                        update = D[i - 1, j - 1] + ((word1[i - 1] == word2[j - 1]) ? 0 : 1);
                        delect = D[i - 1, j] + 1;
                        insert = D[i, j - 1] + 1;
                    }
                    else if (i >= 1)
                        delect = D[i - 1, j] + 1;
                    else if (j >= 1)
                        insert = D[i, j - 1] + 1;
                    else
                        update = 0;
                    D[i, j] = Math.Min(update, Math.Min(delect, insert));
                }
            }
            return D[l1, l2];
        }
    }
}