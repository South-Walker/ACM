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
        static void Main(string[] args)
        {
            //10976
            #region
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
            #endregion
        }
        static double Get_y(double x, double k)
        {
            return k * x / (x - k);
        }
    }
}
