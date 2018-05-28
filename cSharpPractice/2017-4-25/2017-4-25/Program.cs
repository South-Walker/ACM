using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_25
{
    class Program
    {
        static int[,] arr;
        static void Main(string[] args)
        {
            Guide();
        }
        public static void Guide()
        {
            arr = new int[8, 8];
            FillArr(1, 2, 30);
            FillArr(1, 3, 15);
            FillArr(1, 4, 10);
            FillArr(2, 4, 25);
            FillArr(2, 5, 60);
            FillArr(3, 4, 40);
            FillArr(3, 6, 20);
            FillArr(4, 7, 35);
            FillArr(5, 7, 20);
            FillArr(6, 7, 30);
            int passenger = 99;
            int scity = 1;
            int dcity = 7;
            for (int a = 1; a < 8; a++)
            {
                for (int b = 1; b < 8; b++)
                {
                    for (int c = 1; c < 8; c++)
                    {
                        if (arr[b, c] < min(arr[a, b], arr[c, a]))
                        {
                            arr[b, c] = arr[c, b] = min(arr[a, b], arr[c, a]);
                        }
                    }
                }
            }
            Console.Read();
        }
        public static void FillArr(int index1, int index2, int maxnum)
        {
            arr[index1, index2] = arr[index2, index1] = maxnum - 1;
        }
        public static int min(params int[]num)
        {
            int min = num[0];
            foreach (int a in num)
            {
                if (a < min)
                {
                    min = a;
                }
            }
            return min;
        }
    }
}
