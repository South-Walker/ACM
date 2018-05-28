using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.SolveNQueens(4);
        }
    }
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            int[,] now = new int[n, n];
            List<IList<string>> result = new List<IList<string>>();
            rollback(now, result, 0);

            return result;
        }
        public void rollback(int[,] now, IList<IList<string>> result, int row)
        {
            if (row >= now.GetLength(0))
            {
                fillresult(now, result);
                return;
            }
            for (int i = 0; i < now.GetLength(1); i++) 
            {
                if (check(now, row, i))
                {
                    now[row, i] = 1;
                    rollback(now, result, row + 1);
                    now[row, i] = 0;
                }
            }

        }
        public bool check(int[,] now, int row, int col)
        {
            //向正上查
            for (int i = row; i >= 0; i--) 
            {
                if (now[i, col] == 1)
                    return false;
            }
            //向左上查
            int min = Math.Min(row, col);
            for (int i = 1; i <= min; i++) 
            {
                if (now[row - i, col - i] == 1)
                    return false;
            }
            //向右上查
            for (int i = 1; ; i++) 
            {
                if (row - i < 0 || col + i >= now.GetLength(1))
                    break;
                if (now[row - i, col + i] == 1)
                    return false;
            }
            return true;
        }
        public void fillresult(int[,] now, IList<IList<string>> result)
        {
            List<string> nowlist = new List<string>();string nowstring;
            for (int row = 0; row < now.GetLength(0); row++) 
            {
                nowstring = "";
                for (int col = 0; col < now.GetLength(1); col++) 
                {
                    nowstring += (now[row, col] == 0) ? "." : "Q";
                }
                nowlist.Add(nowstring);
            }
            result.Add(nowlist);
        }
    }
}
