using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_7
{
    class Program
    {
        static int[] int_array = { 1, 2};
        static void Main(string[] args)
        {
            //10976
            #region
            /*
            double k = Convert.ToDouble(Console.ReadLine());
            Stack stack = new Stack();
            double y = 0;
            for (double x = k + 1; x < 2 * k; x++)
            {
                y = Get_y(x, k);
                if (y % 1 != 0)
                    continue;
                if (k == x * y / (x + y))
                {
                    stack.Push(y);
                    stack.Push(x);
                    Console.WriteLine("1/" + k.ToString() + " = 1/" + x.ToString() + " + 1/" + y.ToString());
                }
            }
            Console.WriteLine("1/" + k.ToString() + " = 1/" + (k * 2).ToString() + " + 1/" + (k * 2).ToString());
            while (stack.Count == 0)
            {
                Console.WriteLine("1/" + k.ToString() + " = 1/" + stack.Pop().ToString() + " + 1/" + stack.Pop().ToString());
            }
            Main(new string[1]);
            */
            #endregion
            //枚举集合中所有子集，按字典序排列，递归实现（C#）
            #region
            SortArray(int_array);//数组由小到大排序
            Print(new int[4], 0);
            Console.ReadLine();
            #endregion
        }
        static double Get_y(double x, double k)
        {
            return k * x / (x - k);
        }
        static void SortArray(int[]array)
        {
            //排序数组
        }
        static void Print(int[]array, int now)
        {
            //递归边界
            if (now == int_array.Length) 
            {
                foreach (int num in array)
                {
                    Console.Write(num);
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < int_array.Length; i++)
                {
                    if (sRepeat(array, i))
                    {
                        array[now] = int_array[i];
                        Console.Write(array[now]);
                        Print(array, now + 1);
                    }
                }
            }
        }
        static bool IsRepeat(int[] a,int i)
        {
            int times = 0; 
            foreach(int num in a)
            {
                if (int_array[i] == num)
                {
                    times++;
                }
            }
            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] == int_array[i]) 
                {
                    times--;
                }
            }
            if (times > 0) 
                return true;
            return false;
        }
        static bool sRepeat(int[]a,int i)
        {
            foreach(int y in a)
            {
                if (y == int_array[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
