using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_30
{
    class Program
    {
        static int[,] road = new int[51, 51];
        static int[,] DijkstraArr = new int[51, 51];
        static int max = 500000000;
        static int[,] prenode = new int[51, 51];
        static void Main(string[] args)
        {
            Cycle();
        }
        public static void Cycle()
        {
            for (int a = 0; a <= 50; a++)
            {
                for (int b = 0; b <= 50; b++)
                {
                    road[a, b] = max;
                    DijkstraArr[a, b] = max;
                }
            }
            FillRoad(1, 2, 2);
            FillRoad(2, 1, 3);
            for (int i = 0; i <= 50; i++)
            {
                Dijkstra(i);
            }
            for (int i = 0; i <= 50; i++)
            {
                DijkstraArr[i, i] = max;
            }
            double decmincycle = max;
            for (int a = 1; a <= 50; a++)
            {
                for (int b = 1; b <= 50; b++)
                {
                    double mincyclenum = 0;
                    int prenodeofb = prenode[a, b];
                    while (prenodeofb != 0)
                    {
                        mincyclenum++;
                        prenodeofb = prenode[a, prenodeofb];
                    }
                    if (mincyclenum == 0)
                        continue;
                    else
                        mincyclenum++;
                    int now = DijkstraArr[a, b] + road[b, a];
                    if (now / mincyclenum < decmincycle)
                        decmincycle = now / mincyclenum;
                }
            }
            if (decmincycle < max)
            {
                Console.WriteLine(decmincycle);
            }
            else
                Console.WriteLine("no found");
            Console.Read();
        }
        public static void Dijkstra(int start)
        {
            int[] temp = new int[51];
            for (int i = 0; i < 51; i++)
            {
                temp[i] = max;
            }
            temp[start] = 0;

            for (int i = 1; i <= 50; i++)
            {
                int min = max;
                int minnum = 0;
                for (int a = 0; a <= 50; a++)
                {
                    if (temp[a] < min && temp[a] != -1) 
                    {
                        minnum = a;
                        min = temp[a];
                    }
                }
                DijkstraArr[start, minnum] = min;
                temp[minnum] = -1;
                for (int a = 0; a <= 50; a++)
                {
                    if (temp[a] != -1 && temp[a] > min + road[minnum, a])
                    {
                        temp[a] = min + road[minnum, a];
                        prenode[start, a] = minnum;
                    }
                }
            }
        }
        public static void FillRoad(int a, int b, int length)
        {
            road[a, b] = length;
        }
    }
}
