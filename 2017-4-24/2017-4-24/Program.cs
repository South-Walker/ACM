using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_24
{
    class Program
    {
        static int[,] arr;
        static void Main(string[] args)
        {
            Risk();
        }
        public static void Risk()
        {
            arr = new int[21, 21];
            FillArr(1, 3);
            FillArr(2, 3, 4);
            FillArr(3, 4, 5, 6);
            FillArr(4, 6);
            FillArr(5, 7);
            FillArr(6, 12, 13);
            FillArr(7, 8);
            FillArr(8, 9, 10);
            FillArr(9, 11);
            FillArr(10, 11);
            FillArr(11, 12, 17);
            FillArr(12, 14);
            FillArr(13, 14, 15);
            FillArr(14, 15, 16);
            FillArr(15, 16);
            FillArr(16, 19);
            FillArr(17, 18, 19);
            FillArr(18, 20);
            FillArr(19, 20);
            for (int a = 1; a <= 20; a++)
            {
                for (int b = 1; b <= 20; b++)
                {
                    if (arr[a, b] != 1)
                        arr[a, b] = 20;
                }
            }
            for (int a = 1; a <= 20; a++)
            {
                for (int b = 1; b <= 20; b++)
                {
                    for (int c = 1; c <= 20; c++)
                    {
                        if (arr[c, b] > arr[c, a] + arr[a, b])
                            arr[c, b] = arr[b, c] = arr[c, a] + arr[a, b];
                    }
                }
            }
            Console.Read();
        }
        public static void FillArr(int now, params int[] input)
        {
            foreach (int a in input)
            {
                arr[now, a] = 1;
                arr[a, now] = 1;
            }
        }
    }
}
