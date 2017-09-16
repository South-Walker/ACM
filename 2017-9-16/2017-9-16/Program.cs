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
            Console.WriteLine(Convert.ToInt32('0'));
            Console.Read();
        }
    }
    public class Solution
    {
        public void SolveSudoku(char[,] board)
        {

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
