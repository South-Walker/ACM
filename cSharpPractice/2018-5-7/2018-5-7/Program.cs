using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_5_7
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int CalculateMinimumHP(int[,] dungeon)
        {
            int length0 = dungeon.GetLength(0);
            int length1 = dungeon.GetLength(1);
            if (length0 == 0 || length1 == 0)
                return 0;
            int[,] minInitHP = new int[length0, length1];
            if (dungeon[length0 - 1, length1 - 1] < 0)
            {
                minInitHP[length0 - 1, length1 - 1] -= dungeon[length0 - 1, length1 - 1];
            }
            for (int i = length0 - 1; i >= 0; i--)
            {
                for (int j = length1 - 1; j >= 0; j--)
                {
                    if (i == length0 - 1)
                    {
                        if (j == length1 - 1)
                        {
                            continue;
                        }
                        else
                        {
                            if (dungeon[i, j] < 0)
                            {
                                minInitHP[i, j] = minInitHP[i, j + 1] - dungeon[i, j];
                            }
                            else
                            {
                                minInitHP[i, j] = Math.Max(0, minInitHP[i, j + 1] - dungeon[i, j]);
                            }
                        }
                    }
                    else if (j == length1 - 1)
                    {
                        if (dungeon[i, j] < 0)
                        {
                            minInitHP[i, j] = minInitHP[i + 1, j] - dungeon[i, j];
                        }
                        else
                        {
                            minInitHP[i, j] = Math.Max(0, minInitHP[i + 1, j] - dungeon[i, j]);
                        }
                    }
                    else
                    {
                        if (dungeon[i, j] < 0)
                        {
                            minInitHP[i, j] = Math.Min(minInitHP[i + 1, j], minInitHP[i, j + 1]) - dungeon[i, j];
                        }
                        else
                        {
                            minInitHP[i, j] = Math.Max(0, Math.Min(minInitHP[i, j + 1] - dungeon[i, j], minInitHP[i + 1, j] - dungeon[i, j]));
                        }
                    }
                }
            }
            return minInitHP[0, 0] + 1;
        }
    }
}
