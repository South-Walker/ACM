using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019_2_23
{
    class Program
    {
        static int[] check = new int[5];
        static int[] all = new int[5];
        static int answer;
        static void solution(int now, int value)
        {
            int i;
            if (value == 23 && now == 5)
            {
                answer = 1;
                return;
            }
            if (answer == 1)
            {
                return;
            }
            for (i = 0; i < 5; i++)
            {
                if (check[i] == 1)
                {
                    continue;
                }
                check[i] = 1;
                if (now == 0)
                {
                    solution(now + 1, all[i]);
                }
                else
                {
                    solution(now + 1, value + all[i]);
                    solution(now + 1, value - all[i]);
                    solution(now + 1, value * all[i]);
                }
                check[i] = 0;
            }
        }
        static void Main(string[] args)
        {
            int i, j, k;
            int flag = 1;
            string[] s = new string[5];
            string ins;
            while (true)
            {
                answer = 0;
                ins = Console.ReadLine();
                s = ins.Split(' ');
                for (i = 0; i < 5; i++)
                {
                    all[i] = Convert.ToInt32(s[i]);
                    check[i] = 0;
                    if (all[i] != 0)
                    {
                        flag = 0;
                    }
                }
                if (flag == 1)
                    return;
                solution(0, 0);
                if (answer == 1)
                {
                    Console.WriteLine("Possible");
                }
                else
                {
                    Console.WriteLine("Impossible");
                }
                flag = 1;
            }
        }
    }
}
