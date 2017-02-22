using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_2_22
{
    class Program
    {
        static int[] array = { 0, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 };
        static int times = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(totaltimes(1, 10) / 10);
            Console.Read();
        }

        static int totaltimes(int begin,int num)
        {
            if(begin == num)
            {
                int sum = array[1] + array[3] + array[6] + array[9];
                if (sum - array[2] - array[6] - array[7] - array[10] == 0 && sum - array[9] - array[7] - array[8] - array[5] == 0 && sum - array[2] - array[3] - array[4] - array[5] == 0 && sum - array[1] - array[4] - array[8] - array[10] == 0)
                { times++; }
            }
            for (int i = begin; i <= num; i++)
            {
                swap(ref array[begin], ref array[i]);
                totaltimes(begin + 1, num);
                swap(ref array[begin], ref array[i]);
            }
            return times;
        }//统计数组全排列，筛选符合条件数组
        static int add(int end)
        {
            if(end == 1)
            {
                return 1;
            }
            else
            {
                return add(end - 1) + end;
            }
        }//递归，累加
        static void swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }//交换
    }
}
