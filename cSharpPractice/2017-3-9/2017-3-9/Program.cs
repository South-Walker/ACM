using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_9
{
    class Program
    {
        static int situation = 0;
        static int lenth = 8;
        static bool[][] allow = new bool[3][];//0代表列，1代表向右对角线，2代表向左对角线
        static int[] chessbroad = new int[lenth];
        static void Main(string[] args)
        {
            //讲座题，排队买票
            //   GetQueue(100, 0, 0);
            //八皇后
            allow[0] = new bool[lenth];
            allow[1] = new bool[2 * lenth];
            allow[2] = new bool[2 * lenth];
            GetQueen_anotherway(0);
            Console.WriteLine(situation);
            Console.Read();
        }
        static void GetQueue(int m, int n, int num)//m 50,n 100
        {
            if (n > m + num || num < 0) 
            {}
            else if (n == 0 || m == 0)
            {
                situation++;
            }
            else
            {
                GetQueue(m - 1, n, num + 1);
                GetQueue(m, n - 1, num - 1);
            }
        }
        static void GetQueen(int now)
        {
            if(now == lenth)
            {
                situation++;
            }
            else
            {
                for (int i = 0; i < lenth; i++)
                {
                    chessbroad[now] = i;
                    bool ok = true;
                    for (int j = 0; j < now; j++)
                    {
                        if (chessbroad[j] == i || (i - now == chessbroad[j] - j) || (i + now == chessbroad[j] + j))
                        {
                            ok = false;
                            break;
                        }
                    }
                        if (ok)
                            GetQueen(now + 1);
                }
            }
        }
        static void GetQueen_anotherway(int now)
        {
            if (now == lenth)
            {
                situation++;
            }
            else
            {
                for (int i = 0; i < lenth; i++)
                {
                    if (!allow[0][i] && !allow[1][i - now + lenth] && !allow[2][i + now])
                    {
                        chessbroad[now] = i;
                        allow[0][i] = true;allow[1][i - now + lenth] = true;allow[2][i + now] = true;
                        GetQueen_anotherway(now + 1);
                        allow[0][i] = false; allow[1][i - now + lenth] = false; allow[2][i + now] = false;
                    }
                }
            }
        }
    }
}
