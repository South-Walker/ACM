using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_26
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = { "0 2 0 4", "0 3 0 1", "1 1 1 1", "2 4 4 2", "1 6 3 2" };
            int weight = 0;
            int index = 0;
            Console.WriteLine(uva839(input, ref index, ref weight));
            Console.Read();
        }
        public static bool uva839(string[] input, ref int index, ref int weight)
        {
            string now = input[index];
            index++;
            string[] wd = now.Split(' ');
            int w1 = Convert.ToInt32(wd[0]);
            int w2 = Convert.ToInt32(wd[2]);
            int d1 = Convert.ToInt32(wd[1]);
            int d2 = Convert.ToInt32(wd[3]);
            bool b1 = true;bool b2 = true;
            if (w1 == 0)
                b1 = uva839(input, ref index, ref w1);
            if (w2 == 0)
                b2 = uva839(input, ref index, ref w2);
            weight = w1 + w2;
            if (b1 && b2 && (w1 * d1 == w2 * d2))
                return true;
            else
                return false;
        }
    }
}
