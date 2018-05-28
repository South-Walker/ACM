using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_26
{
    class Program
    {
        static int total = 0;
        static int point = 5;
        static int[,] arr = new int[point + 1, point + 1];
        static int[] array1 = new int[point + 1];
        static int[] minnest = new int[point + 1];
        static int min = 1000000000;
        static int minnum = 2;
        static void Main(string[] args)
        {
            Forest();
            Console.Write(total);
            Console.Read();
        }
        public static void Forest()
        {
            for (int a = 1; a <= point; a++)
            {
                for (int b = 1; b <= point; b++)
                {
                    arr[a, b] = 1000000000;
                }
            }
            FillArr(1, 3, 2);
            FillArr(1, 4, 2);
            FillArr(3, 4, 3);
            FillArr(1, 5, 12);
            FillArr(4, 2, 34);
            FillArr(5, 2, 24);
            for (int i = 1; i <= point; i++)
            {
                minnest[i] = arr[2, i];
                if (minnest[i] == 0)
                {
                    minnest[i] = 1000000000;
                }
            }
            for (int i = 0; i < point; i++)
            {
                for (int a = 1; a <= point; a++)
                {
                    if (minnest[a] < min)
                    {
                        minnum = a;
                        min = minnest[a];
                    }
                }
                minnest[minnum] = 1000000000;
                array1[minnum] = min;
                for (int b = 1; b <= point; b++)//weihu
                {
                    if (b == 2)
                    {
                        continue;
                    }
                    if (arr[minnum, b] + min < minnest[b] && array1[b] == 0) 
                    {
                        minnest[b] = arr[minnum, b] + min;
                    }
                }
                min = 1000000000;
                minnum = 2;
            }
            array1[2] = 0;
            DFS_FindRoute(1);
        }
        public static void FillArr(int index1, int index2, int length)
        {
            arr[index1, index2] = arr[index2, index1] = length;
        }
        public static void DFS_FindRoute(int nowposition)
        {
            if(nowposition == 2)
            {
                total++;
                return;
            }
            int nowdistance = array1[nowposition];
            for (int i = 1; i <= point; i++)
            {
                if (arr[i, nowposition] <= 1000000 && array1[i] <= nowdistance)
                {
                    DFS_FindRoute(i);
                }
            }
        }
    }
}
