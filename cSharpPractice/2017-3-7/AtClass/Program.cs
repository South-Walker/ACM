using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtClass
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int fc(int now)
        {

            Console.WriteLine(fc((now + 1) * 10));
            Console.WriteLine(fc(now * 10 + 1));
            return now;

        }
    }
}
