using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.TotalNQueens(4);
        }
    }
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            bool[,] board = new bool[n, n];
            int total = 0;
            rollback(ref total, board, 0);
            return total;
        }
        public bool check(bool[,] board, int row, int col)
        {
            //up
            for (int i = 0; i < row; i++)
            {
                if (board[i, col])
                    return false;
            }
            //leftup
            int min = Math.Min(row, col);
            for (int i = 1; i <= min; i++)
            {
                if (board[row - i, col - i])
                    return false;
            }
            //rightup
            for (int i = 1; row - i >= 0 && col + i < board.GetLength(0); i++) 
            {
                if (board[row - i, col + i])
                    return false;
            }
            return true;
        }
        public void rollback(ref int total, bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                total++;
                return;
            }
            for (int col = 0; col < board.GetLength(1); col++) 
            {
                if (check(board, row, col))
                {
                    board[row, col] = true;
                    rollback(ref total, board, row + 1);
                    board[row, col] = false;
                }
            }
        }
    }
}
