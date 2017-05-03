using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //  string input = ".#.........\r\n.#.#######.\r\n.#.#.....#.\r\n.#.#.###.#.\r\n.#.#..@#.#.\r\n.#.#####.#.\r\n.#.......#.\r\n.#########.\r\n...........";
            // Deposits(9, 11, input);
        }
        static void Deposits(int a, int b, string input)
        {
            int now_x = 0;int now_y = 0;
            int[,] deposit = new int[a, b];
            input = input.Replace("\r", "");
            string[] arrinput = input.Split('\n');
            string now;
            for (int i = 0; i < a; i++)
            {
                for (int k = 0; k < b; k++)
                {
                    now = arrinput[i].Substring(k, 1);
                    if (now == "." || now == "@") 
                    {
                        deposit[i, k] = 1;
                        if (now == "@")
                        {
                            now_x = i;
                            now_y = k;
                        }
                    }
                    else if (now == "#")
                    {
                        deposit[i, k] = 0;
                    }
                }
            }
            int num = 0;
            TurnRed(now_x, now_y, deposit, ref num);
            Console.WriteLine(num);
            Console.Read();
        }
        static void TurnRed(int nowx, int nowy, int[,] deposit, ref int total)
        {
            if (deposit[nowx, nowy] == 1)
            {
                deposit[nowx, nowy] = 0;
                total++;
                if (nowx > 0)
                    TurnRed(nowx - 1, nowy, deposit, ref total);
                if (nowx < deposit.GetLength(0) - 1)
                    TurnRed(nowx + 1, nowy, deposit, ref total);
                if (nowy > 0)
                    TurnRed(nowx, nowy - 1, deposit, ref total);
                if (nowy < deposit.GetLength(1) - 1)
                    TurnRed(nowx, nowy + 1, deposit, ref total);
            }


        }
    }
}
