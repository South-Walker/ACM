using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_15
{
    class Program
    {
        static string input = "abababaabababa";
        static int length = input.Length;
        static int[,] DP = new int[length + 1, length + 1];
        static char[] ch_input = input.ToCharArray();
        static void Main(string[] args)
        {
            Get(0, length - 1);
            Console.Write(DP[0, length - 1]);
            Console.Read();
        }
        static void Get(int i, int k)
        {
            if (k > i)
            {
                if (ch_input[i] == ch_input[k])
                {
                    Get(i + 1, k - 1);
                    DP[i, k] = DP[i + 1, k - 1];
                }
                else
                {
                    Get(i + 1, k);
                    Get(i, k - 1);
                    if (DP[i, k - 1] >= DP[i + 1, k])
                    {
                        DP[i, k] = DP[i + 1, k] + 1;
                    }
                    else
                    {
                        DP[i, k] = DP[i, k - 1] + 1;
                    }
                }
            }
        }
    }
}
