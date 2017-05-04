using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_4
{
    class Program
    {
        static bool is_cycle = false;
        static void Main(string[] args)
        {
            string input = "ABCDEFGHIJKLM\rNOPQRSTUVWXYZ";
            Dots(2, 13, input);
        }
        public static void Dots(int n, int m, string input)
        {
            string[,] ArrDots = new string[n, m];
            string delect = "0";
            string[] line = input.Split('\r');
            int[,] has_pass = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    ArrDots[i, k] = line[i].Substring(k, 1);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    clear(n, m, has_pass);
                    if (ArrDots[i, k] != delect)
                        bfs(i, k, has_pass, ArrDots[i, k], ArrDots);
                }
            }
            Console.WriteLine(is_cycle);
            Console.Read();
        }
        public static void clear(int n, int m, int[,] has_passed)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    has_passed[i, k] = 0;
                }
            }
        }
        public static void bfs(int index1, int index2, int[,] has_pass, string now_letter, string[,] arrdots)
        {
            if (arrdots[index1, index2] == now_letter)
            {
                int check = 0;
                arrdots[index1, index2] = "0";
                has_pass[index1, index2] = 1;
                if (index1 > 0)
                {
                    check += has_pass[index1 - 1, index2];
                    bfs(index1 - 1, index2, has_pass, now_letter, arrdots);
                }
                if (index2 > 0)
                {
                    check += has_pass[index1, index2 - 1];
                    bfs(index1, index2 - 1, has_pass, now_letter, arrdots);
                }
                if (index1 < has_pass.GetLength(0) - 1) 
                {
                    check += has_pass[index1 + 1, index2];
                    bfs(index1 + 1, index2, has_pass, now_letter, arrdots);
                }
                if (index2 < has_pass.GetLength(1) - 1) 
                {
                    check += has_pass[index1, index2 + 1];
                    bfs(index1, index2 + 1, has_pass, now_letter, arrdots);
                }
                if (check >= 2)
                {
                    is_cycle = true;
                    return;
                }

            }
        }
    }
}
