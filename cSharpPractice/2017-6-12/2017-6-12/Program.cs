using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.GenerateParenthesis(3);
        }
    }
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            fullresult(result, n, n, "");
            return result;
        }
        public void fullresult(List<string> result, int remainafter, int remainbefore, string now)
        {
            if (remainafter == 0)
            {
                while (remainbefore != 0)
                {
                    now = now + ")";
                    remainbefore--;
                }
                result.Add(now);
                return;
            }
            string temp = now + "(";
            fullresult(result, remainafter - 1, remainbefore, temp);
            if (remainbefore - 1 >= remainafter)
            {
                temp = now + ")";
                fullresult(result, remainafter, remainbefore - 1, temp);
            }
        }
    }
}
