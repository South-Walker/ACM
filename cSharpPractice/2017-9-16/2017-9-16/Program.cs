using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_9_16
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[9, 9];
            //    string[] stra = { "..4678912", "672195348", "198342567", "859761423", "426853791", "713924856", "961537284", "287419635", "345286179" };
            string[] stra = { "..9748...", "7........", ".2.1.9...", "..7...24.", ".64.1.59.", ".98...3..", "...8.3.2.", "........6", "...2759.." };
            for (int i = 0; i < stra.Length; i++)
            {
                fill(board, stra[i], i);
            }
            Solution a = new Solution();
            a.SolveSudoku(board);
           // Console.Write(a.iswrong(board, 0, 1));
            Console.Read();
        }
        static void fill(char[,] array, string str, int firstindex)
        {
            char[] fromstr = str.ToCharArray();
            for (int i = 0; i < fromstr.Length; i++)
            {
                array[firstindex, i] = fromstr[i];
            }
        }
    }
    public class Solution
    {
        static char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public void SolveSudoku(char[,] board)
        {
            Solver(board, 0, 0);
        }
        public bool Solver(char[,] board, int row, int col)
        {
            if (col == 9)
                return Solver(board, row + 1, 0);
            if (row == 9)
                return true;
            if (board[row, col] != '.')
                return Solver(board, row, col + 1);
            for (int i = 0; i < nums.Length; i++)
            {
                board[row, col] = nums[i];
                if (iswrong(board, row, col) && Solver(board, row, col + 1))
                    return true;
                else
                {
                    board[row, col] = '.';
                }
            }
            return false;
        }
        public bool iswrong(char[,] board, int row, int col)
        {
            char now = board[row, col];
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                if (board[i, col] == now && i != row)
                    return false;
                if (board[row, i] == now && i != col)
                    return false;
            }
            int rowteam = row / 3;
            int colteam = col / 3;
            for (int i = rowteam * 3; i < rowteam * 3 + 3; i++) 
            {
                for (int k = colteam * 3; k < colteam * 3 + 3; k++) 
                {
                    if (board[i, k] == now && (i != row || k != col)) 
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsValidSudoku(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                int[] checkrow = new int[9];
                int[] checkcol = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    checkchar(checkrow, board[j, i]);
                    checkchar(checkcol, board[i, j]);
                }
                if (!isvalid(checkcol))
                    return false;
                if (!isvalid(checkrow))
                    return false;
            }
            int[] checkfirsthouse = new int[9];
            int[] checksecondhouse = new int[9];
            int[] checkthirdhouse = new int[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j <= 2)
                        checkchar(checkfirsthouse, board[i, j]);
                    else if (j <= 5)
                        checkchar(checksecondhouse, board[i, j]);
                    else
                        checkchar(checkthirdhouse, board[i, j]);
                }
                if ((i + 1) % 3 == 0) 
                {
                    if (!isvalid(checkfirsthouse))
                        return false;
                    if (!isvalid(checksecondhouse))
                        return false;
                    if (!isvalid(checkthirdhouse))
                        return false;
                    checkfirsthouse = new int[9];
                    checksecondhouse = new int[9];
                    checkthirdhouse = new int[9];
                }
            }
            return true;
        }
        public void checkchar(int[] check, char now)
        {
            if (now == '.')
                return;
            int nownum = Convert.ToInt32(now) - 49;
            check[nownum] += 1;
        }
        public bool isvalid(int[] check)
        {
            foreach (int a in check)
            {
                if (a >= 2)
                    return false;
            }
            return true;
        }
    }
}
