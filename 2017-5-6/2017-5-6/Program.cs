using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_6
{
    class Program
    {
        static int a = 3;
        static int b = 7;
        static string st_input = "##9784#\r##123##\r##45###";
        static string[,] ar_input = new string[3, 7];
        static int[,] DP = new int[3, 7];
        static void Main(string[] args)
        {
            BiggestNumber();
        }
        static void BiggestNumber()
        {
            Fill(st_input);
            Console.Read();
        }
        static void Fill(string input)
        {
            string[] ar_string = input.Split('\r');
            int len = ar_string.Length;string now = "";
            for (int i = 0; i < a; i++)
            {
                now = ar_string[i];
                for (int k = 0; k < b; k++)
                {
                    ar_input[i, k] = now.Substring(k, 1);
                }
            }
        }
    }
}
