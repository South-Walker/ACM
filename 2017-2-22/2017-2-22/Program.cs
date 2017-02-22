using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_2_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(add(10));
            Console.Read();
        }

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
    }
}
